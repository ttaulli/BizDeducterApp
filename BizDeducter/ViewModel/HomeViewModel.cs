using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using BizDeducter.Model;
using System.Collections.ObjectModel;
using BizDeducter.Database;
using Xamarin;


namespace BizDeducter.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {

		public string TotalDeductionsString { get; set; }
		double totalDeductions;

		public bool IsDirty { get; set; }

		public HomeViewModel(Page page) : base(page)
		{
			Title = "BizDeductor";
			Subtitle = "Subtitle";
			totalDeductions = 0;

			expenses = new ObservableCollection<Expense>();


			totalDeductions = expenses.Count;

			TotalDeductionsString = string.Format("{0:C0}", totalDeductions);



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


	}
}





