using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCAssembly.src.pcinterfaces
{
    internal abstract class InterfacePC: IPCinterfaces
    {
        public required string ActiveType { get; set; }
        private string[]? AllTypes { get; set; }

        string GetActiveType()
        {
            return ActiveType;
        }
        string[] GetAllTypesList()
        {
            AllTypes = new string[0];
            return AllTypes;
        }
        void SetActiveType(string type) { }
    }
}
