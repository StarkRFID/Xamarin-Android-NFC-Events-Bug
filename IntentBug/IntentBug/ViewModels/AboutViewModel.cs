using System.Windows.Input;
using Xamarin.Forms;

namespace IntentBug.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenScanPage = new Command(async () => await Shell.Current.GoToAsync("scan"));
        }

        public ICommand OpenScanPage { get; }
    }
}