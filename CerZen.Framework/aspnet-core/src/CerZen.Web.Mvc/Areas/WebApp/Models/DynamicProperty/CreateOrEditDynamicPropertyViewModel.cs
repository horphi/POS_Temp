using System.Collections.Generic;
using CerZen.DynamicEntityProperties.Dto;

namespace CerZen.Web.Areas.WebApp.Models.DynamicProperty
{
    public class CreateOrEditDynamicPropertyViewModel
    {
        public DynamicPropertyDto DynamicPropertyDto { get; set; }

        public List<string> AllowedInputTypes { get; set; }
    }
}
