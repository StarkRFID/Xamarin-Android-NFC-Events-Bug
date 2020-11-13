using IntentBug.Views;
using System;
using Xamarin.Forms;

namespace IntentBug
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("scan", typeof(ScanPage));
            Routing.RegisterRoute("another", typeof(AnotherScanPage));
        }
    }
}
