using System;
using BizDeducter.Helpers;
using Xamarin.Forms;
using Android.Content;
using BizDeducter.Droid.Helpers;
using Java.IO;
using System.IO;

[assembly: Dependency(typeof(EmailHelper))]
namespace BizDeducter.Droid.Helpers
{
    public class EmailHelper : IEmailHelper
    {
        public EmailHelper()
        {

        }

        private void SaveExcel(MemoryStream stream)
        {
            string exception = string.Empty;
            string root = null;
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
            }
            else
                root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            Java.IO.File myDir = new Java.IO.File(root + "/Syncfusion");
            myDir.Mkdir();

            Java.IO.File file = new Java.IO.File(myDir, "report.xlsx");

            if (file.Exists()) file.Delete();

            try
            {
                FileOutputStream outs = new FileOutputStream(file);
                outs.Write(stream.ToArray());

                outs.Flush();
                outs.Close();
            }
            catch (Exception e)
            {
                exception = e.ToString();
            }
        }

        public void SendMail(MemoryStream stream)
        {
            SaveExcel(stream);

            Intent emailIntent = new Intent(Intent.ActionSend);
            emailIntent.SetType("plain/text");

            Java.IO.File root = Android.OS.Environment.GetExternalStoragePublicDirectory("Syncfusion");
            Java.IO.File file = new Java.IO.File(root, "report.xlsx");
            if (file.Exists() || file.CanRead())
            {
                Android.Net.Uri uri = Android.Net.Uri.FromFile(file);
                emailIntent.PutExtra(Intent.ExtraStream, uri);
            }

            Forms.Context.StartActivity(Intent.CreateChooser(emailIntent, "Send mail..."));
        }
    }
}