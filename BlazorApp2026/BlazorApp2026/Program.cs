using Blazor26.DataAccess.DataAccess;
using Blazor26.Services;
using Blazor26.Services.BusinessModels;
using BlazorApp2026.Components;

using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;
using Syncfusion.Licensing;

namespace BlazorApp2026
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JHaF1cXmhMYVB3WmFZfVhgdV9FYFZUR2Y/P1ZhSXxVdkBjWH5dc3RQQWleU0d9XEE=");
            
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();
            
            builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IFileMgt, FileMgt>();
            builder.Services.AddLocalization();
            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddSingleton<MLService>();
            
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var mlService = scope.ServiceProvider.GetRequiredService<MLService>();
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var sales = await unitOfWork.SalesRepo.ListOfSalesDataAsync();

                if (sales.Any())
                {
                    var data = sales.Select(s => new SalesData
                    {
                        // s.MonthName was stored as a literal string of the month, so we need a
                        // switch here to convert it back into a number...
                        Month = s.MonthName switch
                        {
                            "January" => 1,
                            "February" => 2,
                            "March" => 3,
                            "April" => 4,
                            "May" => 5,
                            "June" => 6,
                            "July" => 7,
                            "August" => 8,
                            "September" => 9,
                            "October" => 10,
                            "November" => 11,
                            "December" => 12,
                            _ => 0
                        },
                        SalesAmount = (float)s.SalesAmount,
                    });
                    
                    mlService.Train(data);
                    
                    Console.WriteLine("Model trained at startup");
                }
                else
                {
                    Console.WriteLine("No date available for training");
                }
            }
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.Run();
        }
    }
}
