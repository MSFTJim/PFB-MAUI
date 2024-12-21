namespace PFBv01
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            SetDynamicTitle();
        }

        private void SetDynamicTitle()
        {
            MainPageShellContent.Title = "Pico Fermi Bagel";
        }
    }
}
