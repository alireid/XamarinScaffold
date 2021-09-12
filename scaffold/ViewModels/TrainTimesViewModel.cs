using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace scaffold.ViewModels
{
    public class TrainTimesViewModel : BaseViewModel
    {
        public TrainTimesViewModel()
        {
            Title = "Read";
            //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
        }

        //public ICommand OpenWebCommand { get; }
    }
}