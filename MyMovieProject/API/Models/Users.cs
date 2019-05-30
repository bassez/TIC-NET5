﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime Date_Created { get; set; }

        // FK
        public Notes Notes { get; set; }
        public Comments Comments { get; set; }
        public Likes Likes { get; set; }
    }
}
