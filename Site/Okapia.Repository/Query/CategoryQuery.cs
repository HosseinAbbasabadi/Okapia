using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.ViewModels.Category;
using Okapia.Repository.Repositories;

namespace Okapia.Repository.Query
{
    public class CategoryQuery : BaseViewRepository<int, Category>, ICategoryQuery
    {
        public CategoryQuery(OkapiaViewContext context) : base(context)
        {
        }


        public List<CategoryMenuViewModel> GetCategoriesForMenu()
        {
            var categories = _context.Categories.Include(x => x.Childs).ToList();
            return null;
        }
    }
}