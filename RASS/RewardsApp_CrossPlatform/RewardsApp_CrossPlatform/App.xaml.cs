using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RewardsApp_CrossPlatform.Services;
using RewardsApp_CrossPlatform.Views;
using RewardsApp_CrossPlatform.Data;

namespace RewardsApp_CrossPlatform
{
    public partial class App : Application
    {
        


        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();


        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }


    }
}
