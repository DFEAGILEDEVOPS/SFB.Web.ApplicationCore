using Newtonsoft.Json;
using SFB.Web.ApplicationCore.Entities.Converters;
using SFB.Web.ApplicationCore.Helpers.Constants;

namespace SFB.Web.ApplicationCore.Entities
{
    public class EdubaseDataObject
    {
        [JsonProperty(PropertyName = EdubaseDataFieldNames.URN)]
        public long URN { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.ESTAB_NAME)]
        public string EstablishmentName { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.OVERALL_PHASE)]
        public string OverallPhase { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.PHASE_OF_EDUCATION)]
        public string PhaseOfEducation { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.TYPE_OF_ESTAB)]
        public string TypeOfEstablishment { get; set; }

        [JsonConverter(typeof(LocationConverter))]
        [JsonProperty(PropertyName = EdubaseDataFieldNames.LOCATION)]
        public LocationDataObject Location { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.ADDRESS)]
        public string Address { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.TRUSTS)]
        public string Trusts { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.SPONSORS)]
        public string SponsorName { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.COMPANY_NUMBER)]
        public int? CompanyNumber { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.UID)]
        public int? UID { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.LA_CODE)]
        public int LACode { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.ESTAB_NO)]
        public int EstablishmentNumber { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.LA_ESTAB)]
        public int LAEstab { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.TEL_NO)]
        public string TelephoneNum { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.NO_PUPIL)]
        public float? NumberOfPupils { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.STAT_LOW)]
        public int? StatutoryLowAge { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.STAT_HIGH)]
        public int? StatutoryHighAge { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.HEAD_FIRST_NAME)]
        public string HeadFirstName { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.NURSERY_PROVISION)]
        public string NurseryProvision { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.HEAD_LAST_NAME)]
        public string HeadLastName { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.OFFICIAL_6_FORM)]
        public string OfficialSixthForm { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.SCHOOL_WEB_SITE)]
        public string SchoolWebsite { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.OFSTED_RATING)]
        public string OfstedRating { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.OFSTE_LAST_INSP)]
        public string OfstedLastInsp { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.FINANCE_TYPE)]
        public string FinanceType { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.OPEN_DATE)]
        public string OpenDate { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.CLOSE_DATE)]
        public string CloseDate { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.RELIGIOUS_CHARACTER)]
        public string ReligiousCharacter { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.MAT_SAT)]
        public string MatSat { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.IS_FEDERATION)]
        public bool IsFederation { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.IS_PART_OF_FEDERATION)]
        public bool IsPartOfFederation { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.FEDERATION_MEMBERS)]
        public long[] FederationMembers { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.FEDERATION_UID)]
        public long? FederationUid { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.FEDERATION_NAME)]
        public string FederationName { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.FEDERATIONS_CODE)]
        public long? FederationsCode { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.FEDERATION)]
        public string Federation { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.GOV_OFFICE_REGION)]
        public string GovernmentOfficeRegion { get; set; }

        [JsonProperty(PropertyName = EdubaseDataFieldNames.ESTAB_STATUS)]
        public string EstablishmentStatus { get; set; }
    }
}