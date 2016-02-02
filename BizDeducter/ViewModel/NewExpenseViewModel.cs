using System;
using BizDeducter.Model;
using Xamarin.Forms;
using System.Threading.Tasks;
using Xamarin;

namespace BizDeducter.ViewModel
{
    public class NewExpenseViewModel : BaseViewModel
    {
        public Expense Expense { get; set;}
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

