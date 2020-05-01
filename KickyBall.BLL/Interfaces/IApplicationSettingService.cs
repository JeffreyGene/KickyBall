using KickyBall.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KickyBall.BLL.Interfaces
{
    public interface IApplicationSettingService
    {
        List<ApplicationSetting> GetApplicationSettings();
        ApplicationSetting UpdateSetting(ApplicationSetting setting);
        List<ApplicationSetting> GetGameSettings();
    }
}
