using Abp.AutoMapper;
using CerZen.MultiTenancy.Dto;

namespace CerZen.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(EditionsSelectOutput))]
    public class EditionsSelectViewModel : EditionsSelectOutput
    {
    }
}
