using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Internal;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using RewardsApp.Adapters;
using RewardsApp.Fragments;
namespace RewardsApp


// Source for much of this code was https://stackoverflow.com/questions/54416342/xamarin-android-bottom-navigation-not-displaying-on-all-screens
// Also a more detailed tutorial https://intelliabb.com/2017/12/02/tutorial-bottomnavigationview-and-viewpager-in-xamarin-android/
// Lastly the Github link for above tutorial https://github.com/hnabbasi/BottomNavigationViewPager

{
    // Support.v4 is used because we are working with fragments
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Android.Support.V4.App.FragmentActivity
    {
       
        ViewPager _viewPager;
        BottomNavigationView _navigationView;

        Android.Support.V4.App.Fragment[] _fragments;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            //creates instances of each fragment layout
            InitializeTabs();

            _viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            _viewPager.PageSelected += ViewPager_PageSelected;
            _viewPager.Adapter = new ViewPagerAdapter(SupportFragmentManager, _fragments);

            _navigationView = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            RemoveShiftMode(_navigationView);
            _navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;
        }

        void InitializeTabs() => _fragments = new Android.Support.V4.App.Fragment[]
            {
                RewardsFragment.NewInstance(),
                AccountFragment.NewInstance(),
                MapFragment.NewInstance()
            };

        // methods for switching between pages
        private void ViewPager_PageSelected(object sender, ViewPager.PageSelectedEventArgs e)
        {
            var item = _navigationView.Menu.GetItem(e.Position);
            _navigationView.SelectedItemId = item.ItemId;
        }

        void NavigationView_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            _viewPager.SetCurrentItem(e.Item.Order, true);
        }

        // This method replaces the switch statement for the navigation bar which was previously here
        // This method also allows for more than 3 tabs to be shown, could be useful in the future
        void RemoveShiftMode(BottomNavigationView view)
        {

            var menuView = (BottomNavigationMenuView)view.GetChildAt(0);

            try
            {
                var shiftingMode = menuView.Class.GetDeclaredField("mShiftingMode");
                shiftingMode.Accessible = true;
                shiftingMode.SetBoolean(menuView, false);
                shiftingMode.Accessible = false;

                for (int i = 0; i < menuView.ChildCount; i++)
                {
                    var item = (BottomNavigationItemView)menuView.GetChildAt(i);
                    item.SetShifting(true);
                    // set once again checked value, so view will be updated
                    item.SetChecked(item.ItemData.IsChecked);
                }
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine((ex.InnerException ?? ex).Message);
            }
        }

        protected override void OnDestroy()
        {
            _viewPager.PageSelected -= ViewPager_PageSelected;
            _navigationView.NavigationItemSelected -= NavigationView_NavigationItemSelected;
            base.OnDestroy();
        }
    }
}

