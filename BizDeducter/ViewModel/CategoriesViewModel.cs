using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using BizDeducter.Model;
using System.Collections.ObjectModel;
using BizDeducter.Database;
using Xamarin;

namespace BizDeducter.ViewModel
{
	public class CategoriesViewModel : BaseViewModel
	{

		public bool IsDirty { get; set; }



		public CategoriesViewModel (Page page) : base(page)
		{

			Title = "Expenses";
			Subtitle = "Subtitle";


			categories = new ObservableCollection<Category>();


		}
	
	


		ObservableCollection<Category> categories;
		public ObservableCollection<Category> Categories
		{
			get { return categories; }
			set
			{
				categories = value;
				OnPropertyChanged();
			}
		}



		Command loadCategoriesCommand;
		public Command LoadCategoriesCommand
		{
			get { return loadCategoriesCommand ?? (loadCategoriesCommand = new Command(async () =>await ExecuteLoadCategories()));}
		}

		async Task ExecuteLoadCategories()
		{
			if (IsBusy)
				return;

			IsDirty = false;
			try
			{
				IsBusy = true;
				var items = await CategoriesDatabase.Current.GetItems<Category>();
				//few ways to do this... maybe load on demand.
				Categories = new ObservableCollection<Category>(items);
			}
			catch(Exception ex)
			{
				ex.Data["info"] = "LoadCategories";
				Insights.Report(ex);
				await page.DisplayAlert("Error", "Unable to load categories, please try again.", "OK");

			}
			finally
			{
				IsBusy = false;
			}
		}
	
	}
}











