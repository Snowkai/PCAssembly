using PCAssembly.src.pcinterfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCAssembly.src.pcmodules
{
    internal class CPU
    {
        public string ActiveSocket;
        public string Name;
        public string ActiveRAMType;

        public ObservableCollection<string> Sockets;
        public ObservableCollection<string> RAMTypes;

        private CPUSocket CPUSocket;
        private RAMType RAMType;
        public CPU() 
        {
            Name = "None";
            ActiveSocket = "None";
            ActiveRAMType = "None";

            CPUSocket = new CPUSocket();
            RAMType = new RAMType();

            Sockets = new ObservableCollection<string>(CPUSocket.GetAllTypesList());
            RAMTypes = new ObservableCollection<string>(RAMType.GetAllTypesList());
        }

    }
}
