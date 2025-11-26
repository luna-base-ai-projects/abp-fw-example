using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace MyCompany.MyModule;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class MyModuleInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<MyModuleInstallerModule>();
        });
    }
}
