using System;
using System.Collections.Generic;

namespace Okapia.Domain.Models
{
    public partial class Page
    {
        public Page()
        {
            PageComments = new HashSet<PageComments>();
        }

        public int PageId { get; set; }
        public int PageCategoryId { get; set; }
        public string PageTittle { get; set; }
        public string PageSlug { get; set; }
        public string PageCategoryMetaTag { get; set; }
        public string PageCategoryMetaDesccription { get; set; }
        public string PageCategorySeohead { get; set; }
        public string PageCanonicalAddress { get; set; }
        public bool? PageCategoryIseDeleted { get; set; }
        public string PageCategoryRemoved301InsteadUrl { get; set; }
        public string PageSmallDescription { get; set; }
        public string PageContent { get; set; }
        public int RegisteringEmployeeId { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual PageCategory PageCategory { get; set; }
        public virtual ICollection<PageComments> PageComments { get; set; }
    }
}