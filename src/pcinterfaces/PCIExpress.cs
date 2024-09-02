using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCAssembly.src.pcinterfaces
{
    internal class PCIExpress: InterfacePC
    {
        private string PCIEType;
        public string[] AllTypes { get; set; }

        public PCIExpress()
        {
            PCIEType = "None";
            AllTypes = new string[] {
            "PCI Express 1.0",
            "PCI Express 2.0",
            "PCI Express 3.0",
            "PCI Express 4.0",
            "PCI Express 5.0",
            "PCI Express 6.0",
            "PCI Express 7.0"
            };
        }


        public string GetActiveType()
        {
            return PCIEType;
        }
        public string[] GetAllTypesList()
        {
            return AllTypes;
        }
        public void SetActiveType(string type)
        {
            foreach (var item in AllTypes)
            {
                if (type == item)
                {
                    PCIEType = item;
                }
            }
        }
    }
}
