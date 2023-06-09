﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
        public IActionResult checkout(Order order)
        {
            shopCart.listShopItems = shopCart.getShopItems();

            if(shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары");
            }

            if(ModelState.IsValid)
            {
                allOrders.createOrder(order);

                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
