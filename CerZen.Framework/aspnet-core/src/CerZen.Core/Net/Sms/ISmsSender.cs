using System.Threading.Tasks;

namespace CerZen.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}