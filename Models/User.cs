﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication2.Models
{ 
        public class User
        {
            public long Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Username { get; set; }

            [JsonIgnore]
            public string Password { get; set; }

            public string Token { get; set; }
        }
    }
