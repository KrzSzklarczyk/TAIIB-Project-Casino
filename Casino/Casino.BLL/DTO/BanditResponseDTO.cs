﻿using Casino.Model.DataTypes;
using Casino.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.BLL.DTO
{
    public class BanditResponseDTO
    {

        public string Description { get; set; }
        public BanditType Position1 { get; set; }
        public BanditType Position2 { get; set; }
        public BanditType Position3 { get; set; }
    }
}
