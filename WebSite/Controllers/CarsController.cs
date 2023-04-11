using Microsoft.AspNetCore.Mvc;
using WebSite.interfaces;
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

        public ViewResult ListCar()
        {
              ViewBag.Tatel = "Хоть чё можно передать"; //при помощи viewBag можно передавать что угодно в представление
            //  var cars=_allCars.Cars;
            CarsListViweModel obj = new CarsListViweModel();
            obj.allCars=_allCars.Cars;
            obj.currCategory = "Автомобили";
            return View(obj);
        }
    }
}
