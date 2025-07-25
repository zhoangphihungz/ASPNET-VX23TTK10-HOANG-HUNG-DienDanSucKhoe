﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthWebApp_Authenticated.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Roles { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}