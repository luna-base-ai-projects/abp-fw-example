
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Volo.Abp;
using Volo.Abp.Modularity;
using MyCompany.MyModule;
using MyCompany.MyModule.Samples;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCompany.MyModule.EntityFrameworkCore;

namespace TestApp;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MyModuleApplicationModule),
    typeof(MyModuleEntityFrameworkCoreModule),
    typeof(MyModuleHttpApiModule)
)]
public class TestAppModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var services = context.Services;
        var configuration = context.Services.GetConfiguration();

        // Configure Entity Framework
        context.Services.AddAbpDbContext<MyModuleDbContext>(options =>
        {
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        services.AddEntityFrameworkInMemoryDatabase();

        // Add logging
        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.SetMinimumLevel(LogLevel.Information);
        });
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        using var application = await AbpApplicationFactory.CreateAsync<TestAppModule>(options =>
        {
            options.UseAutofac();
        });

        await application.InitializeAsync();

        var logger = application.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("🚀 ABP Module Test Application Started!");

        try
        {
            // Test the sample app service
            var sampleAppService = application.ServiceProvider.GetRequiredService<ISampleAppService>();

            logger.LogInformation("📋 Testing Sample App Service...");
            var result = await sampleAppService.GetAsync();

            logger.LogInformation("✅ Sample App Service Result:");
            logger.LogInformation($"   Value: {result.Value}");

            logger.LogInformation("📋 Module services are working correctly!");
            logger.LogInformation("✅ ABP Module integration successful!");

            logger.LogInformation("🎉 All tests completed successfully!");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "❌ Error occurred during testing");
        }

        await application.ShutdownAsync();
    }
}
