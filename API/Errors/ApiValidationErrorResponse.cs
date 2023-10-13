
namespace API.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(400)
        {
            // Coming from [ApiController]
        }

        public IEnumerable<string> Errors { get; set; }
    }
}