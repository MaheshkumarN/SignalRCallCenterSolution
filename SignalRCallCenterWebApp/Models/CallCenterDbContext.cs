using Microsoft.EntityFrameworkCore;
using SignalRCallCenterWebApp.Models.Entities;

namespace SignalRCallCenterWebApp.Models;

public class CallCenterDbContext(DbContextOptions<CallCenterDbContext> dbContextOptions): DbContext(dbContextOptions)
{

    public DbSet<Call> Calls { get; set; }
}
