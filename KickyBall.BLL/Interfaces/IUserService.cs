﻿using KickyBall.BLL.DTOs;
using KickyBall.BLL.Requests;
using KickyBall.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace KickyBall.BLL.Interfaces
{
    public interface IUserService
    {
        List<AdminPageUser> GetUsers();
        AuthenticatedUser Authenticate(AuthenticationRequest request);
        bool Register(RegistrationRequest request);
        User GetById(int userId);
        UserGameStats GetUserGameStats(int userId);
        bool ResetPassword(ResetPasswordRequest request);
    }
}
