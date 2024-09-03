using PCAssembly.src.pcinterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCAssembly.src.pcmodules
{
    internal class CPU
    {
        public string Name;
        public CPUScocket CPUScocket;
        public RAMType RAMType;
        public CPU() 
        {
            Name = "None";
            var _valueSocket  = new CPUScocket();
            CPUScocket = _valueSocket;
            var _valueRAM = new RAMType();
            RAMType = _valueRAM;
        }

    }
}
