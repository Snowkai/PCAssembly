using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCAssembly.src.pcmodules
{
    public class PowerUnit
    {
        public string Name { get; set; }
        public string Watt { get; set; }
        public PowerUnit() 
        {
            Name = "None";
            Watt = "None";
        }
    }
}
