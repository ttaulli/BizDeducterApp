using System;
using BizDeducter.Model;
using Xamarin.Forms;
using System.Threading.Tasks;
using Xamarin;

namespace BizDeducter.ViewModel
{
    public class NewExpenseViewModel : BaseViewModel
    {
        public Expense Expense { get; set; }

		public Category Category { get; set; }

		public string CategoryString { get; set; }

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


        public NewExpenseViewModel(Page page, Expense expense = null) : base(page)
        {
            
            if (expense == null)
            {
                Expense = new Expense();
                Title = "New Deduction";
            }
            else
            {
                Title = "Expense Details";
            }


			CategoryString = CurrentCategory;


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


			try
			{
				IsBusy = true;
				CategoryString = CurrentCategory;


				OnPropertyChanged("CategoryString");

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


                //probably do some validation here before saving;

                await Expense.Save();

                MessagingCenter.Send<Expense>(Expense, "UpdateExpense");

                await page.DisplayAlert("Expense Saved", "Successfully saved", "OK");
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


    }
}

