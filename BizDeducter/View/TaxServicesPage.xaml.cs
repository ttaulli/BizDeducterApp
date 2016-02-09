using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Plugin.Media;
using Plugin.Messaging;
using BizDeducter.ViewModel;

namespace BizDeducter.View
{
    public partial class TaxServicesPage : ContentPage
    {
        public TaxServicesPage()
        {
            InitializeComponent();
            BindingContext = new TaxServicesViewModel(this);

			sendEmail.Clicked += async (sender, args) =>
			{


				var emailTask = MessagingPlugin.EmailMessenger;
				if (emailTask.CanSendEmail)
				{
					// Send simple e-mail to single receiver without attachments, bcc, cc etc.
					emailTask.SendEmail("ttaulli@gmail.com", "BizDeductor", "");



				}  


			};

        }
    }
}

