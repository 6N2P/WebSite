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
                        img="https://static-assets.tesla.com/configurator/compositor?context=design_studio_2&options=$MTS13,$PPSW,$WS91,$IBE00&view=FRONT34&model=ms&size=1920&bkba_opt=2&crop=0,0,0,0&",
                        price =45000,
                        isFavourite=true, 
                        available=true, 
                        Category = _categoryCars.AllCategories.First()},
                    new Car{name ="Ваз 2114",
                        shortDesc="Чёткий авто",
                        longDesc="Красивый, бомбический авто",
                        img="https://resizer.mail.ru/p/139d628b-b146-5ff1-a873-1ade38f754be/AQABEu09SufibWA1thDeFA1fAZi2iFEC-Q7nhjEECa9pthcgNLiM6oXoAdlAgBLEWY2KFHTminOB0iPljr6Aed0Fkpo.webp",
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
