using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.ViewModels.Category;
using Okapia.Domain.ViewModels.Job;

namespace Okapia.Query.Query
{
    public class CategoryQuery : BaseViewRepository<int, Category>, ICategoryQuery
    {
        private readonly IJobQuery _jobQuery;

        public CategoryQuery(OkapiaViewContext context, IJobQuery jobQuery) : base(context)
        {
            _jobQuery = jobQuery;
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
                    PhotoAlt = category.CategoryPicAlt,
                    Color = category.CategoryColor,
                    Icon = category.CategoryIcon,
                    IsNew = category.CategoryIsNew
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
                CategoryName = category.CategoryName,
                CategorySlug = category.CategorySlug
            };
        }

        public CategoryViewDetailsViewModel GetCategoryViewDetails(int id)
        {
            var childrenCategories = GetChildrenOfCategory(id);

            var selectedCategory = _context.Categories.Include(x => x.Jobs).ThenInclude(x => x.JobPictures)
                .Where(x => x.CategoryId == id).Select(cat =>
                    new CategoryViewDetailsViewModel
                    {
                        CategoryId = cat.CategoryId,
                        CategorySlug = cat.CategorySlug,
                        CategoryCanonicalAddress = cat.CategoryCanonicalAddress,
                        CategoryMetaDesccription = cat.CategoryMetaDesccription,
                        CategoryMetaTag = cat.CategoryMetaTag,
                        CategoryPageTittle = cat.CategoryPageTittle,
                        CategorySeohead = cat.CategorySeohead,
                        CatgoryName = cat.CategoryName,
                        CategoryIcon = cat.CategoryIcon,
                        CategoryColor = cat.CategoryColor,
                        Children = childrenCategories
                    }).FirstOrDefault();

            if (selectedCategory == null) return new CategoryViewDetailsViewModel();

            var mainCategoryJobs = GetJobsForSpecificCategory(id);
            selectedCategory?.JobItems.AddRange(mainCategoryJobs);
            foreach (var child in childrenCategories)
            {
                var jobs = GetJobsForSpecificCategory(child.CategoryId);
                selectedCategory.JobItems.AddRange(jobs);
            }

            return selectedCategory;
        }

        public List<CategoryViewDetailsViewModel> GetChildrenOfCategory(int categoryId)
        {
            return _context.Categories.Where(x => x.CategoryParentId == categoryId)
                .Select(cat => new CategoryViewDetailsViewModel
                    {
                        CategoryId = cat.CategoryId,
                        CatgoryName = cat.CategoryName,
                    }
                ).ToList();
        }

        private IEnumerable<JobItemViewModel> GetJobsForSpecificCategory(int id)
        {
            return _context.Jobs.Where(x => x.JobCategory == id).Include(x => x.JobPictures)
                .Join(_context.Provinces, job => job.JobProvienceId, province => province.Id,
                    (job, province) => new {job, province})
                .Join(
                    _context.Cities, job => job.job.JobCityId, city => city.Id, (job, city) => new JobItemViewModel
                    {
                        JobName = job.job.JobName,
                        JobId = job.job.JobId,
                        JobSlug = job.job.JobSlug,
                        JobPicture = job.job.JobPictures.FirstOrDefault().JobPictureName,
                        JobPictureAlt = job.job.JobPictures.FirstOrDefault().JobPictureAlt,
                        JobPictureTitle = job.job.JobPictures.FirstOrDefault().JobPictureTitle,
                        JobPrice = job.job.JobPrice,
                        JobDiscountPrice = job.job.JobDiscountPrice,
                        Province = job.province.Name,
                        City = city.Name,
                        BenefitPercentForEndCustomer = job.job.JobBenefitPercentForEndCustomer
                    }).ToList();
        }

        private List<JobItemViewModel> MapJobs(IEnumerable<Job> jobs)
        {
            return jobs.Select(MapJob).ToList();
        }

        private JobItemViewModel MapJob(Job job)
        {
            var cityName = _context.Cities.FirstOrDefault(x => x.Id == job.JobCityId)?.Name;
            return new JobItemViewModel
            {
                JobName = job.JobName,
                JobId = job.JobId,
                JobSlug = job.JobSlug,
                JobPicture = job.JobPictures.FirstOrDefault()?.JobPictureName,
                JobPictureAlt = job.JobPictures.FirstOrDefault()?.JobPictureAlt,
                JobPictureTitle = job.JobPictures.FirstOrDefault()?.JobPictureTitle,
                JobPrice = job.JobPrice,
                City = cityName,
                BenefitPercentForEndCustomer = job.JobBenefitPercentForEndCustomer
            };
        }
    }
}