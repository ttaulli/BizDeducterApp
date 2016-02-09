using System;
using System.Collections.Generic;
using BizDeducter.Model;
using Xamarin.Forms;
using System.Threading.Tasks;
using Xamarin;
using Plugin.Geolocator;
using Plugin.Settings;
using Xamarin.Forms.Maps;

using System.Windows.Input;
using System.ComponentModel;

using System.Net.Http;
using System.Globalization;
using Newtonsoft.Json;

namespace BizDeducter.ViewModel
{
	public class NewMileageViewModel : BaseViewModel
	{






		public Expense Expense { get; set; }


		public double deg2rad (double deg) {
			return (deg * Math.PI / 180.0);
		}


		public string Start
		{
			get { return Settings.Start; }
			set
			{
				if (Settings.Start == value)
					return;

				Settings.Start = value;
				OnPropertyChanged();
			}
		}


		public double StartLat
		{
			get { return Settings.StartLat; }
			set
			{
				if (Settings.StartLat == value)
					return;

				Settings.StartLat = value;
				OnPropertyChanged();
			}
		}


		public double StartLong
		{
			get { return Settings.StartLong; }
			set
			{
				if (Settings.StartLong == value)
					return;

				Settings.StartLong = value;
				OnPropertyChanged();
			}
		}




		public string Stop
		{
			get { return Settings.Stop; }
			set
			{
				if (Settings.Stop == value)
					return;

				Settings.Stop = value;
				OnPropertyChanged();
			}
		}

		public double StopLat
		{
			get { return Settings.StopLat; }
			set
			{
				if (Settings.StopLat == value)
					return;

				Settings.StopLat = value;
				OnPropertyChanged();
			}
		}

		public double StopLong
		{
			get { return Settings.StopLong; }
			set
			{
				if (Settings.StopLong == value)
					return;

				Settings.StopLong = value;
				OnPropertyChanged();
			}
		}



		public string MilesString
		{
			get { return Settings.MilesString; }
			set
			{
				if (Settings.MilesString == value)
					return;

				Settings.MilesString = value;
				OnPropertyChanged();
			}
		}



		public bool GetRoundTrip
		{
			get { return Settings.GetRoundTrip; }
			set
			{
				if (Settings.GetRoundTrip == value)
					return;

				Settings.GetRoundTrip = value;
				OnPropertyChanged();
			}
		}









		public NewMileageViewModel (Page page, Expense expense = null) : base(page)
		{

			if (expense == null)
			{
				Expense = new Expense();
				Title = "Mileage";
			}
			else
			{
				Title = "Mileage";
			}




		}

	
		Command saveExpenseCommand;
		public Command SaveExpenseCommand
		{
			get 
			{
				return saveExpenseCommand ?? 
					(saveExpenseCommand = new Command(async () => 
						await ExecuteSaveExpense())); 
			}
		}

		async Task ExecuteSaveExpense()
		{
			if (IsBusy)
				return;

			try
			{
				IsBusy = true;
				Expense.IsMileage = true;

				Expense.StartString = Start;
				Expense.StartLatitude = StartLat;
				Expense.StartLongitude = StartLat;
				Expense.StopString = Stop;
				Expense.StopLatitude = StopLat;
				Expense.StopLongitude = StopLat;
			
				Expense.RoundTrip = GetRoundTrip;

				//probably do some validation here before saving;

				await Expense.Save();

				MessagingCenter.Send<Expense>(Expense, "UpdateExpense");

				await page.DisplayAlert("Expense Saved", "Successfully saved", "OK");

				Start = "No start location set yet";
				StartLat = 0;
				StartLat = 0;
				Stop = "No end location set yet";
				StopLat = 0;
				StopLat = 0;
				GetRoundTrip = false;
				MilesString = "0 miles";



				await page.Navigation.PopAsync();
			}
			catch(Exception ex)
			{
				ex.Data["info"] = "ExecuteSaveExpense";
				Insights.Report(ex);
				await page.DisplayAlert("Error", "Unable to save expense, please try again.", "OK");
			}
			finally
			{
				IsBusy = false;
			}
		}


		Command getGPSCommand;
		public Command GetGPSCommand
		{
			get
			{
				return getGPSCommand ?? (getGPSCommand = new Command(async (v)=>
					{
						Title = "Getting Location";
						IsBusy = true;
						try
						{
							var position = await CrossGeolocator.Current.GetPositionAsync(10000);

							await page.DisplayAlert("Got GPS", $"Lat {position.Latitude} Long {position.Longitude}", "OK");

							StartLat = position.Latitude;
							StartLong = position.Longitude;

							var fortMasonPosition = new Position (position.Latitude, position.Longitude);
							var geoCoder = new Xamarin.Forms.Maps.Geocoder();
							var possibleAddresses = await geoCoder.GetAddressesForPositionAsync (fortMasonPosition);
							var l = string.Empty;
							foreach (var a in possibleAddresses){
								l += a + "\n";
							}

							await page.DisplayAlert("Addresses", l, "OK");
							Start = l;

						}
						catch(Exception ex)
						{
							
						}

						Title = "Mileage";
						IsBusy = false;
					}));
			}
		}


		Command getGPSCommandStop;
		public Command GetGPSCommandStop
		{
			get
			{
				return getGPSCommandStop ?? (getGPSCommandStop = new Command(async (v)=>
					{
						Title = "Getting Location";
						IsBusy = true;
						try
						{
							var position = await CrossGeolocator.Current.GetPositionAsync(10000);

							await page.DisplayAlert("Got GPS", $"Lat {position.Latitude} Long {position.Longitude}", "OK");

							StopLat = position.Latitude;
							StopLong = position.Longitude;

							var fortMasonPosition = new Position (position.Latitude, position.Longitude);
							var geoCoder = new Xamarin.Forms.Maps.Geocoder();
							var possibleAddresses = await geoCoder.GetAddressesForPositionAsync (fortMasonPosition);
							var l = string.Empty;
							foreach (var a in possibleAddresses){
								l += a + "\n";
							}

							await page.DisplayAlert("Addresses", l, "OK");
							Stop = l;
						
							double oLat = StartLat;
							double oLong = StartLong;
							double dLat = StopLat;
							double dLong = StopLong;

							using(var client = new HttpClient())
							{


								//you will have doubles and Invariant culture is very important so they are always . and not , for decimals
								var finalOLat = oLat.ToString(CultureInfo.InvariantCulture);
								var finalOLong = oLong.ToString(CultureInfo.InvariantCulture);
								var finalDLat = dLat.ToString(CultureInfo.InvariantCulture);
								var finalDLong = dLong.ToString(CultureInfo.InvariantCulture);

								//make sure you register for your own key
								var key = "AIzaSyBj-0KuIUut7p928Oz22y95PplLOwBI94Q";
								var api = string.Format("https://maps.googleapis.com/maps/api/distancematrix/json?origins={0},{1}&destinations={2},{3}&language=en&units=imperial&key={4}",
									finalOLat, finalOLong, finalDLat, finalDLong, key);

								var json = await client.GetStringAsync(api);

								var item = JsonConvert.DeserializeObject<DistanceCalculation>(json);


								char[] MyChar = {'m','i',' '};
								string NewString = item?.Rows?[0]?.Elements?[0].Distance?.Text.TrimEnd(MyChar);

								Expense.Miles = Convert.ToDouble(NewString);
							

								MilesString = string.Format("{0:0.##}", Expense.Miles);



								if (MilesString == "1") {
									MilesString = MilesString + " Mile";
								} else {

									MilesString = MilesString + " Miles";
								}

									
									
							}
							







						
						}
						catch(Exception ex)
						{
							
						}

						Title = "Mileage";
						IsBusy = false;
					}));
			}
		}


	}
}






