namespace Core.Services.Service.concrete
{
    using Core.Domain.Entity;
    using Core.Services.Factory;
    using Core.Services.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Core.Domain.Repository;

    public class PostService : IPostService
    {

        private readonly IRepository<Post> _repository;


        public PostService(IRepository<Post> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PostView>> GetPosts()
        {
            var Returned = await _repository.ReadAllAsync();
            return Returned.Select(c => ViewModelFactory.CreateViewModel(c));
        }

        public async Task<PostView> GetPost(Guid id)
        {
            PostView gameToReturn = ViewModelFactory.CreateViewModel(await _repository.ReadByGuidAsync(id));
            return gameToReturn;
        }

        public async Task<PostView> CreatePost(PostView postToCreate)
        {
            if (string.IsNullOrEmpty(postToCreate.PosterEmail)) { throw new ArgumentNullException("Null Email"); }
            var newPost = ViewModelFactory.CreateDomainModel(postToCreate);
            await _repository.CreateAsync(newPost);
            return postToCreate;
        }

        public async Task UpdatePost(PostView postToUpdate)
        {
            var updatedItem = ViewModelFactory.CreateDomainModel(postToUpdate);
            await _repository.UpdateAsync(updatedItem);
        }

        public async Task DeletePost(Guid postId)
        {
            var deleteItem = await _repository.ReadByGuidAsync(postId);
            await  _repository.DeleteAsync(deleteItem);
        }
    }
}
