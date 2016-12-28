using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarService.Core.Entities
{
    /// <summary>
    /// Base class with Id property
    /// </summary>
    public abstract class ModelId:  TimeStamp, IEntity
    {
        
        // Initialize unique order identifyer
        public ModelId()
        {
            Id = Guid.NewGuid();
        }
        // Id property
        [Key]
        public Guid Id { get; private set; }
    }
}