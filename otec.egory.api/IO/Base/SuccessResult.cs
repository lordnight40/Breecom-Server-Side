using System.Net;

namespace otec.egory.api.IO.Base
{
    public class SuccessResult
    {
        public bool Success => true;
        public HttpStatusCode StatusCode { get; set; }
    }
}