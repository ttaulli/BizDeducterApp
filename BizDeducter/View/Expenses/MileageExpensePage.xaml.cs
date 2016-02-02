using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BizDeducter.ViewModel;
using Plugin.Media;

namespace BizDeducter.View.Expenses
{
    public partial class MileageExpensePage : ContentPage
    {

		NewMileageViewModel viewModel;

        public MileageExpensePage()
        {
            InitializeComponent();
			BindingContext = viewModel = new NewMileageViewModel(this);
  
			ToolbarItems.Add(new ToolbarItem
				{
					Text="Save",
					Command = viewModel.SaveExpenseCommand

				});


        }
    }
}






			






