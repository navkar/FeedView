using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace App1.UXTest
{
    public class AppInitializer
    {
        private const string PATH = @"C:\Users\JWK8HKX\AppData\Local\Xamarin\Mono for Android\Archives\2018-12-26\App1.Android 12-26-18 1.08 PM.apkarchive\";
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.ApkFile(PATH + "com.companyname.App1.apk").StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}