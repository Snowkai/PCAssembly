using PCAssembly.src.pcmodules;
using System.Collections.ObjectModel;

namespace PCAssembly.Pages;

public partial class PCConfig : ContentPage
{
    CPU CPU = new CPU();

    public PCConfig()
    {
        InitializeComponent();

        // Привязка данных
        CPUNameEntry.BindingContext = CPU;
        CPUNameEntry.SetBinding(Entry.TextProperty, "Name");

        CPUSocketPicker.ItemsSource = CPU.Sockets;
        CPURamPicker.ItemsSource = CPU.RAMTypes;
    }

    private void CpuSocketPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        CPU.ActiveSocket = picker.Items[picker.SelectedIndex];
    }

    private void CpuRamPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        CPU.ActiveRAMType = picker.Items[picker.SelectedIndex];
    }

}