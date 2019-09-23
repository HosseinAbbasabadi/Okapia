using System.Collections.Generic;
using Okapia.Domain.ViewModels.Job;

namespace Okapia.Domain.ViewModels.Category
{
    public class CategoryViewDetailsViewModel
    {
        public CategoryViewDetailsViewModel()
        {
            JobItems = new List<JobItemViewModel>();
        }

        public int CategoryId { get; set; }
        public string CatgoryName { get; set; }
        public string CategoryMetaTag { get; set; }
        public string CategoryMetaDesccription { get; set; }
        public string CategorySeohead { get; set; }
        public string CategoryCanonicalAddress { get; set; }
        public string CategoryPageTittle { get; set; }
        public string CategorySlug { get; set; }
        public string CategoryIcon { get; set; }
        public string CategoryColor { get; set; }
        public List<CategoryViewDetailsViewModel> Children { get; set; }
        public List<JobItemViewModel> JobItems { get; set; }
    }
}