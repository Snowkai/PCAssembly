using Microsoft.Extensions.Options;
using PCAssembly.src.db;
using PCAssembly.src.db.Models;
using PCAssembly.src.pcmodules;

namespace PCAssembly.Pages;

public partial class PCConfig : ContentPage
{
    PC pc = new PC();
    CPU CPU = new CPU();
    Motherboard Motherboard = new Motherboard();
    RAM RAM = new RAM();

    public PCConfig()
    {
        InitializeComponent();

        // CPU
        CPUNameEntry.BindingContext = CPU;
        CPUNameEntry.SetBinding(Entry.TextProperty, "Name");

        CPUSocketPicker.ItemsSource = CPU.Sockets;
        CPURamPicker.ItemsSource = CPU.RAMTypes;
        //Motherboard
        MNameEntry.BindingContext = Motherboard;
        MNameEntry.SetBinding(Entry.TextProperty, "Name");

        MSocketPicker.ItemsSource = Motherboard.Sockets;
        MRamPicker.ItemsSource = Motherboard.RAMTypes;
        MPCIEPicker.ItemsSource = Motherboard.PCIEs;
        //RAM
        RAMNameEntry.BindingContext = RAM;
        RAMNameEntry.SetBinding(Entry.TextProperty, "Name");

        RAMTypePicker.ItemsSource = RAM.RAMTypes;
    }

    private void CpuSocketPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        CPU.ActiveSocket = picker.Items[picker.SelectedIndex];
        CheckCorrespond();
    }

    private void CpuRamPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        CPU.ActiveRAMType = picker.Items[picker.SelectedIndex];
        CheckCorrespond();
    }

    private void MSocketPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        Motherboard.ActiveSocket = picker.Items[picker.SelectedIndex];
        CheckCorrespond();
    }

    private void MRamPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        Motherboard.ActiveRAMType = picker.Items[picker.SelectedIndex];
        CheckCorrespond();
    }

    private void MPCIEPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        Motherboard.ActivePCIE = picker.Items[picker.SelectedIndex];
        CheckCorrespond();
    }

    private void RAMTypePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        RAM.ActiveRAMType = picker.Items[picker.SelectedIndex];
        CheckCorrespond();
    }

    private void CheckCorrespond()
    {
        //Socket
        if (CPU.ActiveSocket == Motherboard.ActiveSocket)
        {
            CPUSocketBox.Color = Colors.Green;
            MSocketBox.Color = Colors.Green;
        }
        else
        {
            CPUSocketBox.Color = Colors.Red;
            MSocketBox.Color = Colors.Red;
        }
        //RAMType
        if (CPU.ActiveRAMType == Motherboard.ActiveRAMType && Motherboard.ActiveRAMType == RAM.ActiveRAMType)
        {
            CPURAMBox.Color = Colors.Green;
            MRAMBox.Color = Colors.Green;
            RAMBox.Color = Colors.Green;
        }
        else
        {
            CPURAMBox.Color = Colors.Red;
            MRAMBox.Color = Colors.Red;
            RAMBox.Color = Colors.Red;
        }
        
    }

    private void Save_button_Clicked(object sender, EventArgs e)
    {
        pc.Name = ConfigName.Text;
        pc.CPU = CPU;
        pc.Motherboard = Motherboard;
        pc.RAM = RAM;
        Database db = new Database();
        db.SaveItemAsync(pc);
    }

    private void Delete_button_Clicked(object sender, EventArgs e)
    {
        Database db = new Database();
        db.DeleteItemAsync(pc);
    }
}