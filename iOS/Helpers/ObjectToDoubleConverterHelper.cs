using System;
using BizDeducter.Helpers;
using Xamarin.Forms;
using BizDeducter.iOS.Helpers;
using System.IO;
using Foundation;

[assembly: Dependency(typeof(ObjectToDoubleConverterHelper))]
namespace BizDeducter.iOS.Helpers
{
    public class ObjectToDoubleConverterHelper : IObjectToDoubleConverterHelper
    {
        public double Convert(object obj)
        {
			return ((NSNumber)NSObject.FromObject (obj)).DoubleValue;
        }
    }
}