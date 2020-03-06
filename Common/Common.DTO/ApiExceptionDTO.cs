namespace Common.DTO
{
    public class ApiExceptionDto
    {
        public ApiExceptionDto(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public string Message { get; set; }

        public int StatusCode { get; set; }
    }
}