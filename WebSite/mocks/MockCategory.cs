using WebSite.interfaces;
using WebSite.Models;

namespace WebSite.mocks
{
    /// <summary>
    /// Клас для работы с категориями
    /// </summary>
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category{categoryName = "Электромобили", desc ="Автомобили с электрическим двигателем"},
                    new Category{categoryName="Класические автомобили", desc="Машины с двигателем внетреннего сгорания"}
                };
            }
        }
    }
}
