using Microsoft.AspNetCore.Mvc;
using Okapia.Application.Contracts;

namespace Okapia.ViewComponents
{
    public class SuggestionsViewComponent : ViewComponent
    {
        private readonly ISettingApplication _settingApplication;

        public SuggestionsViewComponent(ISettingApplication settingApplication)
        {
            _settingApplication = settingApplication;
        }

        public IViewComponentResult Invoke()
        {
            var suggestionsInfo = _settingApplication.GetSuggestionsInfo();
            return View("_Suggestions", suggestionsInfo);
        }
    }
}