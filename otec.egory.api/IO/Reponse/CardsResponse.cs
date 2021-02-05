using System.Collections.Generic;
using otec.egory.api.dto.Entities;

namespace otec.egory.api.IO.Reponse
{
    public class CardsResponse : BaseResponse
    {
        public IEnumerable<Product> Data { get; set; }
    }
}