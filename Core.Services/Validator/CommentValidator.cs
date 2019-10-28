// <copyright file="CommentValidator.cs" company="Academic Lab" >
//   Copyright (c) Marcelo Carvalho. All rights reserved.
// </copyright>
// <author>Marcelo Carvalho</author>
namespace Core.Services.Validator
{
    using System;

    using Core.Domain.Entity;
    using FluentValidation;

    /// <summary>
    /// Validator for comment
    /// </summary>
    public class CommentValidator : AbstractValidator<Comment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentValidator"/> class
        /// </summary>
        public CommentValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Can't found the object.");
                    });

            RuleFor(c => c.Text)
                .NotEmpty().WithMessage("Is necessary to inform the text of post.")
                .NotNull().WithMessage("Is necessary to inform the text of post.");

            RuleFor(c => c.User)
                .SetValidator(new UserValidator());

            RuleFor(c => c.Post)
                .NotNull().WithMessage("Is necessary to inform the post associated.");

            // Can't comment closed post
            RuleFor(c => c.Post.Open)
                 .NotNull().NotEqual(false).WithMessage("Can't comment a close post.");
        }
    }
}
