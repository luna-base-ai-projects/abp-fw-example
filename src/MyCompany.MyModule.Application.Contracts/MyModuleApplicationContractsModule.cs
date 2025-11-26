using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace MyCompany.MyModule;

[DependsOn(
    typeof(MyModuleDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class MyModuleApplicationContractsModule : AbpModule
{

}
