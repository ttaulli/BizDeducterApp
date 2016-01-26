using System;
using System.Collections.Generic;

using Xamarin.Forms;
using BizDeducter.ViewModel;

namespace BizDeducter.View
{
    public partial class TaxServicesPage : ContentPage
    {
        public TaxServicesPage()
        {
            InitializeComponent();
            BindingContext = new TaxServicesViewModel(this);

			ButtonFeedback.Clicked += async (sender, e) => 
				await Navigation.PushAsync (new FeedbackPage ());


        }
    }
}

