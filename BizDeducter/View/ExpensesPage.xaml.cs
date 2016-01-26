using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BizDeducter.ViewModel;
using BizDeducter.View.Expenses;

namespace BizDeducter.View
{
    public partial class ExpensesPage : ContentPage
    {
        ExpensesViewModel viewModel;
        public ExpensesPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ExpensesViewModel(this);

            ButtonMeals.Clicked += async (sender, e) => 
                await Navigation.PushAsync(new MealsExpensePage());
            
            ButtonMileage.Clicked += async (sender, e) => 
                await Navigation.PushAsync(new MileageExpensePage());

            ButtonOther.Clicked += async (sender, e) => 
                await Navigation.PushAsync(new OtherExpensePage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (viewModel.Expenses.Count == 0 || viewModel.IsDirty)
                viewModel.LoadExpensesCommand.Execute(null);
        }
    }
}

