using System;
using BizDeducter.Helpers;
using Xamarin.Forms;
using BizDeducter.Droid.Helpers;

[assembly:Dependency(typeof(DatabaseHelper))]
namespace BizDeducter.Droid.Helpers
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

