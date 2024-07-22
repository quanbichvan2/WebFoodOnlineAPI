using Domain.Persistence.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnlineFood.Components;
using OnlineFood.Repository.Repositories;
using OnlineFood.UseCase.Contracts.Repositories;
using System;
using UseCase.Contracts.Services;
using UseCase.Models.Product;
using UseCase.Services;

namespace OnlineFood
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddDbContext<ApplicationDbContext>(x => 
                    {x.UseSqlServer(builder.Configuration.GetConnectionString("Test"));
                    });


            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IValidator<CreateProductDto>, CreateProductDtoValidator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            

            app.UseHttpsRedirection();

            
            app.UseAuthentication(); // xác định danh tính -> login và logout
            app.UseAuthorization(); // xác thực quyền truy cập
            
            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
