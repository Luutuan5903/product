﻿using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using FinallyProject.Configuration.Dto;

namespace FinallyProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : FinallyProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
