using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using RewardsApp_CrossPlatform.Models;
using RewardsApp_CrossPlatform.Views;
using RewardsApp_CrossPlatform.ViewModels;

namespace RewardsApp_CrossPlatform.Views
{
    [DesignTimeVisible(false)]
    public partial class AccountPage : ContentPage
    {
        AccountViewModel viewModel;
        public AccountPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AccountViewModel();
        }
    }
}