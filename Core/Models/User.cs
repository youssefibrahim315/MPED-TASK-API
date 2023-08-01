using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class User:IdentityUser
    {
        //public int Id { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        public string Gender { get; set; }
        //public string Phone { get; set; }
        [Required ,MaxLength(400)]
        public string Message { get; set; }
        public string Location { get; set; }

    }
}