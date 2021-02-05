using System;
using System.ComponentModel.DataAnnotations;
using otec.egory.api.dto.Base;

namespace otec.egory.api.dto.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Name { get; set; }
        
        public virtual Brand Brand { get; set; }
    }
}