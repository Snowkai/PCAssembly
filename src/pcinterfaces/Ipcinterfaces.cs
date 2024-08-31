using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCAssembly.src.pcinterfaces
{
    internal interface Ipcinterfaces
    {
        public string ActiveType { get; set; }

        string GetActiveType()
        {
            return ActiveType;
        }
        string[] GetAllTypesList()
        {
            return new string[0];
        }
        void SetActiveType(string type) { }
    }
}
