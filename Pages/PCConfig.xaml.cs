using PCAssembly.src.db;
using PCAssembly.src.db.Models;
using PCAssembly.src.pcmodules;


namespace PCAssembly.Pages;

public partial class PCConfig : ContentPage
{
    private PC pc;
    private CPU _cpu;
    private Motherboard _motherboard;
    private RAM _ram;
    private Database _database;

    public PCConfig()
    {
        InitializeComponent();
        //Initialize fields
        pc = new PC();
        _cpu = new CPU();
        _motherboard = new Motherboard();
        _ram = new RAM();
        _database = new Database();

        // CPU
        CPUNameEntry.BindingContext = _cpu;
        CPUNameEntry.SetBinding(Entry.TextProperty, "Name");

        CPUSocketPicker.ItemsSource = _cpu.Sockets;
        CPURamPicker.ItemsSource = _cpu.RAMTypes;
        //Motherboard
        MNameEntry.BindingContext = _motherboard;
        MNameEntry.SetBinding(Entry.TextProperty, "Name");

        MSocketPicker.ItemsSource = _motherboard.Sockets;
        MRamPicker.ItemsSource = _motherboard.RAMTypes;
        MPCIEPicker.ItemsSource = _motherboard.PCIEs;
        //RAM
        RAMNameEntry.BindingContext = _ram;
        RAMNameEntry.SetBinding(Entry.TextProperty, "Name");

        RAMTypePicker.ItemsSource = _ram.RAMTypes;

    }

    private void CpuSocketPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        _cpu.ActiveSocket = picker.Items[picker.SelectedIndex];
        CheckCorrespond();
    }

    private void CpuRamPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        _cpu.ActiveRAMType = picker.Items[picker.SelectedIndex];
        CheckCorrespond();
    }

    private void MSocketPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        _motherboard.ActiveSocket = picker.Items[picker.SelectedIndex];
        CheckCorrespond();
    }

    private void MRamPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        _motherboard.ActiveRAMType = picker.Items[picker.SelectedIndex];
        CheckCorrespond();
    }

    private void MPCIEPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        _motherboard.ActivePCIE = picker.Items[picker.SelectedIndex];
        CheckCorrespond();
    }

    private void RAMTypePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        _ram.ActiveRAMType = picker.Items[picker.SelectedIndex];
        CheckCorrespond();
    }

    private void CheckCorrespond()
    {
        //Socket
        if (_cpu.ActiveSocket == _motherboard.ActiveSocket)
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
        if (_cpu.ActiveRAMType == _motherboard.ActiveRAMType && _motherboard.ActiveRAMType == _ram.ActiveRAMType)
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

    public async void Save_button_Clicked(object sender, EventArgs e)
    {
        pc.Name = ConfigName.Text;
        pc.CPUName = _cpu.Name;
        pc.MotherboardName = _motherboard.Name;
        pc.RAMName = _ram.Name;
        await _database.SaveItemAsync(pc);
        await Navigation.PopAsync();
    }

    public async void Delete_button_Clicked(object sender, EventArgs e)
    {
        await _database.DeleteItemAsync(pc);
    }
}