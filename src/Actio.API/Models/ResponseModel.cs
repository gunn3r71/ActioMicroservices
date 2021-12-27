namespace Actio.API.Models
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public dynamic Data { get; set; }
    }
}
