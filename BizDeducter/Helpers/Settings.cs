// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using BizDeducter.ViewModel;

namespace BizDeducter.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public class Settings : BaseViewModel
    {
        
        static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        static Settings settings;

        public static Settings Current
        {
            get { return settings ?? (settings = new Settings()); }
        }

        const string EmailKey = "email_key";
        readonly string EmailDefault = string.Empty;
        public string Email 
        {
            get { return AppSettings.GetValueOrDefault<string>(EmailKey, EmailDefault); }
            set
            {
                if (AppSettings.AddOrUpdateValue(EmailKey, value))
                    OnPropertyChanged();
            }
        }

        public bool IsLoggedIn => !string.IsNullOrWhiteSpace(Email);


    }
}