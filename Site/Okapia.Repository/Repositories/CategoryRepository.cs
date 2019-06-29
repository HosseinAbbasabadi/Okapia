using System.Collections.Generic;
using System.Linq;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Category;

namespace Okapia.Repository.Repositories
{
    public class CategoryRepository : BaseRepository<int, Category>, ICategoryRepository
    {
        private readonly OkapiaContext _context;

        public CategoryRepository(OkapiaContext context) : base(context)
        {
            _context = context;
        }

        public List<CategoryViewModel> GetCategories()
        {
            return _context.Categories.Select(x => new CategoryViewModel
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
            }).ToList();
        }

        public List<CategoryViewModel> Search(CategorySearchModel searchModel, out int recordCount)
        {
            //var query = _context.Categories.Select(x => new CategoryViewModel
            //{
            //    CategoryId = x.CategoryId,
            //    CategoryName = x.CategoryName,
            //    CategorySmallDescription = x.CategorySmallDescription,
            //    CategoryParentId = x.CategoryParentId
            //});
            var query = from category in _context.Categories
                select new CategoryViewModel
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    CategorySmallDescription = category.CategorySmallDescription,
                    CategoryParentId = category.CategoryParentId
                };

            if (!string.IsNullOrEmpty(searchModel.CategoryName))
                query = query.Where(c => c.CategoryName == searchModel.CategoryName);
            if (searchModel.CategoryParrentId != 0)
                query = query.Where(c => c.CategoryParentId == searchModel.CategoryParrentId);

            recordCount = query.Count();
            var result = query.OrderByDescending(x => x.CategoryId).Skip(searchModel.PageIndex * searchModel.PageSize)
                .Take(searchModel.PageSize);

            //foreach (var category in result)
            //{
            //    var parrentCategoryName = query.First(x => x.CategoryId == category.CategoryParentId).CategoryName;
            //    category.CategoryParentName = parrentCategoryName;
            //}

            return result.ToList();
        }
    }
}