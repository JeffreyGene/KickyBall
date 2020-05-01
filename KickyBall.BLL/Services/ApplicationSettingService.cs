using KickyBall.BLL.DTOs;
using KickyBall.BLL.Interfaces;
using KickyBall.BLL.Requests;
using KickyBall.DAL;
using KickyBall.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KickyBall.BLL.Services
{
    public class ApplicationSettingService : IApplicationSettingService
    {
        private KickyBallContext _context;
        private IReadOnlyList<string> gameSettingCodes = new List<string> { "PRT", "RT", "NOPR", "NOR" };
        public ApplicationSettingService(KickyBallContext context)
        {
            _context = context;
        }

        public List<ApplicationSetting> GetApplicationSettings()
        {
            return _context.ApplicationSettings.OrderBy(s => s.Name).ToList();
        }

        public List<ApplicationSetting> GetGameSettings()
        {
            return _context.ApplicationSettings.Where(s => gameSettingCodes.Contains(s.ApplicationSettingCode)).ToList();
        }

        public ApplicationSetting UpdateSetting(ApplicationSetting setting)
        {
            ApplicationSetting settingToUpdate = _context.ApplicationSettings.FirstOrDefault(s => s.ApplicationSettingCode == setting.ApplicationSettingCode);
            settingToUpdate.Value = setting.Value;
            _context.SaveChanges();
            return settingToUpdate;
        }
    }
}
