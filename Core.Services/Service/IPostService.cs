namespace Core.Services.Service
{
    using Core.Services.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPostService
    {
        Task<IEnumerable<PostView>> GetPosts();
        
        Task<PostView> GetPost(Guid postId);
        
        Task<PostView> CreatePost(PostView postToCreate);
                
        Task UpdatePost(PostView postToUpdate);
        
        Task DeletePost(Guid postId);
    }
}
