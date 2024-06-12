using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SignalRCallCenterWebApp.Models;
using SignalRCallCenterWebApp.Models.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.ConfigureOptions<DbOptionSetup>();
builder.Services.ConfigureOptions<EFOptionSetup>();
builder.Services.AddDbContext<CallCenterDbContext>((serviceProvider, cfg) => {
  // GetService will return null if T not found
  //var dbUtility = serviceProvider.GetService<IOptions<DbUtility>>()!.Value;
  // GetRequiredService will throw exception if T not found
  var dbUtility = serviceProvider.GetRequiredService<IOptions<DbUtility>>().Value;
  var EFUtility = serviceProvider.GetRequiredService<IOptions<EFUtility>>().Value;
  var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

  logger.LogInformation($"----dbUtility.DbConnectionString: {dbUtility.DbConnectionString}----");

  cfg.UseSqlServer(dbUtility.DbConnectionString, sqlOptions => {
    sqlOptions.EnableRetryOnFailure(maxRetryCount: EFUtility.MaxReTryCount, maxRetryDelay: TimeSpan.FromSeconds(EFUtility.MaxReTryDelay), errorNumbersToAdd: null);
    sqlOptions.CommandTimeout(EFUtility.CommandTimeout);
  });
  cfg.EnableDetailedErrors(EFUtility.EnableDetailedErrors);
  cfg.EnableSensitiveDataLogging(EFUtility.EnableSensitiveDataLogging);
  if (EFUtility.EnableLogToConsole)
  {
    //cfg.LogTo(Console.WriteLine);
    cfg.LogTo(Console.WriteLine, LogLevel.Information);
  }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
