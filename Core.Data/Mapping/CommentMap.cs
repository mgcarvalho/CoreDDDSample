// <copyright file="CommentMap.cs" company="Academic Lab" >
//   Copyright (c) Marcelo Carvalho. All rights reserved.
// </copyright>
// <author>Marcelo Carvalho</author>
namespace Core.Data.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Core.Domain.Entity;
    /// <summary>
    /// Mapping class to user
    /// </summary>
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        /// <summary>
        /// Configure the class
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Text)
                .IsRequired()
                .HasColumnName("Text");

            //Complex
            builder.Property(c => c.Create)
                .IsRequired()
                .HasColumnName("Created");

            builder.Property(c => c.User)
                .IsRequired()
                .HasColumnName("UserId");

            builder.Property(c => c.Post)
                .IsRequired()
                .HasColumnName("UserId");
        }
    }
}