using System.Collections.Generic;
using Abp.Application.Services.Dto;
using CerZen.Editions.Dto;

namespace CerZen.Web.Areas.WebApp.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}