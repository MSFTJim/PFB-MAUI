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
            // Example: Set the title with a build number or date-time stamp
            string buildNumber = "1.0.0"; // Replace with your actual build number
            string dateTimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //MainPageShellContent.Title = $"Pico Fermi Bagel - Build {buildNumber} - {dateTimeStamp}";
            MainPageShellContent.Title = $"Pico Fermi Bagel - Build {buildNumber}";
        }
    }
}
