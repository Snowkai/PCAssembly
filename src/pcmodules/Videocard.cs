using PCAssembly.src.pcinterfaces;
using System.Collections.ObjectModel;

namespace PCAssembly.src.pcmodules
{
    public class Videocard
    {
        public string ActivePCIE;
        public string Name { get; set; }

        public ObservableCollection<string> PCIEs;

        public Videocard()
        {
            Name = "None";
            ActivePCIE = "None";

            PCIExpress VideocardPCIE = new PCIExpress();

            PCIEs = new ObservableCollection<string>(VideocardPCIE.GetAllTypesList());
        }
    }
}
