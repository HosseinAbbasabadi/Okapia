using System.Collections.Generic;
using System.Linq;
using Okapia.Domain.Commands.Job;

namespace Okapia.Areas.Administrator.Controllers
{
    public static class Provinces
    {
        public static IEnumerable<Provience> ToList()
        {
            return new List<Provience>
            {
                new Provience(0, "نامشخص"),
                new Provience(1, "مركزي"),
                new Provience(2, "گيلان"),
                new Provience(3, "مازندران"),
                new Provience(4, "آذربايجان شرقي"),
                new Provience(5, "آذربايجان غربي"),
                new Provience(6, "كرمانشاه"),
                new Provience(7, "خوزستان"),
                new Provience(8, "فارس"),
                new Provience(9, "كرمان "),
                new Provience(10, "خراسان رضوي"),
                new Provience(11, "اصفهان"),
                new Provience(12, "سيستان و بلوچستان"),
                new Provience(13, "كردستان"),
                new Provience(14, "همدان"),
                new Provience(15, "چهارمحال و بختياري"),
                new Provience(16, "لرستان"),
                new Provience(17, "ايلام"),
                new Provience(18, "كهگيلويه و بويراحمد"),
                new Provience(19, "بوشهر"),
                new Provience(20, "زنجان"),
                new Provience(21, "سمنان"),
                new Provience(22, "يزد"),
                new Provience(23, "هرمزگان"),
                new Provience(24, "تهران"),
                new Provience(25, "اردبيل"),
                new Provience(26, "قم"),
                new Provience(27, "قزوین"),
                new Provience(28, "گلستان"),
                new Provience(29, "خراسان شمالي"),
                new Provience(30, "خراسان جنوبي"),
                new Provience(31, "البرز")
            }.OrderBy(x => x.Name);
        }
    }
}