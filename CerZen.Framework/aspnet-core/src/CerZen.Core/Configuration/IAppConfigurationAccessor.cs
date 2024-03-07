using Microsoft.Extensions.Configuration;

namespace CerZen.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
