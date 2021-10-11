
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TestProjectXamarin.Models;

namespace TestProjectXamarin.Views
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
            BackgroundColor = Contants.BackgroundColor;
            Lbl_Username.TextColor = Contants.MainTextColor;
            Lbl_Password.TextColor = Contants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Contants.LoginIconHeight;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);


        }

        async void SignInProcedure(object sender, System.EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if (user.CheckInformation())
            {
                await DisplayAlert("Login", "Login Success", "Okay");
                var result = await App.RestService.Login(user);
                if (result.access_token != null)
                {
                    App.UserDatabase.SaveUser(user);

                }
                else
                {
                    await DisplayAlert("Login", "Login Not Correct, empty username or password.", "Oke");
                }
            }
        }
    }

}