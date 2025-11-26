
using Localization.Resources.AbpUi;
using MyCompany.MyModule.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.VirtualFileSystem;

namespace MyCompany.MyModule;

[DependsOn(
    typeof(MyModuleApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule),
    typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
public class MyModuleHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(MyModuleHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<MyModuleResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });

        // Add MVC and Razor Pages services
        context.Services.AddControllersWithViews();
        context.Services.AddRazorPages();

        // Configure Virtual File System to include embedded pages
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<MyModuleHttpApiModule>();
        });
    }
}
