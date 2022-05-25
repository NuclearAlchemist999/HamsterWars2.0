﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWarsWebAssembly.Shared.Models
{
    public class JoinModel
    {
        public string? HamsterName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Games { get; set; }
        public int HamsterId { get; set; }
        public string? ImgName { get; set; }
        public string? WinStatus { get; set; } 
        public int GameId { get; set; }

    }
}
