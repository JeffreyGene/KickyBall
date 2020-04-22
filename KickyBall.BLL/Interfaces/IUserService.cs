using KickyBall.BLL.Requests;
using KickyBall.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KickyBall.BLL.Interfaces
{
    public interface IUserService
    {
        List<User> GetUsers();
        User Authenticate(AuthenticationRequest request);
        User Register(RegistrationRequest request);
    }
}
