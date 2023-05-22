using System.Threading.Tasks;

namespace Mybarber.Services.Interfaces
{
    public interface ISMSService
    {
        bool SendSMS(string phoneNumber, string message);
    }
}
