using System;
using BizDeducter.Helpers;
using Xamarin.Forms;
using BizDeducter.iOS.Helpers;

[assembly:Dependency(typeof(DatabaseHelper))]
namespace BizDeducter.iOS.Helpers
{
    public class DatabaseHelper : IDatabaseHelper
    {
        

        #region IDatabaseHelper implementation

        public string Root
        {
            get
            {
                return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            }
        }

        #endregion
    }
}

