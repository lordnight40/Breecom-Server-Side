using otec.egory.api.dto.Entities;

namespace otec.egory.api.IO.Reponse
{
    public class CardResponseModel
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        
        public BrandResponseModel Brand { get; set; }
    }
}