// <copyright file="EntityBase.cs" company="Academic Lab" >
//   Copyright (c) Marcelo Carvalho. All rights reserved.
// </copyright>
// <author>Marcelo Carvalho</author>
namespace Core.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    /// <summary>
    /// Entity base
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// Gets or sets the unique identifier
        /// </summary>
        [Key]
        public Guid Id { get; set; }
    }
}
