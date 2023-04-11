using WebSite.interfaces;
using WebSite.Models;

namespace WebSite.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars 
        {
            get
            {
                return new List<Car>
                {
                    new Car{name = "Tesla MOdel s", 
                        shortDesc="Быстрый авто",
                        longDesc="Красивый, быстрый авто",
                        img="/img/tesla-roadster_large.jpg",
                        price =45000,
                        isFavourite=true, 
                        available=true, 
                        Category = _categoryCars.AllCategories.First()},
                    new Car{name ="Ваз 2114",
                        shortDesc="Чёткий авто",
                        longDesc="Красивый, бомбический авто",
                        img="/img/lada_2114_1.jpg",
                        price=500,
                        isFavourite=true,
                        available=true,
                        Category= _categoryCars.AllCategories.Last()
                    }
                };
            }
        }
        public IEnumerable<Car> GetFavCars { get; set ; }

        public Car GetObgectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
