using Abp.AutoMapper;
using CerZen.Localization.Dto;

namespace CerZen.Web.Areas.WebApp.Models.Languages
{
    [AutoMapFrom(typeof(GetLanguageForEditOutput))]
    public class CreateOrEditLanguageModalViewModel : GetLanguageForEditOutput
    {
        public bool IsEditMode => Language.Id.HasValue;
    }
}