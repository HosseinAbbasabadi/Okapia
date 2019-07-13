namespace Okapia.Domain.Models
{
    public class Controller
    {
        public Controller()
        {
            
        }

        public Controller(int id, string name, string persianName, int areaId)
        {
            Id = id;
            Name = name;
            PersianName = persianName;
            AreaId = areaId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PersianName { get; set; }
        public int AreaId { get; set; }
    }
}
