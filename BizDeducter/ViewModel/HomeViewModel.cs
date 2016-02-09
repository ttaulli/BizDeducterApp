using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;
using BizDeducter.Model;
using System.Collections.ObjectModel;
using BizDeducter.Database;
using Xamarin;
using System.Linq;


namespace BizDeducter.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {

		public Category Category { get; set; }


		public bool CategoriesPreloaded
		{
			get { return Settings.CategoriesPreloaded; }
			set
			{
				if (Settings.CategoriesPreloaded == value)
					return;

				Settings.CategoriesPreloaded = value;
				OnPropertyChanged();
			}
		}




		public string TotalDeductionsString { get; set; }
		double totalDeductions;

		public bool IsDirty { get; set; }

		public HomeViewModel(Page page) : base(page)
		{
			Title = "BizDeductor";
			Subtitle = "Subtitle";
			totalDeductions = 0;

			expenses = new ObservableCollection<Expense>();

			if (CategoriesPreloaded == false) {

				SaveCategoryCommand.Execute (null);
			}

		}
			

		ObservableCollection<Expense> expenses;
		public ObservableCollection<Expense> Expenses
		{
			get { return expenses; }
			set
			{
				expenses = value;
				OnPropertyChanged("TotalDeductionsString");
			}
		}


		Command loadExpensesCommand;
		public Command LoadExpensesCommand
		{
			get { return loadExpensesCommand ?? (loadExpensesCommand = new Command(async () =>await ExecuteLoadExpenses()));}
		}

		async Task ExecuteLoadExpenses()
		{
			if (IsBusy)
				return;

			IsDirty = false;
			try
			{
				IsBusy = true;
				var items = await ExpensesDatabase.Current.GetItems<Expense>();
				//few ways to do this... maybe load on demand.
				Expenses = new ObservableCollection<Expense>(items);


				totalDeductions = 0;

				var thisYearsExpenses = Expenses.Where(x => x.Date.Year == DateTime.UtcNow.Year);

				foreach (var item in thisYearsExpenses)
					totalDeductions = totalDeductions + item.Amount;

				TotalDeductionsString = string.Format("{0:C0}", totalDeductions);
				IsDirty = true;


			}
			catch(Exception ex)
			{
				ex.Data["info"] = "LoadExpenses";
				Insights.Report(ex);
				await page.DisplayAlert("Error", "Unable to load expenses, please try again.", "OK");

			}
			finally
			{
				IsBusy = false;
			}
		}



			
		Command saveCategoryCommand;
		public Command SaveCategoryCommand
		{
			get 
			{
				return saveCategoryCommand ?? 
					(saveCategoryCommand = new Command(async () => 
						await ExecuteSaveCategory())); 
			}
		}

		async Task ExecuteSaveCategory()
		{
			if (IsBusy)
				return;

			try
			{
				IsBusy = true;

				CategoriesPreloaded = true;

				//probably do some validation here before saving;


				Category = new Category();

				Category.Name = "Advertising";

				await Category.Save();



				Category = new Category();

				Category.Name = "Auto";

				await Category.Save();


				Category = new Category();

				Category.Name = "Commissions";

				await Category.Save();


				Category = new Category();

				Category.Name = "Contractors";

				await Category.Save();


				Category = new Category();

				Category.Name = "Insurance";

				await Category.Save();


				Category = new Category();

				Category.Name = "Interest";

				await Category.Save();


				Category = new Category();

				Category.Name = "Legal";

				await Category.Save();


				Category = new Category();

				Category.Name = "Miscellaneous";

				await Category.Save();


				Category = new Category();

				Category.Name = "Office";

				await Category.Save();


				Category = new Category();

				Category.Name = "Professional";

				await Category.Save();


				Category = new Category();

				Category.Name = "Rent";

				await Category.Save();



				Category = new Category();

				Category.Name = "Repairs";

				await Category.Save();



				Category = new Category();

				Category.Name = "Supplies";

				await Category.Save();



				Category = new Category();

				Category.Name = "Travel";

				await Category.Save();



				Category = new Category();

				Category.Name = "Utilities";

				await Category.Save();



				MessagingCenter.Send<Category>(Category, "UpdateExpense");



			}
			catch(Exception ex)
			{
				ex.Data["info"] = "ExecuteSaveCategory";
				Insights.Report(ex);
				await page.DisplayAlert("Error", "Unable to save expense, please try again.", "OK");
			}
			finally
			{
				IsBusy = false;
			}
		}






	}
}





