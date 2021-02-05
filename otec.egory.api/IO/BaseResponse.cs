namespace otec.egory.api.IO
{
    public abstract class BaseResponse
    {
        public bool Success { get; set; }
        public string Error { get; set; }
    }
}