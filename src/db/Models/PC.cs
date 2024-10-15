using SQLite;

namespace PCAssembly.src.db.Models
{
    public class PC
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "None";
        public string CPUName { get; set; } = "None";
        public string CPUSocket { get; set; } = "None";
        public string CPURAam { get; set; } = "None";
        public string MotherboardName { get; set; } = "None";
        public string MotherboardSocket { get; set; } = "None";
        public string MotherboardRam { get; set; } = "None";
        public string MotherboardPCI { get; set; } = "None";
        public string MotherboardFormFactor { get; set; } = "None";
        public string RAMName { get; set; } = "None";
        public string RAMType { get; set; } = "None";
        public string VideocardName { get; set; } = "None";
        public string VideocardPCIE { get; set; } = "None";
        public string CaseName { get; set; } = "None";
        public string CaseFormFactor { get; set; } = "None";
        public string PowerUnitName { get; set; } = "None";
        public string PowerUnitWatt { get; set; } = "None";
        public string MarkText { get; set; } = "None";
    }
}
