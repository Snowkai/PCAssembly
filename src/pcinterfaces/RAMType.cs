using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCAssembly.src.pcinterfaces
{
    internal class RAMType : InterfacePC
    {
        private string RamType;
        public string[] AllTypes { get; set; }

        public RAMType()
        {
            RamType = "None";
            AllTypes = new string[] {
                // DRAM (Dynamic RAM)
                "SDR SDRAM",  // Single Data Rate Synchronous DRAM
                "DDR SDRAM",  // Double Data Rate Synchronous DRAM
                "DDR2 SDRAM", // Double Data Rate 2 Synchronous DRAM
                "DDR3 SDRAM", // Double Data Rate 3 Synchronous DRAM
                "DDR4 SDRAM", // Double Data Rate 4 Synchronous DRAM
                "DDR5 SDRAM", // Double Data Rate 5 Synchronous DRAM

                // SRAM (Static RAM)
                "SRAM",  // Static RAM

                // RDRAM (Rambus DRAM)
                "RDRAM",  // Rambus DRAM

                // VRAM (Video RAM)
                "VRAM",  // Video RAM

                // Flash Memory
                "NAND Flash",  // NAND Flash Memory
                "NOR Flash",   // NOR Flash Memory

                // ROM (Read-Only Memory)
                "PROM",  // Programmable ROM
                "EPROM", // Erasable Programmable ROM
                "EEPROM" // Electrically Erasable Programmable ROM 
            };
        }


        public string GetActiveType()
        {
            return RamType;
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
                    RamType = item;
                }
            }
        }
    }
}
