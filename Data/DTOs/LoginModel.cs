using Data.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTOs
{
    public class LoginModel
    {
        public string Token { get; set; }
        public bool IsLogin { get; set; }
        public UserDTO User  { get; set; }
    }
}
