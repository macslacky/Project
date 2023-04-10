using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplashScreenX.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme.Splash", Icon = "@drawable/splash_logo", MainLauncher = true, NoHistory = true)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            // performs boot initialization
            base.OnCreate(savedInstanceState);
            // provides a cross-platform API
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // create a window in which to place the user interface
            SetContentView(Resource.Layout.activity_splash_screen);
        }

        protected override void OnResume()
        {
            // the activity is ready to start interacting with the user
            base.OnResume();
            // creation of the task object to manage an asynchronous method
            Task startupWork = new Task(() => { SimulateStartUp(); });
            startupWork.Start();
        }

        async void SimulateStartUp()
        {
            // stops the method for a defined time
            await Task.Delay(2000);
            // start a new activity
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}