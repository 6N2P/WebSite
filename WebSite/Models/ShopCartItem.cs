namespace WebSite.Models
{
    //Клас для карзины
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Car car { get; set; }
        public int prace { get; set; }
        public string ShopCartId { get; set; }
    }
}
