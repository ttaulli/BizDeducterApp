using System;
using Xamarin.Forms;

using BizDeducter.ViewModel;
using BizDeducter.View.Expenses;


namespace BizDeducter.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
     
		ExpensesViewModel view2;



		public HomeViewModel(Page page) : base(page)
        {

			string totalDeductions = "$0";


		

			Title = totalDeductions;
            Subtitle = "Home page";


        }
    }
}

