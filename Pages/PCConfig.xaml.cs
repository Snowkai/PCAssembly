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
    private Case _case;
    private Videocard _videocard;
    private PowerUnit _powerunit;
    private Database _database;

    public PCConfig()
    {
        InitializeComponent();
        //Initialize fields
        Init();
    }

    public PCConfig(PC item)
    {
        InitializeComponent();
        Init();
        pc = item;
        ConfigName.Text = item.Name;
        CPUNameEntry.Text = item.CPUName;
        CPUSocketPicker.SelectedItem = item.CPUSocket;
        CPURamPicker.SelectedItem = item.CPURAam;
        MNameEntry.Text = item.MotherboardName;
        MSocketPicker.SelectedItem = item.MotherboardSocket;
        MRamPicker.SelectedItem = item.MotherboardRam;
        MFormFactorPicker.SelectedItem = item.MotherboardFormFactor;
        MPCIEPicker.SelectedItem = item.MotherboardPCI;
        RAMNameEntry.Text = item.RAMName;
        RAMTypePicker.SelectedItem = item.RAMType;
        VideocardNameEntry.Text = item.VideocardName;
        VideocardPCIEPicker.SelectedItem = item.VideocardPCIE;
        CaseNameEntry.Text = item.CaseName;
        CaseFormFactorPicker.SelectedItem = item.CaseFormFactor;
        PowerUnitNameEntry.Text = item.PowerUnitName;
        PowerUnitWattEntry.Text = item.PowerUnitWatt;
        MarksText.Text = item.MarkText;
    }

    private void Init()
    {
        pc = new PC();
        _cpu = new CPU();
        _motherboard = new Motherboard();
        _ram = new RAM();
        _database = new Database();
        _videocard = new Videocard();
        _powerunit = new PowerUnit();
        _case = new Case();

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
        MFormFactorPicker.ItemsSource = _motherboard.FormFactors;
        //RAM
        RAMNameEntry.BindingContext = _ram;
        RAMNameEntry.SetBinding(Entry.TextProperty, "Name");

        RAMTypePicker.ItemsSource = _ram.RAMTypes;
        //Videocard
        VideocardNameEntry.BindingContext = _videocard;
        VideocardNameEntry.SetBinding(Entry.TextProperty, "Name");

        VideocardPCIEPicker.ItemsSource = _videocard.PCIEs;
        //PowerUnit
        PowerUnitNameEntry.BindingContext = _powerunit;
        PowerUnitNameEntry.SetBinding(Entry.TextProperty, "Name");
        PowerUnitWattEntry.BindingContext = _powerunit;
        PowerUnitWattEntry.SetBinding(Entry.TextProperty, "Name");
        //Case
        CaseNameEntry.BindingContext = _ram;
        CaseNameEntry.SetBinding(Entry.TextProperty, "Name");

        CaseFormFactorPicker.ItemsSource = _case.FormFactors;
        //Other marks
        MarksText.BindingContext = pc;
        MarksText.SetBinding(Editor.TextProperty, "MarkText");
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

    private void MFormFactorPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        _motherboard.ActiveFormFactor = picker.Items[picker.SelectedIndex];
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

    private void VideocardPCIEPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        _videocard.ActivePCIE = picker.Items[picker.SelectedIndex];
        CheckCorrespond();
    }
    private void CaseFormFactorPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        _case.ActiveFormFactor = picker.Items[picker.SelectedIndex];
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
        //FormFactor
        if (_motherboard.ActiveFormFactor == _case.ActiveFormFactor)
        {
            MFormFactorBox.Color = Colors.Green;
            CaseFormFactorBox.Color = Colors.Green;
        }
        else
        {
            MFormFactorBox.Color = Colors.Red;
            CaseFormFactorBox.Color = Colors.Red;
        }
        //PCIExpress
        if (_motherboard.ActivePCIE == _videocard.ActivePCIE)
        {
            MPCIBox.Color = Colors.Green;
            VideocardBox.Color = Colors.Green;
        }
        else
        {
            MPCIBox.Color = Colors.Red;
            VideocardBox.Color = Colors.Red;
        }
    }

    public async void Save_button_Clicked(object sender, EventArgs e)
    {
        pc.Name = ConfigName.Text;
        pc.CPUName = _cpu.Name;
        pc.MotherboardName = _motherboard.Name;
        pc.RAMName = _ram.Name;
        pc.CPUSocket = _cpu.ActiveSocket;
        pc.CPURAam = _cpu.ActiveRAMType;
        pc.MotherboardSocket = _motherboard.ActiveSocket;
        pc.MotherboardRam = _motherboard.ActiveRAMType;
        pc.MotherboardPCI = _motherboard.ActivePCIE;
        pc.MotherboardFormFactor = _motherboard.ActiveFormFactor;
        pc.RAMType = _ram.ActiveRAMType;
        pc.VideocardName = _videocard.Name;
        pc.VideocardPCIE = _videocard.ActivePCIE;
        pc.CaseName = _case.Name;
        pc.CaseFormFactor = _case.ActiveFormFactor;
        pc.PowerUnitName = _powerunit.Name;
        pc.PowerUnitWatt = _powerunit.Watt;
        pc.MarkText = MarksText.Text;
        await _database.SaveItemAsync(pc);
        await Navigation.PopAsync();
    }

    public async void Delete_button_Clicked(object sender, EventArgs e)
    {
        await _database.DeleteItemAsync(pc);
        await Navigation.PopAsync();
    }

}