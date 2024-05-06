
using Domain.Responses.Api;
using Serilog;
using System.Text.Json;

namespace Api.Middlewares
{
    public class GlobalExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
			catch (Exception e)
			{
				Log.Error(e.Message);
				ApiResponse<object> response = new ApiResponse<object>();	
				response.Success = false;
				response.ErrorMessage = e.Message;
				response.TimeStamps = DateTime.UtcNow;
				
				await context.Response.WriteAsync(JsonSerializer.Serialize(response));
			}
        }
    }
}
