using otec.egory.api.dto.Entities;

using System;

namespace otec.egory.api.IO.Reponse
{
    public class CardResponseModel
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        
        public BrandResponseModel Brand { get; set; }
    }
}