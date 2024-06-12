using Microsoft.Extensions.Options;

namespace SignalRCallCenterWebApp.Models.Utilities;

public class EFOptionSetup(IConfiguration configuration) : IConfigureOptions<EFUtility>
{
  private readonly string _efOptionsSection = "EFOptions";
  private readonly IConfiguration _configuration = configuration;

  public void Configure(EFUtility utility)
  {
    _configuration.GetSection(_efOptionsSection).Bind(utility);
  }
}
