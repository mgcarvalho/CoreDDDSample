﻿

namespace Core.Domain.Entity
{
    using System;

    public class Comment:EntityBase
    {
        #region ctor
        public Comment()
        {
            base.Id = new Guid();
            this.Create = new DateTime();
            this.Post = new Post();
            this.User = new User();
        }
        #endregion

        public Post Post { get; set; }

        public string Text { get; set; }

        public DateTime Create { get; set; }

        public User User { get; set; }

        #region Overrides
        public override string ToString()
        {
            return $"Id: {base.Id}, Post: {this.Post.ToString()}, Text: {this.Text}, Date: {this.Create.ToString()}, Comment Owner: {this.User.ToString()}.";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || (obj as Comment) == null)
            {
                return false;
            }
            else
            {
                Comment compare = obj as Comment;
                return (base.Id.Equals(compare.Id)
                    && this.Post.Equals(compare.Post)
                    && this.Text.Equals(compare.Text, StringComparison.InvariantCultureIgnoreCase))
                    && DateTime.Compare(this.Create, compare.Create) == 0
                    && this.User.Equals(compare.User);
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hc = base.Id.GetHashCode();
                hc = (hc * 5) + this.Post.GetHashCode();
                hc = (hc * 5) + this.Text.GetHashCode();
                hc = (hc * 5) + this.Create.GetHashCode();
                hc = (hc * 5) + this.User.GetHashCode();
                return hc;
            }
        }

        #endregion
    }
}