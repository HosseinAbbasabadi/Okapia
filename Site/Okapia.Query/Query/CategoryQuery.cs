using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.ViewModels.Category;

namespace Okapia.Query.Query
{
    public class CategoryQuery : BaseViewRepository<int, Category>, ICategoryQuery
    {
        public CategoryQuery(OkapiaViewContext context) : base(context)
        {
        }
        
        public List<CategoryViewModel> GetCategoriesForSearch()
        {
            return _context.Categories.Where(x => x.CategoryParentId != 0).Select(category => new CategoryViewModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
            }).ToList();
        }

        public List<CategoryMenuViewModel> GetCategoriesForMenu()
        {
            return _context.Categories.Where(x => x.CategoryParentId == 0).Include(x => x.Childs).Select(category =>
                new CategoryMenuViewModel
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    CategoryChilds = MapToCategoryMenuViewModels(category.Childs),
                    Photo = category.CategoryThumbPicUrl,
                    PhotoAlt = category.CategoryPicAlt
                }).ToList();
        }


        private static List<CategoryMenuViewModel> MapToCategoryMenuViewModels(IEnumerable<Category> categories)
        {
            return categories.Select(MapToCategoryMenuViewModel).ToList();
        }

        private static CategoryMenuViewModel MapToCategoryMenuViewModel(Category category)
        {
            return new CategoryMenuViewModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }
    }
}