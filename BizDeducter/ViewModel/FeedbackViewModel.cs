using System;
using Xamarin.Forms;

namespace BizDeducter.ViewModel
{

	public class FeedbackViewModel : BaseViewModel
	{
		public FeedbackViewModel(Page page) : base(page)
		{
			Title = "Feedback";
			Subtitle = "Subtitle";
		}
	}
}