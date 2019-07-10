using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Commands.Category;
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

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(x => x.CategoryId == id).AsNoTracking().ToList().First();
        }

        public EditCategory GetCategoryDetails(int id)
        {
            var category = _context.Categories.Where(x => x.CategoryId == id).Select(x => new EditCategory
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                CategoryMetaDesccription = x.CategoryMetaDesccription,
                CategoryMetaTag = x.CategoryMetaTag,
                CategoryPageTittle = x.CategoryPageTittle,
                CategoryParentId = x.CategoryParentId,
                CategorySeohead = x.CategorySeohead,
                CategorySmallDescription = x.CategorySmallDescription,
                NameImage = x.CategoryThumbPicUrl,
                CategorySlug = x.CategorySlug,
                TitleImage = x.CategoryPicTitle,
                AltImage = x.CategoryPicAlt,
                DescImage = x.CategoryPicDescription,
                IsDeleted = x.IsDeleted
            }).ToList().First();
            return category;
        }

        public List<CategoryViewModel> GetCategories()
        {
            return _context.Categories.Where(x => x.IsDeleted == false).Select(x => new CategoryViewModel
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
            }).ToList();
        }

        public List<CategoryViewModel> Search(CategorySearchModel searchModel, out int recordCount)
        {
            var query = from category in _context.Categories
                select new CategoryViewModel
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    CategorySmallDescription = category.CategorySmallDescription,
                    CategoryParentId = category.CategoryParentId,
                    Photo = category.CategoryThumbPicUrl,
                    IsDeleted = category.IsDeleted
                };

            if (!string.IsNullOrEmpty(searchModel.CategoryName))
                query = query.Where(c => c.CategoryName.Contains(searchModel.CategoryName));
            if (searchModel.CategoryParrentId != 0)
                query = query.Where(c => c.CategoryParentId == searchModel.CategoryParrentId);
            query = query.Where(c => c.IsDeleted == searchModel.IsDeleted);

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