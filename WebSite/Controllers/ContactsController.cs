using Microsoft.AspNetCore.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Check(Contact contact)
        {
            if (ModelState.IsValid)
            {
                //Переадресация на главную страницу
                return Redirect("/");
            }
            return View("Index");
        }
    }
}
