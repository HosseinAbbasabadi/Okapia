using System.Collections.Generic;
using Okapia.Domain.Commands.Job;

namespace Okapia.Areas.Administrator.Controllers
{
    public static class Provinces
    {
        public static IEnumerable<Provience> ToList()
        {
            return new List<Provience>
            {
                new Provience(0, "استان مورد نظر را انتخاب کنید"),
                new Provience(31, "البرز"),
                new Provience(27, "قزوین"),
                new Provience(16, "لرستان")
            };
        }
    }
}
