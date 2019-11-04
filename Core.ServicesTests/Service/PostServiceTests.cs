
namespace Core.Services.Service.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Moq;
    using Xunit;

    using Core.Domain.Repository;
    using Core.Domain.Entity;
    using Core.Services.Factory;
    using Core.Services.ViewModel;
    using Core.Services.Service.concrete;


    [ExcludeFromCodeCoverage]
    [Trait("Unit", "CreateDriverManifest")]
    public class PostServiceTests
    {
        private readonly Mock<IRepository<Post>> fakeRepository = new Mock<IRepository<Post>>();
        private readonly PostService postService; 


        [Fact(DisplayName = nameof(PostTest_Ok))]
        public async Task PostTest_Ok()
        {
            //Arrange
            PostView pv = new PostView() { Create = DateTime.Now, Id = new Guid(), PosterEmail = "tester@mail.com" };
            this.fakeRepository.Setup(fk => fk.CreateAsync(It.IsAny<Post>()));

            //Act
            var result = await postService.CreatePost(pv);

            //Assert
            Assert.Equal(pv.Id, result.Id);
        }

        [Fact(DisplayName = nameof(PostTest_FailureEmail))]
        public async Task PostTest_FailureEmail()
        {
            //Arrange
            PostView pv = new PostView() { Create = DateTime.Now, Id = new Guid(), PosterEmail = string.Empty };
            this.fakeRepository.Setup(fk => fk.CreateAsync(It.IsAny<Post>()));

            //Act
            var result = await postService.CreatePost(pv);

            //Assert
            Assert.Equal(pv.Id, result.Id);
        }
    }
}