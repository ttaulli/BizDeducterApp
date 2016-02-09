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

	

		const string StartKey = "start_key";
		readonly string StartDefault = "No start location set yet";
		public string Start 
		{
			get { return AppSettings.GetValueOrDefault<string>(StartKey, StartDefault); }
			set
			{
				if (AppSettings.AddOrUpdateValue(StartKey, value))
					OnPropertyChanged();
			}
		}

		const string StartLatKey = "start_lat_key";
		readonly double StartLatDefault = 0;
		public double StartLat
		{
			get { return AppSettings.GetValueOrDefault<double>(StartLatKey, StartLatDefault); }
			set
			{
				if (AppSettings.AddOrUpdateValue(StartLatKey, value))
					OnPropertyChanged();
			}
		}

		const string StartLongKey = "start_long_key";
		readonly double StartLongDefault = 0;
		public double StartLong
		{
			get { return AppSettings.GetValueOrDefault<double>(StartLongKey, StartLongDefault); }
			set
			{
				if (AppSettings.AddOrUpdateValue(StartLongKey, value))
					OnPropertyChanged();
			}
		}


		const string StopKey = "stop_key";
		readonly string StopDefault = "No end location set yet";
		public string Stop 
		{
			get { return AppSettings.GetValueOrDefault<string>(StopKey, StopDefault); }
			set
			{
				if (AppSettings.AddOrUpdateValue(StopKey, value))
					OnPropertyChanged();
			}
		}

		const string StopLatKey = "stop_lat_key";
		readonly double StopLatDefault = 0;
		public double StopLat
		{
			get { return AppSettings.GetValueOrDefault<double>(StopLatKey, StopLatDefault); }
			set
			{
				if (AppSettings.AddOrUpdateValue(StopLatKey, value))
					OnPropertyChanged();
			}
		}

		const string StopLongKey = "stop_long_key";
		readonly double StopLongDefault = 0;
		public double StopLong
		{
			get { return AppSettings.GetValueOrDefault<double>(StopLongKey, StopLongDefault); }
			set
			{
				if (AppSettings.AddOrUpdateValue(StopLongKey, value))
					OnPropertyChanged();
			}
		}



		const string MilesStringKey = "miles_string_key";
		readonly string MilesStringDefault = "0 Miles";
		public string MilesString 
		{
			get { return AppSettings.GetValueOrDefault<string>(MilesStringKey, MilesStringDefault); }
			set
			{
				if (AppSettings.AddOrUpdateValue(MilesStringKey, value))
					OnPropertyChanged();
			}
		}


		const string GetRoundTripKey = "get_round_trip_key";
		readonly bool GetRoundTripDefault = false;
		public bool GetRoundTrip 
		{
			get { return AppSettings.GetValueOrDefault<bool>(GetRoundTripKey, GetRoundTripDefault); }
			set
			{
				if (AppSettings.AddOrUpdateValue(GetRoundTripKey, value))
					OnPropertyChanged();
			}
		}


		const string CategoriesPreloadedKey = "categories_preloaded_key";
		readonly bool CategoriesPreloadedDefault = false;
		public bool CategoriesPreloaded 
		{
			get { return AppSettings.GetValueOrDefault<bool>(CategoriesPreloadedKey, CategoriesPreloadedDefault); }
			set
			{
				if (AppSettings.AddOrUpdateValue(CategoriesPreloadedKey, value))
					OnPropertyChanged();
			}
		}

		const string CurrentCategoryKey = "current_category_key";
		readonly string CurrentCategoryDefault = "Miscellaneous";
		public string CurrentCategory 
		{
			get { return AppSettings.GetValueOrDefault<string>(CurrentCategoryKey, CurrentCategoryDefault); }
			set
			{
				if (AppSettings.AddOrUpdateValue(CurrentCategoryKey, value))
					OnPropertyChanged();
			}
		}

        public bool IsLoggedIn => !string.IsNullOrWhiteSpace(Email);


    }
}