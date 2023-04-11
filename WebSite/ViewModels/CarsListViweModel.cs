using WebSite.Models;

namespace WebSite.ViewModels
{
    public class CarsListViweModel
    {
        public IEnumerable<Car> allCars { get; set; }
        public string currCategory { get; set; }
    }
}
