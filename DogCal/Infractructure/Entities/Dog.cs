﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infractructure.Entities
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int ActivityLevel { get; set; }
        public int? CalorieNeed { get; set; }
        public int OwnerId { get; set; }
    }
}
