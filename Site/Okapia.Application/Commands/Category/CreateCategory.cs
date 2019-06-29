using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Application.Commands.Category
{
    public class CreateCategory
    {
        public string CatgoryName { get; set; }
        public string CategorySmallDescription { get; set; }
        public string CategoryMetaTag { get; set; }
        public string CategoryMetaDesccription { get; set; }
        public string CategorySeohead { get; set; }
        public string CategoryPageTittle { get; set; }
        public int CategoryParentId { get; set; }
        public SelectList Categories { get; set; }
        public IFormFile Photo { get; set; }
    }
}
