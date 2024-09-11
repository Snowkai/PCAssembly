using PCAssembly.src.pcinterfaces;
using System.Collections.ObjectModel;

namespace PCAssembly.src.pcmodules
{
    internal class Motherboard
    {
        public string Name { get; set; }
        public string ActiveSocket;
        public string ActiveRAMType;
        public string ActivePCIE;

        public ObservableCollection<string> Sockets;
        public ObservableCollection<string> RAMTypes;
        public ObservableCollection<string> PCIEs;

        private CPUSocket CPUSocket;
        private RAMType RAMType;
        private PCIExpress PCIExpress;
        public Motherboard()
        {
            Name = "None";
            ActiveSocket = "None";
            ActiveRAMType = "None";
            ActivePCIE = "None";

            CPUSocket = new CPUSocket();
            RAMType = new RAMType();
            PCIExpress = new PCIExpress();

            Sockets = new ObservableCollection<string>(CPUSocket.GetAllTypesList());
            RAMTypes = new ObservableCollection<string>(RAMType.GetAllTypesList());
            PCIEs = new ObservableCollection<string>(PCIExpress.GetAllTypesList());
        }

    }
}
