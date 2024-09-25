using PCAssembly.src.pcmodules;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCAssembly.src.db.Models
{
    public class PC
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "None";
        public string CPUName { get; set; } = "None";
        public string MotherboardName { get; set; } = "None";
        public string RAMName { get; set; } = "None";
    }
}
