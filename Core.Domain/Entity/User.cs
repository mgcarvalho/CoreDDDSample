// <copyright file="User.cs" company="Academic Lab" >
//   Copyright (c) Marcelo Carvalho. All rights reserved.
// </copyright>
// <author>Marcelo Carvalho</author>
namespace Core.Domain.Entity
{
    using System;

    public class User : EntityBase
    {
        #region ctor
        public User()
        {
            base.Id = new Guid();
        }
        #endregion

        public string Name { get; set; }

        public string EMail { get; set; }

        #region Overrides
        public override string ToString()
        {
            return $"Id: {base.Id}, Name: {this.Name}, E-Mail: {this.EMail}.";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || (obj as User) == null)
            {
                return false;
            }
            else
            {
                User compare = obj as User;
                return (base.Id.Equals(compare.Id) && this.Name.Equals(compare.Name, StringComparison.InvariantCultureIgnoreCase) && this.EMail.Equals(compare.EMail, StringComparison.InvariantCultureIgnoreCase));
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hc = base.Id.GetHashCode();
                hc = (hc * 3) + this.Name.GetHashCode();
                hc = (hc * 3) + this.EMail.GetHashCode();
                return hc;
            }
        }

        #endregion

    }
}
