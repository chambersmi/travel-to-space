namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            // New switch way
            return statusCode switch {
                400 => "Bad Request (400)",
                401 => "Authorization Error (401)",
                404 => "Resource not found.",
                500 => "Internal Server Error.",
                _ => null
            };
        }


    }
}