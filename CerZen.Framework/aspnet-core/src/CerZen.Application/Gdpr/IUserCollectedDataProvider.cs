﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using CerZen.Dto;

namespace CerZen.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
