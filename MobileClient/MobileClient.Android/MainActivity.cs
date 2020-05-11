using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;

namespace MobileClient.Droid
{
    [Activity(Label = "Survey App", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait,
        LaunchMode = LaunchMode.SingleInstance)]
    [IntentFilter(new[] { Intent.ActionView },
        Categories = new[]
        {
            Intent.CategoryDefault,
            Intent.CategoryBrowsable
        },
        DataScheme = "https",
        DataHost = "server20200331200409.azurewebsites.net",
        DataPathPrefix = "/",
        AutoVerify = true
        )
    ]

    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            // HERE
#if DEBUG
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
#endif
            global::Xamarin.Forms.Forms.SetFlags("SwipeView_Experimental");
            UserDialogs.Init(this);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}