﻿using System.Collections.Generic;
using CerZen.DynamicEntityProperties.Dto;

namespace CerZen.Web.Areas.WebApp.Models.DynamicEntityProperty
{
    public class CreateEntityDynamicPropertyViewModel
    {
        public string EntityFullName { get; set; }

        public List<string> AllEntities { get; set; }

        public List<DynamicPropertyDto> DynamicProperties { get; set; }
    }
}
