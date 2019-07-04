namespace Okapia.Domain.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategorySmallDescription { get; set; }
        public string CategoryMetaTag { get; set; }
        public string CategoryMetaDesccription { get; set; }
        public string CategorySeohead { get; set; }
        public string CategoryPageTittle { get; set; }
        public string CategoryThumbPicUrl { get; set; }
        public string JobLinkTitle { get; set; }
        public int CategoryParentId { get; set; }
        public string Job { get; set; }
        public int RegisteringEmployeeId { get; set; }
        public bool IsDeleted { get; set; }
    }
}