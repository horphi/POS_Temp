using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CerZen.Web.Authentication.JwtBearer
{
    public class AsyncJwtBearerOptions : JwtBearerOptions
    {
        public readonly List<IAsyncSecurityTokenValidator> AsyncSecurityTokenValidators;
        
        private readonly CerZenAsyncJwtSecurityTokenHandler _defaultAsyncHandler = new CerZenAsyncJwtSecurityTokenHandler();

        public AsyncJwtBearerOptions()
        {
            AsyncSecurityTokenValidators = new List<IAsyncSecurityTokenValidator>() {_defaultAsyncHandler};
        }
    }

}
