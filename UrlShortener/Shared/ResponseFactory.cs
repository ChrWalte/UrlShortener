using System;
using UrlShortener.Models;

namespace UrlShortener.Shared
{
    public static class ResponseFactory
    {
        public static Response InitializeResponse(string status, string message, object value)
            => new Response
            {
                Status = status,
                Message = message,
                Value = value
            };

        public static Response InitializeResponseSuccess(string message, object value)
            => InitializeResponse("Success", message, value);

        public static Response InitializeResponseFailed(string message, object value)
            => InitializeResponse("Failed", message, value);

        public static Response InitializeResponseError(string message, Exception ex, object value)
            => InitializeResponse("Error", $"Message: {message}, Error: {ex}", value);
    }
}