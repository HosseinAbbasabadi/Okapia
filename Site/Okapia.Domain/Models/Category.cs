using System.Collections.Generic;

namespace Okapia.Domain.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategorySmallDescription { get; set; }
        public string CategorySlug { get; set; }
        public string CategoryMetaTag { get; set; }
        public string CategoryMetaDesccription { get; set; }
        public string CategorySeohead { get; set; }
        public string CategoryCanonicalAddress { get; set; }
        public string CategoryPageTittle { get; set; }
        public string CategoryThumbPicUrl { get; set; }
        public string CategoryPicTitle { get; set; }
        public string CategoryPicAlt { get; set; }
        public string CategoryPicDescription { get; set; }
        public string JobLinkTitle { get; set; }
        public int CategoryParentId { get; set; }
        public string Job { get; set; }
        public long RegisteringEmployeeId { get; set; }
        public bool IsDeleted { get; set; }
        public Category Parent { get; set; }
        public ICollection<Category> Childs { get; set; }
    }
}