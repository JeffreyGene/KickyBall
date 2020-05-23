using System;
using System.Collections.Generic;
using System.Text;

namespace KickyBall.BLL.Requests
{
    public class ResetPasswordRequest
    {
        public int UserId { get; set; }
        public string NewPassword { get; set; }
    }
}
