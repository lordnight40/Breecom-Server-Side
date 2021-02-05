using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using otec.egory.api.dto.Base;

namespace otec.egory.api.dto.Entities
{
    public class Brand : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Info { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
    }
}