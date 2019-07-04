namespace Okapia.Domain.Commands.City
{
    public class EditCity: CreateCity
    {
        public int Id { get; set; }
        public string ProvinceName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
