using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Okapia.Application.Contracts;
using Okapia.Domain.Contracts;

namespace Okapia.Application.Applications
{
    public class ControllerApplication : IControllerApplication
    {
        private readonly IControllerRepository _controllerRepository;

        public ControllerApplication(IControllerRepository controllerRepository)
        {
            _controllerRepository = controllerRepository;
        }

        public List<SelectListItem> GetControllers()
        {
            var controllers = _controllerRepository.GetAll();
            var items = new List<SelectListItem>();
            controllers.ForEach(x =>
            {
                var item = new SelectListItem(x.PersianName, x.Id.ToString());
                items.Add(item);
            });

            return items;
        }
    }
}