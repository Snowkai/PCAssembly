namespace PCAssembly.src.pcinterfaces
{
    internal class CPUSocket : IPCinterfaces
    {
        public string SocketType;
        private string[] AllTypes;
        public CPUSocket()
        {
            SocketType = "None";
            AllTypes = new string[] { 
                // Intel
                "Socket 1", "Socket 2", "Socket 3", "Socket 4", "Socket 5", "Socket 6", "Socket 7", "Socket 8",
                "Socket 370", "Socket 423", "Socket 478", "LGA 775", "LGA 1156", "LGA 1366", "LGA 1155",
                "LGA 2011", "LGA 1150", "LGA 2011-3", "LGA 1151", "LGA 2066", "LGA 1200", "LGA 1700",
                "LGA 3647", "LGA 4189",
    
                // AMD
                "Socket 563", "Socket 754", "Socket 939", "Socket 940", "AM2", "AM2+", "AM3", "AM3+",
                "FM1", "FM2", "FM2+", "AM4", "sTR4", "sTRX4", "AM5", "SP3" };
        }


        public string GetActiveType()
        {
            return SocketType;
        }
        public string[] GetAllTypesList()
        {
            return AllTypes;
        }
        public void SetActiveType(string type)
        {
            foreach (var item in AllTypes)
            {
                if (type == item)
                {
                    SocketType = item;
                }
                else
                {
                    SocketType = "None";
                }
            }
        }
    }
}
