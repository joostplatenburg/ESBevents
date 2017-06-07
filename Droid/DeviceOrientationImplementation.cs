using System;
using Android.Content;
using Android.Runtime;
using Android.Views;
using ESBevents.Abstractions;
using ESBevents.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceOrientationImplementation))]
namespace ESBevents.Droid
{
    public class DeviceOrientationImplementation : IDeviceOrientation
    {
        public DeviceOrientationImplementation() { }

		public static void Init() { }

		public DeviceOrientations GetOrientation()
		{
			IWindowManager windowManager = Android.App.Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();

			var rotation = windowManager.DefaultDisplay.Rotation;
			bool isLandscape = rotation == SurfaceOrientation.Rotation90 || rotation == SurfaceOrientation.Rotation270;
			return isLandscape ? DeviceOrientations.Landscape : DeviceOrientations.Portrait;
		}
	}
}
