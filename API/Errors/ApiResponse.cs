using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetMessageForStatusCode(StatusCode);
        }

        private string GetMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorised, you are not",
                404 => "Resource found, it was not",
                500 => "Errors are a path to the Dark side. Errors leads to anger, anger lead to hate, hate leads to career change!",
                _ => null
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}