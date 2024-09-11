namespace PCAssembly
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnButtonCliked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.PCConfig());
        }
    }
}
