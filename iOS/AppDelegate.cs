using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using ImageCircle.Forms.Plugin.iOS;
using Syncfusion.SfNumericTextBox.XForms.iOS;
using Syncfusion.SfNumericTextBox.iOS;

namespace BizDeducter.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {

            UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(43, 132, 211); //bar background
            UINavigationBar.Appearance.TintColor = UIColor.White; //Tint color of button items
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
                {
                    Font = UIFont.FromName("HelveticaNeue-Light", (nfloat)20f),
                    TextColor = UIColor.White
                });

            Xamarin.Forms.Forms.Init();
            Xamarin.FormsMaps.Init();
			new SfNumericTextBoxRenderer ();
            LoadApplication(new App());
            ImageCircleRenderer.Init();

			Xamarin.Forms.Forms.ViewInitialized += (object sender, Xamarin.Forms.ViewInitializedEventArgs e) => 
			{
				if(e.NativeView is SFNumericTextBox)
				{

					(e.NativeView as SFNumericTextBox).Layer.BorderWidth  = (nfloat) 1;
					(e.NativeView as SFNumericTextBox).Layer.BorderColor  = UIKit.UIColor.FromRGB(226,226,226).CGColor;
					(e.NativeView as SFNumericTextBox).Layer.CornerRadius = 4.0f;

				}
			} ;

            return base.FinishedLaunching(app, options);
        }
    }
}

