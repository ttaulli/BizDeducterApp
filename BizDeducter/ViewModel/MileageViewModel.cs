using System;
using Xamarin.Forms;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;


namespace BizDeducter.ViewModel
{
	public class MileageViewModel : BaseViewModel
	{
		public MileageViewModel(Page page) : base(page)
		{
			Title = "Mileage";
			Subtitle = "Subtitle";
		}


		string total = string.Empty;

		/// <summary>
		/// Gets or sets the "Title" property
		/// </summary>
		/// <value>The title.</value>
		public string Total
		{
			get { return total; }
			set 
			{ 
				SetProperty(ref total, value, onChanged: () =>
					OnPropertyChanged("TotalDisplay")); 
			}

		}


		public string TotalDisplay
		{
			get 
			{ 
				double result = 0;
				double.TryParse(total, out result); 
				return result.ToString("C"); 
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

							var fortMasonPosition = new Position (position.Latitude, position.Longitude);
							var geoCoder = new Xamarin.Forms.Maps.Geocoder();
							var possibleAddresses = await geoCoder.GetAddressesForPositionAsync (fortMasonPosition);
							var l = string.Empty;
							foreach (var a in possibleAddresses){
								l += a + "\n";
							}

							await page.DisplayAlert("Addresses", l, "OK");
						}
						catch(Exception ex)
						{
							await page.DisplayAlert("Error", "Error", "OK");
						}

						Title = "Reports";
						IsBusy = false;
					}));
			}
		}

	}
}
