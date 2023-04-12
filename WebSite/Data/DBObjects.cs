using Microsoft.Extensions.DependencyInjection;
using WebSite.Models;

namespace WebSite.Data
{
    public class DBObjects
    {
        DBObjects() { }
        /// <summary>
        /// Для добовления и вытягивания объектов из БД
        /// </summary>
        /// <param name="content"></param>
        public static void Initial(AppDBContent content)
        {
           
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Car.Any())
            {
                content.AddRange(
                    new Car
                    {
                        name = "Tesla MOdel s",
                        shortDesc = "Быстрый авто",
                        longDesc = "Красивый, быстрый авто",
                        img = "/img/tesla-roadster_large.jpg",
                        price = 45000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        name = "Ваз 2114",
                        shortDesc = "Чёткий авто",
                        longDesc = "Красивый, бомбический авто",
                        img = "/img/lada_2114_1.jpg",
                        price = 500,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Класические автомобили"]
                    });
            }
            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string,Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                    new Category{categoryName = "Электромобили", desc ="Автомобили с электрическим двигателем"},
                    new Category{categoryName="Класические автомобили", desc="Машины с двигателем внетреннего сгорания"}
                    };
                    category = new Dictionary<string,Category>();
                    foreach(Category c in list)
                    {
                        category.Add(c.categoryName, c);
                    }
                }
                return category;
            }
        }
    }
}
