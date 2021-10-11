using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;

namespace RewardsApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MapActivity : AppCompatActivity
    {
        // hey guys this is a comment I just made
        // This is Tyler's Comment
        // Karan here
        // Sup guys - Andrew's comment 
        // GFirst-unctio
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Console.Write("Bruh wtf");
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.map_layout);
        }
        
    }
}

