namespace Core.Domain.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
