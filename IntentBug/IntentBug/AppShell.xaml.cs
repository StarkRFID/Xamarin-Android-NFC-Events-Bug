using IntentBug.ViewModels;
using IntentBug.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace IntentBug
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("scan", typeof(ScanPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("scan");
        }
    }
}
