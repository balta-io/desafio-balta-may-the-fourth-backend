namespace May.The.Fourth.Backend.Services.Messages
{
    public class ResponseBase
    {
        public bool Success { get; set; }
        public string Message { get; set; } = String.Empty;
        public int StatusCode { get; set; }
    }
}