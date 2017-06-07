using System;
using ESBevents.Abstractions;
using ESBevents.iOS;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceOrientationImplementation))]
namespace ESBevents.iOS
{
    public class DeviceOrientationImplementation : IDeviceOrientation
    {
        public DeviceOrientationImplementation()
        {
        }

		public DeviceOrientations GetOrientation()
		{
			var currentOrientation = UIApplication.SharedApplication.StatusBarOrientation;
			bool isPortrait = currentOrientation == UIInterfaceOrientation.Portrait
				|| currentOrientation == UIInterfaceOrientation.PortraitUpsideDown;

			return isPortrait ? DeviceOrientations.Portrait : DeviceOrientations.Landscape;
		}
	}
}
