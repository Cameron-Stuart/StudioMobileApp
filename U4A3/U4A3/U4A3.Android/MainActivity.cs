using System;

using Android.App;
using Android.Content.PM;
using Android.Util;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace U4A3.Droid
{
    [Activity(Label = "U4A3", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			// get the accent color from your theme
			var themeAccentColor = new TypedValue();
			this.Theme.ResolveAttribute(Resource.Attribute.colorAccent, themeAccentColor, true);
			var droidAccentColor = new Android.Graphics.Color(themeAccentColor.Data);

			// set Xamarin Color.Accent to match the theme's accent color
			var accentColorProp = typeof(Xamarin.Forms.Color).GetProperty(nameof(Xamarin.Forms.Color.Accent), System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
			var xamarinAccentColor = new Xamarin.Forms.Color(30, 144, 255, 255);
			accentColorProp.SetValue(null, xamarinAccentColor, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static, null, null, System.Globalization.CultureInfo.CurrentCulture);

			LoadApplication(new App());
		}
    }
}

