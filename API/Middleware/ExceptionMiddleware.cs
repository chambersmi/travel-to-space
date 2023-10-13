using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        public RequestDelegate _next { get; }
        private readonly ILogger<ExceptionMiddleware> _logger;
        public IHostEnvironment _env { get; }

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;            
        }

        
        public async Task InvokeAsync(HttpContext context) {
            try {
                await _next(context); // If there's no exception, move on
            } 
            catch (Exception ex) 
            {
                _logger.LogError(ex, ex.Message); // Output into logging system (console)
                _logger.LogError("THERE IS AN ISSUE HERE!!!!!!!!!!!!");
                context.Response.ContentType = "application/json";  // sent as json format
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // set the status code to be a 500

                var response = _env.IsDevelopment() 
                ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString()) 
                : new ApiException((int)HttpStatusCode.InternalServerError);

                // Create options for camelCase
                var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

                var json = JsonSerializer.Serialize(response, options); // Serialize into JSON format

                await context.Response.WriteAsync(json);
            }
        }
    }
}