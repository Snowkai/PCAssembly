using Microsoft.Maui.Controls;
using PCAssembly.src.db;
using PCAssembly.src.db.Models;
using System.Collections.ObjectModel;

namespace PCAssembly
{
    public partial class MainPage : ContentPage
    {
        private List<PC> PCConfigList;
        public MainPage()
        {
            InitializeComponent();   
            UpdateColView();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var db = new Database();
            // Обновите данные здесь
            colView.ItemsSource = await db.GetItemsAsync();
        }

        private async void OnButtonCliked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.PCConfig());
        }
        private async void UpdateColView()
        {
            var db = new Database();
            ObservableCollection<PC> pcList = new ObservableCollection<PC>(await db.GetItemsAsync());
            colView.ItemsSource = pcList;
            colView.ItemTemplate = new DataTemplate(() =>
            {
                var configButton = new Button();
                configButton.BindingContextChanged += (sender, args) =>
                {
                    var button = sender as Button;
                    var item = button?.BindingContext as PC;
                    button.Text = CreateString(item);
                };
                configButton.Clicked += btnItem_Clicked;

                return new StackLayout {
                Children = {configButton} 
                };
            });
        }

        private async void btnItem_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var item = button?.BindingContext as PC;
            await Navigation.PushAsync(new Pages.PCConfig(item));
        }

        private string CreateString(PC item)
        {
            return $"Config name: {item.Name}\nCPU: {item.CPUName} Motherboard: {item.MotherboardName} RAM: {item.RAMName}"; ;
        }
    }
}
