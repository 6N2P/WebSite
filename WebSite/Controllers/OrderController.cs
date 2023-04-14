using Microsoft.AspNetCore.Mvc;
using WebSite.Data;
using WebSite.interfaces;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }
        //чтоб можно было принемать данные
        public IActionResult checkout()
        {
            return View();
        }
    }
}
