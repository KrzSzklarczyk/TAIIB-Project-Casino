﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BLL
{
    public class AuthSettings
    {
        public string JwtKey { get; set; }
        public int JwtExpiredDays { get; set; }
        public string JwtIssuer { get; set; }
    }
}
