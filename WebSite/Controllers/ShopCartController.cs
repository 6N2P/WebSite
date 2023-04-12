﻿using Microsoft.AspNetCore.Mvc;
using WebSite.interfaces;
using WebSite.Models;
using WebSite.ViewModels;

namespace WebSite.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRep, ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModel
            {
                ShopCart = _shopCart
            };
            return View(obj);
        }
        //переадресация на другую страницу
        public RedirectToActionResult addToCart(int id)
        {
            var item = _carRep.Cars.FirstOrDefault(i => i.id == id);
            if (item!= null)
            {
                _shopCart.AddToCart(item);                
            }
            return RedirectToAction("Index");
        }
    }
}
