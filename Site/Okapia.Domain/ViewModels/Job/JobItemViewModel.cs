namespace Okapia.Domain.ViewModels.Job
{
    public class JobItemViewModel
    {
        public long JobId { get; set; }
        public string JobName { get; set; }
        public string JobSlug { get; set; }
        public string JobPicture { get; set; }
        public string JobPictureAlt { get; set; }
        public string JobPictureTitle { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public double BenefitPercentForEndCustomer { get; set; }
        public double JobPrice { get; set; }
        public double JobDiscountPrice { get; set; }
        public string SmalDescription { get; set; }
    }
}