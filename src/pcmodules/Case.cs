using PCAssembly.src.pcinterfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCAssembly.src.pcmodules
{
    public class Case
    {
        public string ActiveFormFactor;
        public string Name { get; set; }

        public ObservableCollection<string> FormFactors;

        private FormFactor FormFactor;

        public Case()
        {
            Name = "None";
            ActiveFormFactor = "None";

            FormFactor = new FormFactor();

            FormFactors = new ObservableCollection<string>(FormFactor.GetAllTypesList());
        }
    }
}
