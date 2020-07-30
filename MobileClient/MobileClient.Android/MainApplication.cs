using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using MobileClient.Extensions;
using Plugin.FirebasePushNotification;
using Xamarin.Forms;
using Application = Android.App.Application;

namespace MobileClient.Droid
{
    [Application(Icon= "@drawable/icon")]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            //Set the default notification channel for your app when running Android Oreo
            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                //Change for your default notification channel id here
                FirebasePushNotificationManager.DefaultNotificationChannelId = "global";

                //Change for your default notification channel name here
                FirebasePushNotificationManager.DefaultNotificationChannelName = "global";
            }


            //If debug you should reset the token each time.
            #if DEBUG
             FirebasePushNotificationManager.Initialize(this ,true);
            #else
             FirebasePushNotificationManager.Initialize(this, false);
            #endif
        }
    }
}