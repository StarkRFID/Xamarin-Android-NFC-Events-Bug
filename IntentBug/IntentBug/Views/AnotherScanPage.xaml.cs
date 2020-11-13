using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IntentBug.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnotherScanPage : ContentPage
    {
        public AnotherScanPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // THIS METHOD IS ONLY EXECUTED WHEN THE PAGE LOADS, NEVER DURING NFC TAG READ

            Console.WriteLine("Another Scan Page OnAppearing");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            Console.WriteLine("Another Scan Page OnDisappearing");
        }
    }
}