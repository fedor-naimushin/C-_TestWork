using UssJuniorTest.Core;
using UssJuniorTest.Core.Contracts;
using UssJuniorTest.Core.Models;

namespace UssJuniorTest.Infrastructure.Services;

public class DriveInfoService : IDriveService
{
    private readonly IRepository<Car> cars;
    private readonly IRepository<Person> persons;
    private readonly IRepository<DriveLog> driveLogs;

    public DriveInfoService(
        IRepository<Car> cars,
        IRepository<Person> persons,
        IRepository<DriveLog> driveLogs)
    {
        this.cars = cars;
        this.persons = persons;
        this.driveLogs = driveLogs;
    }

    public List<DriveInfoResponse> GetDriveInfo(TimeRangeRequest request)
    {
        var needDriveLogs = driveLogs
            .GetAll()
            .Where(x =>
                x.StartDateTime >= request.Start && x.EndDateTime <= request.End ||
                request.Start <= x.EndDateTime && request.End >= x.EndDateTime ||
                request.End >= x.StartDateTime && request.Start <= x.StartDateTime
            )
            .ToList();

        return needDriveLogs.Select(driveLog => new DriveInfoResponse
        {
            Person = persons.Get(driveLog.PersonId),
            Car = cars.Get(driveLog.CarId),
            TimeTravel = driveLog.EndDateTime - driveLog.StartDateTime
        }).ToList();
    }
}