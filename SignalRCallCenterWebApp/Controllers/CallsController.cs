using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalRCallCenterWebApp.Models;

namespace SignalRCallCenterWebApp.Controllers;

[ApiController]
[Route("api/calls")]
public class CallsController(CallCenterDbContext context) : ControllerBase
{
  private readonly CallCenterDbContext _context = context;

  [HttpGet]
  public async Task<IActionResult> Get()
  {
    var calls = await _context.Calls.ToListAsync();
    return Ok(calls);
  }

  //[HttpDelete]
  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    try
    {
      var call = await _context.Calls.Where(c => c.Id == id).FirstOrDefaultAsync();
      if (call == null)
      {
        return BadRequest();
      }
      else
      {
        _context.Remove(call);
        if (await _context.SaveChangesAsync() > 0)
        {
          return Ok(new { success = true });
        }
        else
        {
          return BadRequest("Database Error");
        }
      }
    }
    catch (Exception)
    {
      return StatusCode(500);
    }
  }
}