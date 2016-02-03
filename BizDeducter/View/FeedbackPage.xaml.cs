using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BizDeducter.ViewModel;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]

namespace BizDeducter.View
{
	public partial class FeedbackPage : ContentPage
	{
		public FeedbackPage ()
		{
			InitializeComponent ();
			BindingContext = new FeedbackViewModel(this);
		}
	}
}




