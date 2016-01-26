using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BizDeducter.ViewModel;

namespace BizDeducter.View.Expenses
{
    public partial class MileageExpensePage : ContentPage
    {
        NewExpenseViewModel viewModel;
        public MileageExpensePage()
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

