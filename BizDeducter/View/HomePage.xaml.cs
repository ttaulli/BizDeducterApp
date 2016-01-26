using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BizDeducter.ViewModel;
using BizDeducter.View.Expenses;

namespace BizDeducter.View
{
    public partial class HomePage : ContentPage
    {
        
		public HomePage()
        {
            InitializeComponent();
			BindingContext = new HomeViewModel(this);

			ButtonDeduction.Clicked += async (sender, e) => 
				await Navigation.PushAsync (new OtherExpensePage ());

			ButtonReports.Clicked += async (sender, e) => 
				await Navigation.PushAsync (new ReportsPage ());

			ButtonTaxServices.Clicked += async (sender, e) => 
				await Navigation.PushAsync (new TaxServicesPage ());



        }




    }
}

