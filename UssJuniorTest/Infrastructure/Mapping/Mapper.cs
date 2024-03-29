using UssJuniorTest.Core.Contracts;
using UssJuniorTest.Core.Models;

namespace UssJuniorTest.Infrastructure.Mapping;

public class Mapper
{
    public PersonResponse MapPerson(Person person)
    {
        return new PersonResponse
        {
            Name = person.Name,
            Age = person.Age
        };
    }

    public CarResponse MapCar(Car car)
    {
        return new CarResponse
        {
            Manufacturer = car.Manufacturer,
            Model = car.Model
        };
    }
}