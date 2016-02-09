using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BizDeducter.ViewModel;
using BizDeducter.View.Expenses;
	

namespace BizDeducter.View
{
    public partial class HomePage : ContentPage
    {
       
		HomeViewModel viewModel;

		public HomePage()
        {
            InitializeComponent();
			BindingContext = viewModel = new HomeViewModel(this);

			ButtonDeduction.Clicked += async (sender, e) => 
				await Navigation.PushAsync (new OtherExpensePage ());

			ButtonReports.Clicked += async (sender, e) => 
				await Navigation.PushAsync (new ReportsPage ());

			ButtonMileage.Clicked += async (sender, e) => 
				await Navigation.PushAsync (new MileageExpensePage ());

			ButtonTaxServices.Clicked += async (sender, e) => 
				await Navigation.PushAsync (new TaxServicesPage ());

        }



		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (viewModel.Expenses.Count == 0 || viewModel.IsDirty)
				viewModel.LoadExpensesCommand.Execute(null);

		}
			
    }
}


