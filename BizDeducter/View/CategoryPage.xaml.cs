using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BizDeducter.ViewModel;
using BizDeducter.View.Expenses;
using BizDeducter.Helpers;

namespace BizDeducter.View
{
	public partial class CategoryPage : ContentPage
	{

		CategoriesViewModel viewModel;

		public Settings Settings
		{
			get { return Settings.Current; }
		}

		public string CurrentCategory
		{
			get { return Settings.CurrentCategory; }
			set
			{
				if (Settings.CurrentCategory == value)
					return;

				Settings.CurrentCategory = value;
				OnPropertyChanged();
			}
		}

		public CategoryPage ()
		{
			InitializeComponent ();

			BindingContext = viewModel = new CategoriesViewModel(this);


		}
	

		async void OnTap(object sender, ItemTappedEventArgs e)
		{

			CurrentCategory = e.Item.ToString ();
			await Navigation.PopAsync();

		}


		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (viewModel.Categories.Count == 0)
				viewModel.LoadCategoriesCommand.Execute(null);
		}
	
	}
}

