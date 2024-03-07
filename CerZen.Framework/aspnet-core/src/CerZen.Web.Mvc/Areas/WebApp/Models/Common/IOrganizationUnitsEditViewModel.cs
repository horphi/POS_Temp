using System.Collections.Generic;
using CerZen.Organizations.Dto;

namespace CerZen.Web.Areas.WebApp.Models.Common
{
    public interface IOrganizationUnitsEditViewModel
    {
        List<OrganizationUnitDto> AllOrganizationUnits { get; set; }

        List<string> MemberedOrganizationUnits { get; set; }
    }
}