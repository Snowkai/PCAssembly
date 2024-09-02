﻿using PCAssembly.src.pcinterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCAssembly.src.pcmodules
{
    internal class CPU
    {
        string? Name { get; set; }
        CPUScocket? CPUScocket { get; set; }
        RAMType? RAMType { get; set; }
    }
}
