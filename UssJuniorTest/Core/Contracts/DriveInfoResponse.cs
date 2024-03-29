using UssJuniorTest.Core.Models;

namespace UssJuniorTest.Core.Contracts;

public class DriveInfoResponse
{
    public PersonResponse Person { get; set; }
    public CarResponse Car { get; set; }
    public string TimeTravel { get; set; }
}