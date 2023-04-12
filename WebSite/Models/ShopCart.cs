using Microsoft.EntityFrameworkCore;
using WebSite.Data;

namespace WebSite.Models
{
    /// <summary>
    /// Клас карзины
    /// </summary>
    public class ShopCart
    {
        private readonly AppDBContent _appDBContent;
        public ShopCart(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }

        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }


        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDBContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId};
        }
        public void AddToCart(Car car)
        {
            this._appDBContent.ShopCartItems.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                car = car,
                prace = car.price
            });
            _appDBContent.SaveChanges();
        }
        public List<ShopCartItem> getShopItems()
        {
            return _appDBContent.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).
                Include(s => s.car).ToList();
        }
    }
}
