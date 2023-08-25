using GetTicket.Business.Abstract;
using GetTicket.Business.Concrete;
using GetTicket.Business.Extensions;
using GetTicket.DataAccess.Implementations.EF.Contexts;
using GetTicket.DataAccess.Implementations.Repositories;
using GetTicket.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebAPI.Extensions;
using WebAPI.MiddleWares;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddBusinessServices();

            builder.Services.APIServices(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();
            
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            app.UseCustomException();
            app.Run();
        }
    }
}