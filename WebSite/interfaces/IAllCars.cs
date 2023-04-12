using WebSite.Models;

namespace WebSite.interfaces
{
    public interface IAllCars
    {
       public IEnumerable<Car> Cars { get;}
       public IEnumerable<Car> GetFavCars { get;}
       public Car GetObgectCar(int carId);
    }
}
