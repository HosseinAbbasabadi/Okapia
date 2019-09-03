using System.Collections.Generic;

namespace Okapia.Domain.Models
{
    public class Job
    {
        public long JobId { get; set; }
        public string JobName { get; set; }
        public string JobSmallDescription { get; set; }
        public string JobFeatures { get; set; }
        public string JobDescription { get; set; }
        public string JobContactTitile { get; set; }
        public string JobManagerFirstName { get; set; }
        public string JobManagerLastName { get; set; }
        public string JobEmailAddress { get; set; }
        public int JobCategory { get; set; }
        public string JobTel1 { get; set; }
        public string JobTel2 { get; set; }
        public string JobMobile1 { get; set; }

        public string JobMobile2 { get; set; }

        //public string JobGeoLocation { get; set; }
        public int JobProvienceId { get; set; }
        public int JobCityId { get; set; }
        public int JobDistrictId { get; set; }
        public int JobNeighborhoodId { get; set; }
        public string JobAddress { get; set; }
        public string JobWazeMap { get; set; }
        public string JobWazeLink { get; set; }
        public string JobPageTittle { get; set; }
        public string JobSlug { get; set; }
        public string JobMetaTag { get; set; }
        public string JobMetaDesccription { get; set; }
        public string JobSeohead { get; set; }
        public string JobCanonicalAddress { get; set; }
        public string JobContractNumber { get; set; }
        public double JobBenefitPercentForEndCustomer { get; set; }
        public double JobBenefitPercentForCompany { get; set; }
        public string JobRemoved301InsteadUrl { get; set; }
        public double JobDiscountPercentForCustomer { get; set; }
        public double JobDiscountPercentForCompnay { get; set; }
        public double JobDiscountPercentForSabaMehrDiscount { get; set; }
        public double JobBefitPercentForIntroducingEndCustomer { get; set; }
        public double MarketerPercentForRegisteringShop { get; set; }
        public int MarketerId { get; set; }
        public string JobPosNameNumber { get; set; }
        public string JobAccountNumber { get; set; }
        public int JobShowOrderIncategory { get; set; }
        public bool ShowInHomePage { get; set; }
        public long RegisteringEmployerId { get; set; }
        public int CustomerIntroductionLimit { get; set; }
        public bool IsWebsite { get; set; }
        public string WebSiteUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TelegramUrl { get; set; }
        public bool IsStared { get; set; }
        public double JobPrice { get; set; }
        public ICollection<JobPicture> JobPictures { get; set; }
        public ICollection<Comment> JobComments { get; set; }
        public Account Account { get; set; }
    }
}