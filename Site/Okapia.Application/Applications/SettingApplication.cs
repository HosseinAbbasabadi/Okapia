using System;
using System.Collections.Generic;
using System.Linq;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.Setting;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;

namespace Okapia.Application.Applications
{
    public class SettingApplication : ISettingApplication
    {
        private readonly ISettingRepository _settingRepository;
        private readonly ISettingQuery _settingQuery;

        public SettingApplication(ISettingRepository settingRepository, ISettingQuery settingQuery)
        {
            _settingRepository = settingRepository;
            _settingQuery = settingQuery;
        }

        public OperationResult CreateSettings(SetSettings command)
        {
            var result = new OperationResult("Settings", "Create");
            try
            {
                var settings = _settingRepository.GetAll();
                foreach (var property in command.GetType().GetProperties())
                {
                    var setting = settings.First(x => x.SettingKey == property.Name);
                    var value = property.GetValue(command, null);
                    if (value != null)
                        setting.SettingValue = value.ToString();
                }

                _settingRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        public SetSettings GetSettings()
        {
            var settings = _settingRepository.GetAll();
            return MapSettings(settings);
        }

        public SetSettings GetSettingsForView()
        {
            var settings = _settingQuery.GetAll();
            return MapSettings(settings);
        }

        private static SetSettings MapSettings(IReadOnlyCollection<Setting> settings)
        {
            var setSetting = new SetSettings();
            foreach (var property in setSetting.GetType().GetProperties())
            {
                var setting = settings.First(x => x.SettingKey == property.Name);
                property.SetValue(setSetting, setting.SettingValue);
            }

            return setSetting;
        }
    }
}