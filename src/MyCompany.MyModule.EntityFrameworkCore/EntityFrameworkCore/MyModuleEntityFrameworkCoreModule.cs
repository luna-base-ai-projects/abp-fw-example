using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MyCompany.MyModule.EntityFrameworkCore;

[DependsOn(
    typeof(MyModuleDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class MyModuleEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<MyModuleDbContext>(options =>
        {
            options.AddDefaultRepositories<IMyModuleDbContext>(includeAllEntities: true);
            
            /* Add custom repositories here. Example:
            * options.AddRepository<Question, EfCoreQuestionRepository>();
            */
        });
    }
}
