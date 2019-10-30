// <copyright file="Comment.cs" company="Academic Lab" >
//   Copyright (c) Marcelo Carvalho. All rights reserved.
// </copyright>
// <author>Marcelo Carvalho</author>
namespace Core.Domain.Entity
{
    using System;

    /// <summary>
    /// Comment Entity
    /// </summary>
    public class Comment : EntityBase
    {
        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="Comment"/> class
        /// </summary>
        public Comment()
        {
            this.Id = new Guid();
            this.Create = new DateTime();
            this.Post = new Post();
        }
        #endregion

        /// <summary>
        /// Gets or sets the reference post of this comment
        /// </summary>
        public Post Post { get; set; }

        /// <summary>
        /// Gets or sets the comment text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the date that this comment was created
        /// </summary>
        public DateTime Create { get; set; }

        /// <summary>
        /// Gets or sets the owner name
        /// </summary>
        public string CommentName { get; set; }

        /// <summary>
        /// Gets or sets the owner email
        /// </summary>
        public string CommentEmail { get; set; }

        #region Overrides
        /// <summary>
        /// Describes the value class
        /// </summary>
        /// <returns>String of object</returns>
        public override string ToString()
        {
            return $"Id: {this.Id}, Post: {this.Post.ToString()}, Text: {this.Text}, Date: {this.Create.ToString()}, Comment Owner: {this.CommentName}-{this.CommentEmail}.";
        }
        
        /// <summary>
        /// Check if objects are equals
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>Boolean that if is equal</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || (obj as Comment) == null)
            {
                return false;
            }
            else
            {
                Comment compare = obj as Comment;
                return (this.Id.Equals(compare.Id)
                    && this.Post.Equals(compare.Post)
                    && this.Text.Equals(compare.Text, StringComparison.InvariantCultureIgnoreCase))
                    && DateTime.Compare(this.Create, compare.Create) == 0
                    && this.CommentName.Equals(compare.CommentName)
                    && this.CommentName.Equals(compare.CommentEmail);
            }
        }

        /// <summary>
        /// Get hash code of object
        /// </summary>
        /// <returns>Hash code by value fields</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hc = this.Id.GetHashCode();
                hc = (hc * 6) + this.Post.GetHashCode();
                hc = (hc * 6) + this.Text.GetHashCode();
                hc = (hc * 6) + this.Create.GetHashCode();
                hc = (hc * 6) + this.CommentName.GetHashCode();
                hc = (hc * 6) + this.CommentEmail.GetHashCode();
                return hc;
            }
        }

        #endregion
    }
}
