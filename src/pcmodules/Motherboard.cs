using PCAssembly.src.pcinterfaces;
using System.Collections.ObjectModel;

namespace PCAssembly.src.pcmodules
{
    public class Motherboard
    {
        public string Name { get; set; }
        public string ActiveSocket;
        public string ActiveRAMType;
        public string ActivePCIE;
        public string ActiveFormFactor;

        public ObservableCollection<string> Sockets;
        public ObservableCollection<string> RAMTypes;
        public ObservableCollection<string> PCIEs;
        public ObservableCollection<string> FormFactors;

        private CPUSocket CPUSocket;
        private RAMType RAMType;
        private PCIExpress PCIExpress;
        private FormFactor FormFactor;
        public Motherboard()
        {
            Name = "None";
            ActiveSocket = "None";
            ActiveRAMType = "None";
            ActivePCIE = "None";
            ActiveFormFactor = "None";

            CPUSocket = new CPUSocket();
            RAMType = new RAMType();
            PCIExpress = new PCIExpress();
            FormFactor = new FormFactor();

            Sockets = new ObservableCollection<string>(CPUSocket.GetAllTypesList());
            RAMTypes = new ObservableCollection<string>(RAMType.GetAllTypesList());
            PCIEs = new ObservableCollection<string>(PCIExpress.GetAllTypesList());
            FormFactors = new ObservableCollection<string>(FormFactor.GetAllTypesList());
        }

    }
}
