namespace PCAssembly.src.pcinterfaces
{
    internal class FormFactor
    {
        public string FormFactorType;
        private string[] AllTypes;
        public FormFactor()
        {
            FormFactorType = "None";
            AllTypes = new string[] {
                "ATX", "Micro-ATX", "Mini-ITX", "E-ATX", "XL-ATX"};
        }


        public string GetActiveType()
        {
            return FormFactorType;
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
                    FormFactorType = item;
                }
                else
                {
                    FormFactorType = "None";
                }
            }
        }
    }
}
