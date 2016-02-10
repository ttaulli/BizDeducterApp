using System.IO;

namespace BizDeducter.Helpers
{
    public interface IEmailHelper
    { 
        void SendMail(MemoryStream stream);
    }
}
