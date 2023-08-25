using GetTicket.Business.CustomExceptions;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace WebAPI.MiddleWares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException (this IApplicationBuilder app)
        {
            app.UseExceptionHandler(configure =>
            {
                configure.Run(async context =>
                {
                    var exceptionFeature =   context.Features.Get<IExceptionHandlerFeature>();
                    var exception = exceptionFeature.Error;

                    context.Response.ContentType = "application/json";

                    var statusCode = StatusCodes.Status500InternalServerError;

                    switch (exception)
                    {
                        case BadRequestException:
                            statusCode = StatusCodes.Status400BadRequest;
                            break;
                        case NotFoundException:
                            statusCode = StatusCodes.Status404NotFound;
                            break;
                        case ConflictException:
                            statusCode = StatusCodes.Status409Conflict;
                            break;
                        default:
                            break;

                    }

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = statusCode;

                    var response = ApiResponse<NoData>.Fail(statusCode, exception.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
;                });
            });
        }
    }
}
