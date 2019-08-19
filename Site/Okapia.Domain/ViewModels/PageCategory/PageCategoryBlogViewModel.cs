using System;
using System.Collections.Generic;
using System.Text;
using Okapia.Domain.ViewModels.Page;

namespace Okapia.Domain.ViewModels.PageCategory
{
    public class PageCategoryBlogViewModel
    {
        public int PageCategoryId { get; set; }
        public string PageCategoryName { get; set; }
        public string PageCategorySlug { get; set; }
        public string PageCategoryMetaDescription { get; set; }
        public string PageCategoryCanonicalAddress { get; set; }
        public string PageCategoryMetaTags { get; set; }
        public List<string> MetaTags { get; set; }
        public List<PageItemViewModel> Pages { get; set; }
    }
}