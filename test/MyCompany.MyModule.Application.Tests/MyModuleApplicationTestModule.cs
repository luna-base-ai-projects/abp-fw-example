using Volo.Abp.Modularity;

namespace MyCompany.MyModule;

[DependsOn(
    typeof(MyModuleApplicationModule),
    typeof(MyModuleDomainTestModule)
    )]
public class MyModuleApplicationTestModule : AbpModule
{

}
