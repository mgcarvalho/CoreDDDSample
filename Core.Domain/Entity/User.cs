// <copyright file="User.cs" company="Academic Lab" >
//   Copyright (c) Marcelo Carvalho. All rights reserved.
// </copyright>
// <author>Marcelo Carvalho</author>
namespace Core.Domain.Entity
{
    using System;

    /// <summary>
    /// User Entity
    /// IF this information camos from a gateway, so I need only a user token and a list of claims
    /// </summary>
    public class User : EntityBase
    {
        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class
        /// </summary>
        public User()
        {
            this.Id = new Guid();
        }
        #endregion

        /// <summary>
        /// Gets or sets the name of user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the EMail of user
        /// </summary>
        public string EMail { get; set; }

        /// <summary>
        /// Gets a value indicating whether if the user has admin rule 
        /// </summary>
        public bool IsAdmin { get; private set; }

        #region Overrides
        /// <summary>
        /// Describes the value class
        /// </summary>
        /// <returns>String of object</returns>
        public override string ToString()
        {
            return $"Id: {this.Id}, Name: {this.Name}, E-Mail: {this.EMail} {(IsAdmin ? ",Administrator" : string.Empty)}";
        }

        /// <summary>
        /// Check if objects are equals
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>Boolean that if is equal</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || (obj as User) == null)
            {
                return false;
            }
            else
            {
                User compare = obj as User;
                return this.Id.Equals(compare.Id) 
                    && this.Name.Equals(compare.Name, StringComparison.InvariantCultureIgnoreCase) 
                    && this.EMail.Equals(compare.EMail, StringComparison.InvariantCultureIgnoreCase)
                    && this.IsAdmin == compare.IsAdmin;
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
                hc = (hc * 4) + this.Name.GetHashCode();
                hc = (hc * 4) + this.EMail.GetHashCode();
                hc = (hc * 4) + this.IsAdmin.GetHashCode();
                return hc;
            }
        }
        #endregion
    }
}
