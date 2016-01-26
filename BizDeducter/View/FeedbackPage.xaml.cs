using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BizDeducter.ViewModel;

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




