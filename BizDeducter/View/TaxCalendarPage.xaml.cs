using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BizDeducter.ViewModel;
using BizDeducter.Model;



namespace BizDeducter.View
{
	public partial class TaxCalendarPage : ContentPage
	{
		public TaxCalendarPage ()
		{
			InitializeComponent ();


			CalendarListView.ItemsSource = new List<Calendar> {

				new Calendar {
					ListDate = "January 15th",
					ListDetail = "Final estimated tax payment for 2015"
				},
				new Calendar {
					ListDate = "March 15th",
					ListDetail = "Form 1120 C-Corp return"
				},
				new Calendar {
					ListDate = "March 15th",
					ListDetail = "Form 1120S S-Corp return"
				},
				new Calendar {
					ListDate = "March 15th",
					ListDetail = "S-Corp status election/Form 2553"
				},
				new Calendar {
					ListDate = "April 18th",
					ListDetail = "Form 1040 individual return"
				},
				new Calendar {
					ListDate = "April 18th",
					ListDetail = "6-month extension Form 4868"
				},
				new Calendar {
					ListDate = "April 18th",
					ListDetail = "First estimated tax installment"
				},
				new Calendar {
					ListDate = "April 18th",
					ListDetail = "Form 1065 partnership return"
				},
				new Calendar {
					ListDate = "June 15th",
					ListDetail = "Second estimated tax installment"
				},
				new Calendar {
					ListDate = "September 15th",
					ListDetail = "Third estimated tax installment"
				},
				new Calendar {
					ListDate = "September 15th",
					ListDetail = "Form 1120, if extension filed"
				},
				new Calendar {
					ListDate = "September 15th",
					ListDetail = "Form 1120S, if extension filed"
				},
				new Calendar {
					ListDate = "September 15th",
					ListDetail = "Form 1065, if extension filed"
				},
				new Calendar {
					ListDate = "October 17th",
					ListDetail = "Form 1040, if extension filed"
				}


			};

			CalendarListView.ItemSelected += (sender, e) => {
				((ListView)sender).SelectedItem = null;	
			};

		}




	}
}

