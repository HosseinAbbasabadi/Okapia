namespace Okapia.Domain.Commands.Modal
{
    public class EditModal : CreateModal
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
