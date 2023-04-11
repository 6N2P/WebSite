using WebSite.Models;

namespace WebSite.interfaces
{
    public interface ICarsCategory
    {
      public  IEnumerable<Category> AllCategories { get; }
    }
}
