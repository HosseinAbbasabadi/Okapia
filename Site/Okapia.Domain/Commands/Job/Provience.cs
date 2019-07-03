namespace Okapia.Domain.Commands.Job
{
    public class Provience
    {
        public Provience(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}