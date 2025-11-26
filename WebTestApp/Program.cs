using MyCompany.MyModule;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Microsoft.EntityFrameworkCore;
using MyCompany.MyModule.EntityFrameworkCore;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;

var builder = WebApplication.CreateBuilder(args);

await builder.AddApplicationAsync<WebTestAppModule>();

var app = builder.Build();

await app.InitializeApplicationAsync();

await app.RunAsync();

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpAspNetCoreMvcModule),
    typeof(MyModuleApplicationModule),
    typeof(MyModuleEntityFrameworkCoreModule),
    typeof(MyModuleHttpApiModule),
    typeof(AbpAspNetCoreMvcUiBasicThemeModule)
)]
public class WebTestAppModule : AbpModule
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

        // Add MVC and Razor Pages support
        services.AddControllers();
        services.AddControllersWithViews();
        services.AddRazorPages();

        // Add Swagger for API documentation
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new() { Title = "MyCompany.MyModule API", Version = "v1" });
        });

        // Configure ABP theming
        Configure<AbpThemingOptions>(options =>
        {
            options.DefaultThemeName = BasicTheme.Name;
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // Enable static files
        app.UseStaticFiles();

        app.UseRouting();

        // Add authentication and authorization middleware
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            // Map Razor Pages (this will handle our login page and home page)
            endpoints.MapRazorPages();

            // Map MVC controllers
            endpoints.MapControllers();

            // Add default route for root path
            endpoints.MapGet("/", async context =>
            {
                context.Response.Redirect("/Account/Login");
            });
        });
    }
}
