using System.Collections.Generic;
using CerZen.Authentication;

namespace CerZen.Configuration.Dto
{
    public class ExternalLoginProviderSettingsEditDto
    {
        public bool Facebook_IsDeactivated { get; set; }
        
        public FacebookExternalLoginProviderSettings Facebook { get; set; }
        
        public bool Google_IsDeactivated { get; set; }
        
        public GoogleExternalLoginProviderSettings Google { get; set; }

    }
}
