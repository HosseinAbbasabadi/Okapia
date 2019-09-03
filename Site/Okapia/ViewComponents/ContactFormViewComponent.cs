using Microsoft.AspNetCore.Mvc;
using Okapia.Domain.Commands.Contactus;

namespace Okapia.ViewComponents
{
    public class ContactFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var createContact = new CreateContact();
            return View("_ContactForm", createContact);
        }
    }
}