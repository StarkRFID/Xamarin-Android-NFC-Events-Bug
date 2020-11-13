using System.Windows.Input;
using Xamarin.Forms;

namespace IntentBug.ViewModels
{
    public class ScanViewModel : BaseViewModel
    {
        public ScanViewModel()
        {
            Title = "Scan";
            OpenScanPage = new Command(async () => await Shell.Current.GoToAsync("another"));
        }

        public ICommand OpenScanPage { get; }
    }
}