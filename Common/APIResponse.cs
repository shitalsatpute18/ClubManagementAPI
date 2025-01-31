namespace ClubManagementAPI.Common
{
    public class APIResponse<T>
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public APIResponse(int statusCode, bool success, string message, T data)
        {
            StatusCode = statusCode;
            Success = success;
            Message = message;
            Data = data;
        }
    }
}





