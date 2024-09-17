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
        public CPU CPU { get; set; } = new CPU();
        public Motherboard Motherboard { get; set; } = new Motherboard();
        public RAM RAM { get; set; } = new RAM();
    }
}
