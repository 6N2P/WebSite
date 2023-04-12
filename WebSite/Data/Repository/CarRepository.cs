using Microsoft.EntityFrameworkCore;
using WebSite.interfaces;
using WebSite.Models;

namespace WebSite.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContent _appDBcontent;
        public CarRepository (AppDBContent appDBContent)
        {
            _appDBcontent = appDBContent;
        }
        public IEnumerable<Car> Cars => _appDBcontent.Car.Include(c=>c.Category);

        public IEnumerable<Car> GetFavCars=> _appDBcontent.Car.Where(p=>p.isFavourite).Include(c=>c.Category) ;

        public Car GetObgectCar(int carId) => _appDBcontent.Car.FirstOrDefault(p => p.id == carId);
        
    }
}
