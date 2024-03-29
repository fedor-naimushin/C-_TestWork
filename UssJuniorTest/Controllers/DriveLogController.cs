using Microsoft.AspNetCore.Mvc;
using UssJuniorTest.Core;
using UssJuniorTest.Core.Contracts;

namespace UssJuniorTest.Controllers;

[ApiController]
[Route("api/driveLog")]
public class DriveLogController : Controller
{
    private readonly IDriveService driveService;
    
    public DriveLogController(IDriveService driveService)
    {
        this.driveService = driveService;
    }
    
    
    [HttpGet]
    public IActionResult GetDriveLogsAggregation([FromQuery] TimeRangeRequest request)
    {
        var response = driveService.GetDriveInfo(request);
        
        if (response.Count == 0)
            return NotFound();

        return Ok(response);
    }
}