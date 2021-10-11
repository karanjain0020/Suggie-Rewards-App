
﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


using RewardsApp_CrossPlatform.Models;
using RewardsApp_CrossPlatform;
using RewardsApp_CrossPlatform.Views;

namespace RewardsApp_CrossPlatform.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_Username.TextColor = Constants.MainTextColor;
            Lbl_Password.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
        }


        [Obsolete]
        async void SignInProcedure(object sender, System.EventArgs e)
        {

            if (Device.OS == TargetPlatform.Android)
            {
                Application.Current.MainPage = new MainPage();
            }
            else if (Device.OS == TargetPlatform.iOS)
            {
                await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
            }
         
        }
    }

}