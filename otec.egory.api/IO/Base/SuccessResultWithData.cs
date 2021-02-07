namespace otec.egory.api.IO.Base
{
    public class SuccessResultWithData<TResult> : SuccessResult
    {
        public TResult Data { get; set; }
    }
}