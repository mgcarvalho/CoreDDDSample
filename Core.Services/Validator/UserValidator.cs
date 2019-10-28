// <copyright file="UserValidator.cs" company="Academic Lab" >
//   Copyright (c) Marcelo Carvalho. All rights reserved.
// </copyright>
// <author>Marcelo Carvalho</author>
namespace Core.Services.Validator
{
    using System;

    using Core.Domain.Entity;
    using FluentValidation;

    /// <summary>
    /// Validator for user
    /// </summary>
    public class UserValidator : AbstractValidator<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserValidator"/> class
        /// </summary>
        public UserValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Can't found the object.");
                    });

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Is necessary to inform the Name of user.")
                .NotNull().WithMessage("Is necessary to inform the Name of user.");

            RuleFor(c => c.EMail)
                .NotEmpty().WithMessage("Is necessary to inform the e-Mail of user.")
                .NotNull().WithMessage("Is necessary to inform the e-Mail of user.");
        }
    }
}
