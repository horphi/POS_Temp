using Abp.AutoMapper;
using CerZen.Authorization.Users.Dto;

namespace CerZen.Mobile.MAUI.Models.User
{
    [AutoMapFrom(typeof(CreateOrUpdateUserInput))]
    public class UserCreateOrUpdateModel : CreateOrUpdateUserInput
    {

    }
}
