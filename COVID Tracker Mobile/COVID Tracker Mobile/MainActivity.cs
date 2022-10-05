using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.BottomNavigation;

namespace COVID_Tracker_Mobile
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.home);
            
            Button settingButton1 = FindViewById<Button>(Resource.Id.settingButton1);
            Button settingButton2 = FindViewById<Button>(Resource.Id.settingButton2);
            Button settingButton3 = FindViewById<Button>(Resource.Id.settingButton3);
            Button settingButton4 = FindViewById<Button>(Resource.Id.settingButton4);
            Button settingButton5 = FindViewById<Button>(Resource.Id.settingButton5);
            Button settingButton6 = FindViewById<Button>(Resource.Id.settingButton6);
            Button settingButton7 = FindViewById<Button>(Resource.Id.settingButton7);
            Button settingButton8 = FindViewById<Button>(Resource.Id.settingButton8);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    SetContentView(Resource.Layout.home);
                    return true;
                case Resource.Id.navigation_dashboard:
                    SetContentView(Resource.Layout.datasets);
                    return true;
                case Resource.Id.navigation_notifications:
                    SetContentView(Resource.Layout.settings);
                    return true;
            }
            return false;
        }
    }
}

