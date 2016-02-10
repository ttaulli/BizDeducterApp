using BizDeducter.Helpers;
using Xamarin.Forms;
using BizDeducter.Droid.Helpers;
using System.IO;

[assembly: Dependency(typeof(StreamHelper))]
namespace BizDeducter.Droid.Helpers
{
    public class StreamHelper : IStreamHelper
    {
        public Stream GetStream(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                if (File.Exists(imagePath))
                {
                    FileStream stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
                    return stream;
                }
            }
            return null;
        }
    }
}