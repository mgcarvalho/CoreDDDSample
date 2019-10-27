// <copyright file="Post.cs" company="Academic Lab" >
//   Copyright (c) Marcelo Carvalho. All rights reserved.
// </copyright>
// <author>Marcelo Carvalho</author>
namespace Core.Domain.Entity
{
    using System;

    public class Post: EntityBase
    {
        #region ctor
        public Post()
        {
            base.Id = new Guid();
            this.Create = new DateTime();
            this.User = new User();
        }
        #endregion

        public string Subject { get; set; }

        public string Text { get; set; }

        public DateTime Create { get; set; }

        public User User { get; set; }

        public bool Open { get; set; }

        #region Overrides
        public override string ToString()
        {
            return $"Id: {base.Id}, Subject: {this.Subject}, Text: {this.Text}, Date: {this.Create.ToString()}, Post Owner: {this.User.ToString()}.";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || (obj as Post) == null)
            {
                return false;
            }
            else
            {
                Post compare = obj as Post;
                return (base.Id.Equals(compare.Id) 
                    && this.Subject.Equals(compare.Subject, StringComparison.InvariantCultureIgnoreCase) 
                    && this.Text.Equals(compare.Text, StringComparison.InvariantCultureIgnoreCase))
                    && DateTime.Compare(this.Create, compare.Create)==0
                    && this.User.Equals(compare.User);
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hc = base.Id.GetHashCode();
                hc = (hc * 5) + this.Subject.GetHashCode();
                hc = (hc * 5) + this.Text.GetHashCode();
                hc = (hc * 5) + this.Create.GetHashCode();
                hc = (hc * 5) + this.User.GetHashCode();
                return hc;
            }
        }

        #endregion

    }
}
