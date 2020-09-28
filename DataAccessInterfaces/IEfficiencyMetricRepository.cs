﻿using SFB.Web.ApplicationCore.Entities;
using System.Threading.Tasks;

namespace SFB.Web.ApplicationCore.DataAccess
{
    public interface IEfficiencyMetricRepository
    {
        Task<EfficiencyMetricParentDataObject> GetEfficiencyMetricDataObjectByUrnAsync(int urn);

        Task<bool> GetStatusByUrnAsync(int urn);
    }
}
