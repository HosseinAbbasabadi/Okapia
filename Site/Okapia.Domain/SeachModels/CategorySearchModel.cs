using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Domain.ViewModels.Category;

namespace Okapia.Domain.SeachModels
{
    public class CategorySearchModel : BaseSerachModel
    {
        public string CategoryName { get; set; }
        public int CategoryParrentId { get; set; }
        public SelectList Categories { get; set; }
    }
}
