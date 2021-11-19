using System;
using System.Collections.Generic;

namespace SFB.Web.ApplicationCore.Models
{
    public class SpecialCriteria
    {
        public bool? SimilarPupils { get; set; }

        public List<SenCriterion> TopSenCriteria { get; set; }
    }
}
