using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CerZen.MultiTenancy.HostDashboard.Dto;

namespace CerZen.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}