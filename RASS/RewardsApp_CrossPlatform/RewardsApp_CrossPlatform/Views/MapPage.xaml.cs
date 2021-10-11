using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Map = Xamarin.Forms.Maps.Map;
using RewardsApp_CrossPlatform.ViewModels;

namespace RewardsApp_CrossPlatform.Views
{
    [DesignTimeVisible(false)]
    public partial class MapPage : ContentPage
    {
        MapViewModel viewModel;
        Position ss_location_f = new Position(41.140360, -73.257160);
        Position ss_location_w = new Position(41.121288, -73.370117);
        public MapPage()
        {
            InitializeComponent();
            SetPosition(ss_location_f);
            AddPin(ss_location_f, "Saugatuck Sweets", "28 Reef Rd, Fairfield, CT 06824");
            AddPin(ss_location_w, "Saugatuck Sweets", "575 Riverside Ave, Westport, CT 06880");

            BindingContext = viewModel = new MapViewModel();

        }
        public void SetPosition(Position position)
        {
            MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);
            map.MoveToRegion(mapSpan);
        }
        public void AddPin(Position position, String label, String address)
        {
            Pin pin = new Pin
            {
                Position = position,
                Label = label,
                Type = PinType.Place,
                Address = address
            };
            map.Pins.Add(pin);
        }
        async void OnWestportClicked (Object sender, EventArgs args)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                await Launcher.OpenAsync("http://maps.apple.com/?q=28+Reef+Rd+Fairfield+CA");
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                await Launcher.OpenAsync("geo:0,0?q=575+Riverside+Ave+Westport+CT");
            }
        }
        async void OnFairfieldClicked(Object sender, EventArgs args)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                await Launcher.OpenAsync("http://maps.apple.com/?q=28+Reef+Rd+Fairfield+CA");
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                await Launcher.OpenAsync("geo:0,0?q=28+Reef+Rd+Fairfield+CT");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {

        }
    }
}   