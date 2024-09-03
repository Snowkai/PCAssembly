using PCAssembly.src.pcmodules;

namespace PCAssembly.Pages;

public partial class PCConfig : ContentPage
{

	CPU CPU { get; set; }
	public PCConfig()
	{
		InitializeComponent();

		CPU = new CPU();
		Picker CPUSocketPicker = new Picker();
		CPUSocketPicker.ItemsSource = CPU.CPUScocket.GetAllTypesList();
	}

    private void CPUSocketPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
		CPU.CPUScocket.SetActiveType(CPUSocketPicker.Items[CPUSocketPicker.SelectedIndex]);
    }
}