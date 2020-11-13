using System;
using Xamarin.Forms;

namespace IntentBug.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // THIS METHOD IS EXECUTED WHEN SCANNING A TAG, EVEN IF ScanPage IS THE PAGE BEING VIEWED

            Console.WriteLine("About Page OnAppearing");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            Console.WriteLine("About Page OnDisappearing");
        }
    }
}