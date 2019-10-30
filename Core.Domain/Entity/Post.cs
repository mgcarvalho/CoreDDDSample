// <copyright file="Post.cs" company="Academic Lab" >
//   Copyright (c) Marcelo Carvalho. All rights reserved.
// </copyright>
// <author>Marcelo Carvalho</author>
namespace Core.Domain.Entity
{
    using System;

    /// <summary>
    /// User Entity
    /// </summary>
    public class Post : EntityBase
    {
        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="Post"/> class
        /// </summary>
        public Post()
        {
            this.Id = new Guid();
            this.Create = new DateTime();
        }
        #endregion

        /// <summary>
        /// Gets or sets the subject of post
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the text of post
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the date of created
        /// </summary>
        public DateTime Create { get; set; }

        /// <summary>
        /// Gets or sets the owner name
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// Gets or sets the owner email
        /// </summary>
        public string OwnerEmail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the post is open.
        /// </summary>
        public bool Open { get; set; }

        #region Overrides
        /// <summary>
        /// Describes the value class
        /// </summary>
        /// <returns>String of object</returns>
        public override string ToString()
        {
            return $"Id: {this.Id}, Subject: {this.Subject}, Text: {this.Text}, Date: {this.Create.ToString()}, Post Owner: {this.OwnerName}-{this.OwnerEmail}.";
        }

        /// <summary>
        /// Check if objects are equals
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>Boolean that if is equal</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || (obj as Post) == null)
            {
                return false;
            }
            else
            {
                Post compare = obj as Post;
                return (this.Id.Equals(compare.Id) 
                    && this.Subject.Equals(compare.Subject, StringComparison.InvariantCultureIgnoreCase) 
                    && this.Text.Equals(compare.Text, StringComparison.InvariantCultureIgnoreCase))
                    && DateTime.Compare(this.Create, compare.Create) == 0;
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
                hc = (hc * 5) + this.Subject.GetHashCode();
                hc = (hc * 5) + this.Text.GetHashCode();
                hc = (hc * 5) + this.Create.GetHashCode();
                return hc;
            }
        }
        #endregion
    }
}
