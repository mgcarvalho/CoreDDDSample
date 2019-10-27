// <copyright file="MySqlContext.cs" company="Academic Lab" >
//   Copyright (c) Marcelo Carvalho. All rights reserved.
// </copyright>
// <author>Marcelo Carvalho</author>
namespace Core.Data.Context
{
    using Core.Data.Mapping;
    using Core.Domain.Entity;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Manager the Context
    /// </summary>
    public class MySqlContext : DbContext
    {
        /// <summary>
        /// Gets or sets the data base set for User
        /// </summary>
        public DbSet<User> User { get; set; }

        /// <summary>
        /// Gets or sets the data base set for post
        /// </summary>
        public DbSet<Post> Post { get; set; }

        /// <summary>
        /// Gets or sets the data base set for comment
        /// </summary>
        public DbSet<Comment> Comment { get; set; }

        /// <summary>
        /// Context configuration
        /// </summary>
        /// <param name="optionsBuilder">Options of data base</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=[SERVIDOR];Port=[PORTA];Database=modelo;Uid=[USUARIO];Pwd=[SENHA]");
            }
        }

        /// <summary>
        /// Data base model builder
        /// </summary>
        /// <param name="modelBuilder">Model builder evoke</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<Post>(new PostMap().Configure);
            modelBuilder.Entity<Comment>(new CommentMap().Configure);
        }
    }
}
