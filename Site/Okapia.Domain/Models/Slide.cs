using System;

namespace Okapia.Domain.Models
{
    public class Slide
    {
        public int SlideId { get; set; }
        public string SlideName { get; set; }
        public string SlideAlt { get; set; }
        public string SlideTitle { get; set; }
        public string SlideDescription { get; set; }
        public string SlideLink { get; set; }
        public DateTime SlideCreationDate { get; set; }
        public bool SlideIsDeleted { get; set; }
        public int SlideProvinceId { get; set; }
    }
}