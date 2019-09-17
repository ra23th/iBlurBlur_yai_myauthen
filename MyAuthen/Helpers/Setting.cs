using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MyAuthen.Helpers
{
    public class Setting
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static string UserName 
        {
            get => AppSettings.GetValueOrDefault(nameof(UserName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserName), value);
        }

        public static string Password
        {
            get => AppSettings.GetValueOrDefault(nameof(Password), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Password), value);
        }
    }
}
