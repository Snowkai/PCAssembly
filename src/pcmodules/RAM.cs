using PCAssembly.src.pcinterfaces;
using System.Collections.ObjectModel;

namespace PCAssembly.src.pcmodules
{
    internal class RAM
    {
        public string Name { get; set; }
        public string ActiveRAMType;

        public ObservableCollection<string> RAMTypes;

        private RAMType RAMType;

        public RAM() 
        {
            Name = "None";
            ActiveRAMType = "None";

            RAMType = new RAMType();
            RAMTypes = new ObservableCollection<string>(RAMType.GetAllTypesList());
        }

    }
}
