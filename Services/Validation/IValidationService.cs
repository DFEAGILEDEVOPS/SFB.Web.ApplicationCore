﻿namespace SFB.Web.ApplicationCore.Services
{
    public interface IValidationService
    {
        string ValidateNameParameter(string name);
        string ValidateTrustNameParameter(string name);
        string ValidateLocationParameter(string location);
        string ValidateLocationParameterForComparison(string location);
        string ValidateLaCodeParameter(string laCode);
        string ValidateLaCodeParameterForComparison(string laCode);
        string ValidateLaNameParameter(string laName);
        string ValidateLaNameParameterForComparison(string laName);
        string ValidateLaCodeNameParameter(string laCodeName);
        string ValidateLaCodeNameParameterForComparison(string laCodeName);
        string ValidateSchoolIdParameter(string schoolId);
        string ValidateCompanyNoParameter(string companyNo);
    }
}
