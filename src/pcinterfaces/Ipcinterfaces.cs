using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCAssembly.src.pcinterfaces
{
    internal interface IPCinterfaces
    {
        string GetActiveType();
        string[] GetAllTypesList();
        void SetActiveType(string type);
    }
}
