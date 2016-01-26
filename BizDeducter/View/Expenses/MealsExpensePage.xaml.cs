using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BizDeducter.ViewModel;

namespace BizDeducter.View.Expenses
{
    public partial class MealsExpensePage : ContentPage
    {
        NewExpenseViewModel viewModel;
        public MealsExpensePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new NewExpenseViewModel(this);
            ToolbarItems.Add(new ToolbarItem
                {
                    Text="Save",
                    Command = viewModel.SaveExpenseCommand
                });
        }
    }
}

