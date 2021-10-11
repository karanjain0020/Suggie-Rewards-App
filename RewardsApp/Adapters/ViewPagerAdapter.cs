using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace RewardsApp.Adapters
{
    public class ViewPagerAdapter : FragmentPagerAdapter
    {
        Android.Support.V4.App.Fragment[] _fragments;

        public ViewPagerAdapter(Android.Support.V4.App.FragmentManager fm, Android.Support.V4.App.Fragment[] fragments) : base(fm)
        {
            _fragments = fragments;
        }

        public override int Count => _fragments.Length;

        public override Android.Support.V4.App.Fragment GetItem(int position) => _fragments[position];
    }
}