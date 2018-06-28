namespace WebApi.Core.Responses
{
    public class SimpleWithReturnResponse
    {
        public SimpleWithReturnResponse(string result)
        {
            this.Result = result;
        }

        public string Result { get; }
    }
}