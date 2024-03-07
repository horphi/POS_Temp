using System.Collections.Generic;
using CerZen.Authorization.Users.Dto;
using CerZen.Dto;

namespace CerZen.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}