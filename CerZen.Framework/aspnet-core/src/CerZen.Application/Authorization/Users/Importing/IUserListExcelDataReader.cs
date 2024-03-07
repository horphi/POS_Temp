using System.Collections.Generic;
using CerZen.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace CerZen.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
