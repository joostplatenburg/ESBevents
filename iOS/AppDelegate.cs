﻿using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace ESBevents.iOS
{
	[Register("AppDelegate")]
	public class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
		{
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());

            App.ScreenWidth = (int)UIScreen.MainScreen.Bounds.Width;
            App.ScreenHeight = (int)UIScreen.MainScreen.Bounds.Height;

            return base.FinishedLaunching(uiApplication, launchOptions);
		}
	}
}
