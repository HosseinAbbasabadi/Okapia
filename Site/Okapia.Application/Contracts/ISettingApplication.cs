using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Setting;

namespace Okapia.Application.Contracts
{
    public interface ISettingApplication
    {
        OperationResult CreateSettings(SetSettings command);
        SetSettings GetSettings();
        
        //
        SetSettings GetSettingsForView();
    }
}
