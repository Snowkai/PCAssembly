namespace PCAssembly.src.pcinterfaces
{
    internal interface IPCinterfaces
    {
        string GetActiveType();
        string[] GetAllTypesList();
        void SetActiveType(string type);
    }
}
