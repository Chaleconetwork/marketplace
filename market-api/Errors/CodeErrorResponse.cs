namespace market_api.Errors
{
    public class CodeErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public CodeErrorResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string? GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "El request enviado tiene errores",
                401 => "No tienes autorización para este recurso",
                404 => "El recurso no se ha encontrado",
                500 => "Se ha producido un error con la comunicación al servidor", 
                _=> null
            };
        }
    }
}
