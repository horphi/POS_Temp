using System.Threading.Tasks;
using CerZen.Security.Recaptcha;

namespace CerZen.Test.Base.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
