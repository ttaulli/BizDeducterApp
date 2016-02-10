using BizDeducter.Helpers;
using Xamarin.Forms;
using BizDeducter.iOS.Helpers;
using System.IO;
using UIKit;
using Foundation;
using System;

[assembly: Dependency(typeof(StreamHelper))]
namespace BizDeducter.iOS.Helpers
{
	public class StreamHelper : IStreamHelper
	{
		public Stream GetStream(string imagePath)
		{
			UIImage image = UIImage.FromFile(imagePath);

			NSData data = null;
			data = image.AsPNG();

			return new MemoryStream( data.ToArray () );
		}
	}
}