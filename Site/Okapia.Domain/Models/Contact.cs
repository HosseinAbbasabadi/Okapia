using System;
using System.Collections.Generic;
using System.Text;

namespace Okapia.Domain.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool IsChecked { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime CheckDate { get; set; }
        public long CheckerAccountId { get; set; }
    }
}
