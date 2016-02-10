using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizDeducter.Helpers
{
    public interface IStreamHelper
    {
        Stream GetStream(string imagePath);
    }
}
