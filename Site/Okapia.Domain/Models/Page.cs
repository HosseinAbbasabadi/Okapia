using System;
using System.Collections.Generic;

namespace Okapia.Domain
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
        public string PageMetaTag { get; set; }
        public string PageMetaDesccription { get; set; }
        public string PageSeohead { get; set; }
        public string PageCanonicalAddress { get; set; }
        public bool? PageIsDeleted { get; set; }
        public string PageRemoved301InsteadUrl { get; set; }
        public string PageSmallDescription { get; set; }
        public string PageContent { get; set; }
        public int PageRegisteringEmployeeId { get; set; }
        public DateTime PageRegistrationDate { get; set; }

        public virtual PageCategory PageCategory { get; set; }
        public virtual ICollection<PageComments> PageComments { get; set; }
    }
}