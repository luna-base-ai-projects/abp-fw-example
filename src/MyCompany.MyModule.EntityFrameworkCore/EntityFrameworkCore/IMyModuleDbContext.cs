using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace MyCompany.MyModule.EntityFrameworkCore;

[ConnectionStringName(MyModuleDbProperties.ConnectionStringName)]
public interface IMyModuleDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
