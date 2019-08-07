using System;
using System.Collections.Generic;

namespace Okapia.Domain.Models
{
    public class PageCategory
    {
        public int PageCategoryId { get; set; }
        public string PageCategoryName { get; set; }
        public string PageCategorySmallPictutre { get; set; }
        public string PageCategorySmallPictutreTitle { get; set; }
        public string PageCategorySmallPictutreAlt { get; set; }
        public string PageCategorySmallPictutreDescription { get; set; }
        public string PageCategoryPageTittle { get; set; }
        public string PageCategorySlug { get; set; }
        public string PageCategoryMetaTag { get; set; }
        public string PageCategoryMetaDesccription { get; set; }
        public string PageCategorySeohead { get; set; }
        public string PageCanonicalAddress { get; set; }
        public bool PageCategoryIsDeleted { get; set; }
        public string PageCategoryRemoved301InsteadUrl { get; set; }
        public int PageCategoryParentId { get; set; }
        public int PageCategoryShowOrder { get; set; }
        public long PageCategoryRegisteringEmployeId { get; set; }
        public DateTime PageCategoryRegistrationDate { get; set; }

        public virtual PageCategory PageCategoryParent { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
    }
}