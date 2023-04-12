using WebSite.interfaces;
using WebSite.Models;

namespace WebSite.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDBContent _appDBcontent;
        public CategoryRepository(AppDBContent appDBContent)
        {
            _appDBcontent = appDBContent;
        }

        public IEnumerable<Category> AllCategories => _appDBcontent.Category;
    }
}
