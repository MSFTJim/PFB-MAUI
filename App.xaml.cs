namespace PFBv01
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NMaF5cXmBCf0x0RHxbf1x1ZFRHal1TTnJWUiweQnxTdEBjWH5acXVURGRVWUNwVg==");
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());            
        }
    }
}