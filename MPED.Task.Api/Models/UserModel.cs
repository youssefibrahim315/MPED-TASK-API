using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPED.Task.Api.Models
{
    public class UserModel
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Message { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Id { get; set; }
    }
}
