// <copyright file="PostMap.cs" company="Academic Lab" >
//   Copyright (c) Marcelo Carvalho. All rights reserved.
// </copyright>
// <author>Marcelo Carvalho</author>
namespace Core.Data.Mapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Core.Domain.Entity;
    /// <summary>
    /// Mapping class to Post
    /// </summary>
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        /// <summary>
        /// Configure the class
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Subject)
                .IsRequired()
                .HasColumnName("Subject");

            builder.Property(c => c.Text)
                .IsRequired()
                .HasColumnName("Text");            
            
            builder.Property(c => c.Open)
                .IsRequired()
                .HasColumnName("Active");

            //Complex
            builder.Property(c => c.Create)
                .IsRequired()
                .HasColumnName("Created");

            builder.Property(c => c.User)
                .IsRequired()
                .HasColumnName("UserId");
        }
    }
}