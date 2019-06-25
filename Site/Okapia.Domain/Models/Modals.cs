using System;

namespace Okapia.Domain.Models
{
    public partial class Modals
    {
        public int ModalId { get; set; }
        public string ModalTtitle { get; set; }
        public string ModalMessage { get; set; }
        public string ModalPageLink { get; set; }
        public string ModalPic { get; set; }
        public int ModalGroupId { get; set; }
        public DateTime ModalCreationDate { get; set; }
        public DateTime ModalStartDate { get; set; }
        public DateTime ModalEndDate { get; set; }

        public virtual Groups ModalGroup { get; set; }
    }
}