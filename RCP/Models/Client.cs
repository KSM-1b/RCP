﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RCP.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ERP_ID { get; set; }
        public string Description { get; set; }
        public string Representant { get; set; }
    }
}
