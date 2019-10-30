using Core.Domain.Entity;
using Core.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Factory
{
    public static class ViewModelFactory
    {
        public static PostView CreateViewModel(Post postToView)
        {
            //Have it return a new GameViewModel instance with it's property assign to the gameTOView properties.
            return new PostView()
            {
                Id = postToView.Id,
                Subject = postToView.Subject,
                Text = postToView.Text,
                Create = postToView.Create,
                PosterEmail = postToView.OwnerEmail,
                PosterName = postToView.OwnerName,
                Open = postToView.Open
            };
        }

        public static Post CreateDomainModel(PostView postToCreate)
        {
            return new Post()
            {
                Subject = postToCreate.Subject,
                Text = postToCreate.Text,
                OwnerName = postToCreate.PosterName,
                OwnerEmail = postToCreate.PosterEmail,
                Open = true,
                Create = postToCreate.Create == DateTime.MinValue ? DateTime.Now : postToCreate.Create
            };
        }
    }
}
