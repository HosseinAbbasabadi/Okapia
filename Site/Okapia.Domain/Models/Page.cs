using System;
using System.Collections.Generic;

namespace Okapia.Domain.Models
{
    public class Page
    {
        public long PageId { get; set; }
        public int PageCategoryId { get; set; }
        public string PageTittle { get; set; }
        public string PageSlug { get; set; }
        public string PageMetaTag { get; set; }
        public string PageMetaDesccription { get; set; }
        public string PageSeohead { get; set; }
        public string PageCanonicalAddress { get; set; }
        public bool PageIsDeleted { get; set; }
        public string PageRemoved301InsteadUrl { get; set; }
        public string PageSmallDescription { get; set; }
        public string PageContent { get; set; }
        public long PageRegisteringEmployeeId { get; set; }
        public DateTime PageRegistrationDate { get; set; }
        public DateTime PagePublishDate { get; set; }
        
        public PageCategory PageCategory { get; set; }
        public ICollection<Comments> PageComments { get; set; }
    }
}