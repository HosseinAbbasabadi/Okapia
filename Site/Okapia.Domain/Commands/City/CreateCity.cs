using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Domain.Commands.City
{
    public class CreateCity
    {
        public string Name { get; set; }
        public int ProvinceId { get; set; }
        public SelectList Provinces { get; set; }
    }
}
