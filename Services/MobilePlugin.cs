using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace SyncfusionSemanticKernelMaui.Services;

public class MobilePlugin
{
    [KernelFunction]
    [Description("Answer question about my device")]
    public static string AnswerQuestionAboutDevice()
    {
        return SearchDeviceInfo();
    }

    static string SearchDeviceInfo()
    {
        // Obteniendo información del dispositivo
        string model = DeviceInfo.Current.Model;
        string manufacturer = DeviceInfo.Current.Manufacturer;
        string osVersion = DeviceInfo.Current.VersionString;
        string platform = DeviceInfo.Current.Platform.ToString();
        string idiom = DeviceInfo.Current.Idiom.ToString();
        string deviceType = DeviceInfo.Current.DeviceType.ToString();
        string deviceName = DeviceInfo.Current.Name;
        string deviceInfo = $"Model: {model}\nManufacturer: {manufacturer}\nOS Version: {osVersion}\nPlatform: {platform}\nIdiom: {idiom}\nDevice Type: {deviceType}\nDevice Name: {deviceName}";
        return deviceInfo;
    }
}