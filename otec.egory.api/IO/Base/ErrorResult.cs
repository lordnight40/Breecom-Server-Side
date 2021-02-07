using System.Net;

namespace otec.egory.api.IO.Base
{
    public class ErrorResult
    {
        public bool Success => true;
        public HttpStatusCode StatusCode { get; set; }
        public string Error { get; set; }
    }
}