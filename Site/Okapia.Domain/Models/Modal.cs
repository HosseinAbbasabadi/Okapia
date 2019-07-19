using System;

namespace Okapia.Domain.Models
{
    public class Modal
    {
        public int ModalId { get; set; }
        public string ModalTitle { get; set; }
        public string ModalMessage { get; set; }
        public string ModalPageLink { get; set; }
        public string ModalPic { get; set; }
        public string ModalPicTitle { get; set; }
        public string ModalPicAlt { get; set; }
        public string ModalPicDescription { get; set; }
        public int ModalGroupId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime ModalCreationDate { get; set; }
        public DateTime ModalStartDate { get; set; }
        public DateTime ModalEndDate { get; set; }
        public virtual Group ModalGroup { get; set; }
    }
}