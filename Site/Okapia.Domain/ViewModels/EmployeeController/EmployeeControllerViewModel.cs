namespace Okapia.Domain.ViewModels.EmployeeController
{
    public class EmployeeControllerViewModel
    {
        public int Id { get; set; }
        public string ControllerId { get; set; }
    }

    public class AccessControllerViewModel
    {
        public int ControllerId { get; set; }
        public string ControllerName { get; set; }
        public string ControllerPersianName { get; set; }
    }
}
