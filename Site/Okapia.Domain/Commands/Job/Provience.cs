using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

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

    public class AddToBox
    {
        public long JobId { get; set; }
        [Display(Name = "باکس")] public int BoxId { get; set; }
        [Display(Name = "باکس های فعال")] public SelectList Boxes { get; set; }
    }
}