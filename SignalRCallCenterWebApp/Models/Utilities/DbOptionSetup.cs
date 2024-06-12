using Microsoft.Extensions.Options;

namespace SignalRCallCenterWebApp.Models.Utilities;

public class DbOptionSetup(IConfiguration configuration) : IConfigureOptions<DbUtility>
{
  private readonly IConfiguration _configuration = configuration;

  public void Configure(DbUtility utility)
  {
    utility.DbConnectionString = _configuration.GetConnectionString("CallCenterConnectionString");
  }
}
