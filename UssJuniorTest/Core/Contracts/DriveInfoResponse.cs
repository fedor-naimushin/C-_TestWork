using UssJuniorTest.Core.Models;

namespace UssJuniorTest.Core.Contracts;

public class DriveInfoResponse
{
    public Person Person { get; set; }
    public Car Car { get; set; }
    public TimeSpan TimeTravel { get; set; }
}