using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace CerZen.Web.Areas.WebApp.Models.Users
{
    public class UserLoginAttemptsViewModel
    {
        public List<ComboboxItemDto> LoginAttemptResults { get; set; }
    }
}