using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using RewardsApp_CrossPlatform.Models;
using RewardsApp_CrossPlatform.Views;
using Xamarin.Essentials;
using System.Windows.Input;

namespace RewardsApp_CrossPlatform.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        public User User { get; set; }
        public Command LoadUserCommand { get; set; }
        
        public AccountViewModel()
        {
            Title = "Account";
            // test user object with dummy values
            // Object definition is in models folder

            User = new User { Id = "1",User_Name="Test User", Cur_Points=200, All_Time_Points=245};


            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
            //NavigateCommand = new Command<Type>(
            //  async (Type pagetype) =>
            //  {
            //      Page page = (Page)Activator.CreateInstance(pagetype);
            //      await Navigation.PushAsync(page);
            //  });
            //  public ICommand NavigateCommand { private set; get; }
    }
        public ICommand OpenWebCommand { get; }
    }
}