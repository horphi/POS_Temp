using System.Collections.Generic;
using CerZen.Authorization.Users.Importing.Dto;
using CerZen.Dto;

namespace CerZen.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
