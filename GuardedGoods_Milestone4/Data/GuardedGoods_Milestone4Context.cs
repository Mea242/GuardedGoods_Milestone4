using Microsoft.EntityFrameworkCore;

public class GuardedGoods_Milestone4Context(DbContextOptions<GuardedGoods_Milestone4Context> options) : DbContext(options)
{
    public DbSet<GuardedGoods_Milestone4.Model.users> users { get; set; } = default!;
    public DbSet<GuardedGoods_Milestone4.Model.sellers> sellers { get; set; } = default!;
}
