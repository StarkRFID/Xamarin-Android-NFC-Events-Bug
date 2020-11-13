using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntentBug.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IntentBug.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanPage : ContentPage
    {
        public ScanPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // THIS METHOD IS ONLY EXECUTED WHEN THE PAGE LOADS, NEVER DURING NFC TAG READ

            Console.WriteLine("Scan Page OnAppearing");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            Console.WriteLine("Scan Page OnDisappearing");
        }
    }
}