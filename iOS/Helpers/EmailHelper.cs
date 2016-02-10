using System;
using BizDeducter.Helpers;
using BizDeducter.iOS.Helpers;

using System.IO;
using Xamarin.Forms;
using MessageUI;
using Foundation;
using UIKit;

[assembly: Dependency(typeof(EmailHelper))]
namespace BizDeducter.iOS.Helpers
{
	public class EmailHelper : IEmailHelper
    {
		
        public EmailHelper()
        {

        }

        private void SaveExcel(MemoryStream stream)
        {
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string filePath = Path.Combine(path, "reports.xlsx");
			try
			{
				FileStream fileStream = File.Open(filePath, FileMode.Create);
				stream.Position = 0;
				stream.CopyTo(fileStream);
				fileStream.Flush();
				fileStream.Close();
			}
			catch
			{
			}
        }

        public void SendMail(MemoryStream stream)
        {
            SaveExcel(stream);

			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string filePath = Path.Combine(path, "reports.xlsx");
          
			NSData data = NSData.FromFile (filePath);

			if (MFMailComposeViewController.CanSendMail) 
			{
				var mail = new MFMailComposeViewController ();
				mail.SetSubject ("Exports");
				mail.SetMessageBody ("Hi, Please find the report here.", false);
				mail.AddAttachmentData (data, "application/vnd.ms-excel", "reports.xlsx");

				var window= UIApplication.SharedApplication.KeyWindow;
				var vc = window.RootViewController;
				vc.PresentViewController (mail, false, null);

				mail.Finished += ( object s, MFComposeResultEventArgs args) => {
					
						args.Controller.DismissViewController (true, null);

				};
			}
        }
    }
}