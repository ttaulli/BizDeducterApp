using System;
using BizDeducter.Helpers;
using Xamarin.Forms;
using Android.Content;
using BizDeducter.Droid.Helpers;
using Java.IO;
using System.IO;

[assembly: Dependency(typeof(ObjectToDoubleConverterHelper))]
namespace BizDeducter.Droid.Helpers
{
    public class ObjectToDoubleConverterHelper : IObjectToDoubleConverterHelper
    {
        public double Convert(object obj)
        {
            return (double)Java.Lang.Double.ValueOf(obj.ToString());
        }
    }
}