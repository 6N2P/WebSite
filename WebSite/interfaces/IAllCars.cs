using WebSite.Models;

namespace WebSite.interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get;  }
        IEnumerable<Car> GetFavCars { get; set; }
        Car GetObgectCar(int carId);
    }
}
