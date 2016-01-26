using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BizDeducter.ViewModel;
using Plugin.Media;


namespace BizDeducter.View.Expenses
{
	public partial class OtherExpensePage : ContentPage
	{
		NewExpenseViewModel viewModel;

		public OtherExpensePage()
		{
			InitializeComponent();
			BindingContext = viewModel = new NewExpenseViewModel(this);
			ToolbarItems.Add(new ToolbarItem
				{
					Text="Save",
					Command = viewModel.SaveExpenseCommand
				});



			takePhoto.Clicked += async (sender, args) =>
			{
				
				 
				if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
				{
					DisplayAlert("No Camera", ":( No camera available.", "OK");
					return;
				}

				var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
					{
						Directory = "Sample",
						Name = "receipt.jpg"
							
					});

				if (file == null)
					return;

				await DisplayAlert("File Location", file.Path, "OK");

				viewModel.Expense.Receipt = file.Path;

				image.Source = ImageSource.FromStream(() =>
					{
						var stream = file.GetStream();
						file.Dispose();
						return stream;
					}); 
			};






		}
	}
}
