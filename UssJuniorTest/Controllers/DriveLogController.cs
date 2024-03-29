using Microsoft.AspNetCore.Mvc;
using UssJuniorTest.Core.Contracts;

namespace UssJuniorTest.Controllers;

[ApiController]
[Route("api/driveLog")]
public class DriveLogController : Controller
{
    public DriveLogController()
    {
        
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetDriveLogsAggregation([FromQuery] TimeRangeRequest timeRange)
    {
        return Ok($"Start: {timeRange.Start}. End: {timeRange.End}");
    }
}