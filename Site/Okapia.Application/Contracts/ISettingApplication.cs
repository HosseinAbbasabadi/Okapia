using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Setting;

namespace Okapia.Application.Contracts
{
    public interface ISettingApplication
    {
        OperationResult CreateSettings(SettingDto command);
        SettingDto GetSettings();

        string GetForgetPasswordText();
        //
        SettingDto GetSettingsForView();
        string GetPrivacy();
        BannerDto GetBannerInfo();
        SuggestionDto GetSuggestionsInfo();
    }
}
