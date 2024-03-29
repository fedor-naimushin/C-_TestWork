using UssJuniorTest.Core;
using UssJuniorTest.Core.Contracts;
using UssJuniorTest.Core.Models;
using UssJuniorTest.Infrastructure.Mapping;

namespace UssJuniorTest.Infrastructure.Services;

public class DriveInfoService : IDriveService
{
    private readonly IRepository<Car> cars;
    private readonly IRepository<Person> persons;
    private readonly IRepository<DriveLog> driveLogs;

    private readonly Mapper mapper;

    public DriveInfoService(
        IRepository<Car> cars,
        IRepository<Person> persons,
        IRepository<DriveLog> driveLogs,
        Mapper mapper)
    {
        this.cars = cars;
        this.persons = persons;
        this.driveLogs = driveLogs;
        this.mapper = mapper;
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
            Person = mapper.MapPerson(persons.Get(driveLog.CarId)),
            Car = mapper.MapCar(cars.Get(driveLog.CarId)),
            TimeTravel = driveLog.EndDateTime - driveLog.StartDateTime
        }).ToList();
    }
}