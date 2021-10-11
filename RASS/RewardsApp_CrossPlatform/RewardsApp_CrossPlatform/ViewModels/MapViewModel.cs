using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RewardsApp_CrossPlatform.ViewModels
{
    public class MapViewModel : BaseViewModel
    {
        public MapViewModel()
        {
            Title = "Map";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
        }

        public ICommand OpenWebCommand { get; }
    }
}