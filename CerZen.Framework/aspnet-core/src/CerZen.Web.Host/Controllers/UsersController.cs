﻿using Abp.AspNetCore.Mvc.Authorization;
using CerZen.Authorization;
using CerZen.Storage;
using Abp.BackgroundJobs;

namespace CerZen.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}