namespace Okapia.Domain.Models
{
    public class EmployeeController
    {
        public int Id { get; set; }
        public long EmployeeId { get; set; }
        public int ControllerId { get; set; }
        public Employee Employee { get; set; }
    }
}
