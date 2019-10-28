// <copyright file="PostValidator.cs" company="Academic Lab" >
//   Copyright (c) Marcelo Carvalho. All rights reserved.
// </copyright>
// <author>Marcelo Carvalho</author>
namespace Core.Services.Validator
{
    using System;
    
    using Core.Domain.Entity;
    using FluentValidation;

    /// <summary>
    /// Validator for Post
    /// </summary>
    public class PostValidator : AbstractValidator<Post>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostValidator"/> class
        /// </summary>
        public PostValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Can't found the object.");
                    });

            RuleFor(c => c.Subject)
                .NotEmpty().WithMessage("Is necessary to inform the subject of post.")
                .NotNull().WithMessage("Is necessary to inform the subject of post.");

            RuleFor(c => c.Text)
                .NotEmpty().WithMessage("Is necessary to inform the text of post.")
                .NotNull().WithMessage("Is necessary to inform the text of post.");

            RuleFor(c => c.User)
                .SetValidator(new UserValidator());

            // An admin can't make a post
            RuleFor(c => c.User.IsAdmin)
                .NotNull().NotEqual(true).WithMessage("The admin can't be an owner of post.");
        }
    }
}
