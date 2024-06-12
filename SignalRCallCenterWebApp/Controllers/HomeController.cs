using Microsoft.AspNetCore.Mvc;
using SignalRCallCenterWebApp.Models;
using SignalRCallCenterWebApp.Models.Entities;
using System.Diagnostics;

namespace SignalRCallCenterWebApp.Controllers
{
  public class HomeController(CallCenterDbContext dbContext, ILogger<HomeController> logger) : Controller
  {
    private readonly CallCenterDbContext _dbContext = dbContext;
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Index()
    {
      ViewBag.Message = "";
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(Call model)
    {
      try
      {
        if (ModelState.IsValid)
        {
          _dbContext.Add(model);
          if (await _dbContext.SaveChangesAsync() > 0)
          {
            ViewBag.Message = "Problem reported...";
            ModelState.Clear();
          }
          else
          {
            ViewBag.Message = "Failed to save the new problem...";
          }
        }
      }
      catch (Exception)
      {
        ViewBag.Message = "Threw exception trying to save call.";
      }
      return View();
    }

    public IActionResult Calls() => View();

    public IActionResult Privacy()
    {
      
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
