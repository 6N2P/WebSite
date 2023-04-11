using Microsoft.AspNetCore.Mvc;
using WebSite.interfaces;

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

        public ViewResult ListCar()
        {
            ViewBag.Category = "Хоть чё"; //при помощи viewBag можно передавать что угодно в представление
            var cars=_allCars.Cars;
            return View(cars);
        }
    }
}
