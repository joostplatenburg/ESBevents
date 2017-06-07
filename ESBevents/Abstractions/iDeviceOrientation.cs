using System;
namespace ESBevents.Abstractions
{
    public enum DeviceOrientations
    {
        Undifined,
        Landscape,
        Portrait
    }

    public interface IDeviceOrientation
    {
        DeviceOrientations GetOrientation();
    }
}
