using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BizDeducter.ViewModel;
using BizDeducter.View.Expenses;

namespace BizDeducter.View
{
    public partial class ReportsPage : ContentPage
    {

		ExpensesViewModel viewModel;
        public ReportsPage()
        {
            InitializeComponent();
			BindingContext = viewModel = new ExpensesViewModel(this);


        }

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (viewModel.Expenses.Count == 0 || viewModel.IsDirty)
				viewModel.LoadExpensesCommand.Execute(null);
		}


	}
}

