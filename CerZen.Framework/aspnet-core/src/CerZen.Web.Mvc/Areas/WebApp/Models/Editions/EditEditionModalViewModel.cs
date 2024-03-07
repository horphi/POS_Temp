using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CerZen.Editions.Dto;
using CerZen.Web.Areas.WebApp.Models.Common;

namespace CerZen.Web.Areas.WebApp.Models.Editions
{
    [AutoMapFrom(typeof(GetEditionEditOutput))]
    public class EditEditionModalViewModel : GetEditionEditOutput, IFeatureEditViewModel
    {
        public bool IsEditMode => Edition.Id.HasValue;

        public IReadOnlyList<ComboboxItemDto> EditionItems { get; set; }

        public IReadOnlyList<ComboboxItemDto> FreeEditionItems { get; set; }
    }
}