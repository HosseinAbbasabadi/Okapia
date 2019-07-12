using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Okapia.Application.Contracts
{
    public interface IControllerApplication
    {
        List<SelectListItem> GetControllers();
    }
}
