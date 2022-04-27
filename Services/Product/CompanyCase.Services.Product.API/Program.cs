using CompanyCase.Services.Product.API;
using CompanyCase.Services.Product.API.Dtos;
using CompanyCase.Services.Product.API.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;

            var categoryService = serviceProvider.GetRequiredService<ICategoryService>();

            if (!categoryService.GetAllAsync().Result.Data.Any())
            {
                categoryService.CreateAsync(new CategoryDto { Name = "Teknoloji" }).Wait();
                categoryService.CreateAsync(new CategoryDto { Name = "Giyim" }).Wait();
            }
        }

        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

}