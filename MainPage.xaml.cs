using Microsoft.Maui.Controls;
using PCAssembly.src.db;
using PCAssembly.src.db.Models;
using System.Collections.ObjectModel;

namespace PCAssembly
{
    public partial class MainPage : ContentPage
    {
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

        private void OnButtonCliked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.PCConfig());
        }
        private async void UpdateColView()
        {
            var db = new Database();
            ObservableCollection<PC> pcList = new ObservableCollection<PC>(await db.GetItemsAsync());
            colView.ItemsSource = pcList;
            colView.ItemTemplate = new DataTemplate(() =>
            {
                var configNameLabel = new Label();
                configNameLabel.SetBinding(Label.TextProperty, "Name");

                return new StackLayout {
                Children = {configNameLabel} 
                };
            });
        }

        private void btnItem_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var pcName = button.Text as string;

        }
    }
}
