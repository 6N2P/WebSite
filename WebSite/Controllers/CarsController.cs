using Microsoft.AspNetCore.Mvc;
using WebSite.interfaces;
using WebSite.Models;
using WebSite.ViewModels;

namespace WebSite.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat)
        {
            _allCars = iAllCars;
            _allCategories = iCarsCat;
        }
        [Route("Cars/ListCar")]
        [Route("Cars/ListCar/{category}")]
        public ViewResult ListCar(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(_category))
            {
                cars = _allCars.Cars.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Электромобили")).
                        OrderBy(i => i.id);
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Класические автомобили")).
                        OrderBy(i => i.id);
                }
                currCategory = _category;                              
            }
            var carObj = new CarsListViweModel
            {
                allCars = cars,
                currCategory = currCategory
            };
            ViewBag.Tatel = "Хоть чё можно передать"; //при помощи viewBag можно передавать что угодно в представление
            //  var cars=_allCars.Cars;
           
            return View(carObj);
        }
    }
}
