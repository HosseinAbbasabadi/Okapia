namespace Okapia.Domain.Commands.Category
{
    public class EditCategory : CreateCategory
    {
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
