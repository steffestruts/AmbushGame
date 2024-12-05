using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;

namespace AmbushGame
{
    [Activity(Label = "Credit")]
    public class Credit : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Credit);
            TextView appName = FindViewById<TextView>(Resource.Id.textViewAppName);
            TextView versionName = FindViewById<TextView>(Resource.Id.textViewVersionName);
            appName.Text = ApplicationInfo.LoadLabel(PackageManager);
            versionName.Text = Application.Context.PackageManager.GetPackageInfo(Application.Context.PackageName, PackageInfoFlags.MetaData).VersionName.ToString();
            //leaderboard.Adapter = new ArrayAdapter<int>(this, Android.Resource.Layout.SimpleListItem1, _player);
        }
    }
}