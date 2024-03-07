using Abp.AspNetCore.Mvc.Authorization;
using CerZen.Authorization.Users.Profile;
using CerZen.Graphics;
using CerZen.Storage;

namespace CerZen.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ProfileController : ProfileControllerBase
    {
        public ProfileController(
            ITempFileCacheManager tempFileCacheManager,
            IProfileAppService profileAppService,
            IImageValidator imageValidator) :
            base(tempFileCacheManager, profileAppService, imageValidator)
        {
        }
    }
}