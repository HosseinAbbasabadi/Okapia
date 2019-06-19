using System;
using System.Collections.Generic;

namespace Okapia.Areas.Administrator.Models
{
    public class PageCategory
    {
        public PageCategory()
        {
            InversePageCategoryParent = new HashSet<PageCategory>();
            Page = new HashSet<Page>();
        }

        public int PageCategoryId { get; set; }
        public string PageCategoryName { get; set; }
        public string PageCategorySmallPictutre { get; set; }
        public string PageCategorySmallPictutreAlt { get; set; }
        public string PageCategoryPageTittle { get; set; }
        public string PageCategorySlug { get; set; }
        public string PageCategoryMetaTag { get; set; }
        public string PageCategoryMetaDesccription { get; set; }
        public string PageCategorySeohead { get; set; }
        public string PageCanonicalAddress { get; set; }
        public bool? PageCategoryIsDeleted { get; set; }
        public string PageCategoryRemoved301InsteadUrl { get; set; }
        public int? PageCategoryParentId { get; set; }
        public string PageCategoryLinkToolTip { get; set; }
        public int? PageCategoryShowOrder { get; set; }
        public int PageCategoryRegisteredByEmployeId { get; set; }
        public DateTime PageCategoryRegisterDate { get; set; }

        public virtual PageCategory PageCategoryParent { get; set; }
        public virtual ICollection<PageCategory> InversePageCategoryParent { get; set; }
        public virtual ICollection<Page> Page { get; set; }
    }
}