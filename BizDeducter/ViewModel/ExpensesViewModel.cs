using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using BizDeducter.Model;
using System.Collections.ObjectModel;
using BizDeducter.Database;
using Xamarin;

namespace BizDeducter.ViewModel
{
    public class ExpensesViewModel : BaseViewModel
    {
        public bool IsDirty { get; set; }
        public ExpensesViewModel(Page page) : base(page)
        {
            Title = "Expenses";
            Subtitle = "Subtitle";
            expenses = new ObservableCollection<Expense>();


            MessagingCenter.Subscribe<Expense>(this, "UpdateExpense", (e) =>
                {
                    IsDirty = true;
                });
        }

        ObservableCollection<Expense> expenses;
        public ObservableCollection<Expense> Expenses
        {
            get { return expenses; }
            set
            {
                expenses = value;
                OnPropertyChanged();
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

