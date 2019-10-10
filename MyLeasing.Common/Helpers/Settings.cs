using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MyLeasing.Common.Helpers
{
    public static class Settings
    {
        private const string _propertyImages = "PropertyImages";
        private static readonly string _settingsDefault = string.Empty;

        private static ISettings AppSettings => CrossSettings.Current;

        public static string PropertyImages
        {
            get => AppSettings.GetValueOrDefault(_propertyImages, _settingsDefault);
            set => AppSettings.AddOrUpdateValue(_propertyImages, value);
        }
    }
}

