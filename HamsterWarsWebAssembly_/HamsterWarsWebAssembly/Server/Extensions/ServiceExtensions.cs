using HamsterWarsWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace HamsterWarsWebAssembly.Server.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(error => 
            {
                    error.Run(async context => 
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";
                        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (contextFeature != null)
                        {
                            await context.Response.WriteAsync(new Error()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = "Internal server error. Hahaha"
                            }.ToString());
                        }

                    });
            });
        }
    }
}
