namespace OfficePrinterAssistant.ApplicationServices.API.ErrorHandling
{
    public static class ErrorType
    {
        public const string InternalServerError = "Internal_Server_Error";
        public const string ValidationError = "Validation_Error";
        public const string NotAunthenticated = "Not_Aunthenticated";
        public const string Unauthorized = "Unauthorized";
        public const string NotFound = "Not_Found";
        public const string UnsupportedMediaType = "Unsupported_Media_Type";
        public const string UnsupportedMethod = "Unsupported_Method";
        public const string RequestTooLarge = "Request_Too_Large";
        public const string TooManyRequests = "Too_Many_Requests";
    }
}
