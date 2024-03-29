﻿using System;
using System.Linq;
using System.Threading.Tasks;
using SFB.Web.ApplicationCore.DataAccess;
using SFB.Web.ApplicationCore.Entities;

namespace SFB.Web.ApplicationCore.Services.DataAccess
{
    public class EfficiencyMetricDataService : IEfficiencyMetricDataService
    {
        private readonly IEfficiencyMetricRepository _efficiencyMetricRepository;

        public EfficiencyMetricDataService(IEfficiencyMetricRepository efficiencyMetricRepository)
        {
            _efficiencyMetricRepository = efficiencyMetricRepository;
        }

        public async Task<EfficiencyMetricParentDataObject> GetSchoolDataObjectByUrnAsync(long urn)
        {
            EfficiencyMetricParentDataObject emData = null;
            var emDatas =  await _efficiencyMetricRepository.GetEfficiencyMetricDataObjectByUrnAsync(urn);
            if(emDatas.Count == 0)
            {
                throw new ApplicationException("Efficiency metric data object could not be loaded from collection! URN:" + urn);
            }
            else if (emDatas.Count == 2) {
                emData = emDatas.Where(em => em.PrimarySecondary == "Secondary").FirstOrDefault();
            }
            else {
                emData = emDatas.First();
            }
            emData.Neighbours = emData.Neighbours.OrderBy(n => n.Rank).ToList();
            return emData;
        }

        public Task<bool> GetStatusByUrn(long urn)
        {
            return _efficiencyMetricRepository.GetStatusByUrnAsync(urn);            
        }
    }
}
