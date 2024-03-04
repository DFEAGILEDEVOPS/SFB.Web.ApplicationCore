using Newtonsoft.Json;
using NUnit.Framework;
using SFB.Web.ApplicationCore.Entities;
using Assert = NUnit.Framework.Legacy.ClassicAssert;

namespace SFB.Artifacts.UnitTests.Serialization;

public class EdubaseDataObjectDeserializationTests
{
    [Test]
    // 20220221-GIAS-2022-2023
    public void DeserializeLegacyGiasData_School_ParsesSuccessfully()
    {
        // arrange
        const string document = @"{
    ""URN"": 100809,
    ""LACode"": 210,
    ""LA"": ""Southwark"",
    ""EstablishmentNumber"": 2516,
    ""LAEstab"": 2102516,
    ""EstablishmentName"": ""Robert Browning Primary School"",
    ""TypeOfEstablishmentCode"": 1,
    ""TypeOfEstablishment"": ""Community school"",
    ""EstablishmentTypeGroupCode"": 4,
    ""EstablishmentTypeGroup"": ""Local authority maintained schools"",
    ""EstablishmentStatusCode"": 1,
    ""EstablishmentStatus"": ""Open"",
    ""ReasonEstablishmentOpenedCode"": 0,
    ""ReasonEstablishmentOpened"": ""Not applicable"",
    ""OpenDate"": null,
    ""ReasonEstablishmentClosedCode"": 0,
    ""ReasonEstablishmentClosed"": ""Not applicable"",
    ""CloseDate"": null,
    ""PhaseOfEducationCode"": 2,
    ""PhaseOfEducation"": ""Infant and junior"",
    ""StatutoryLowAge"": 3,
    ""StatutoryHighAge"": 11,
    ""BoardersCode"": 1,
    ""Boarders"": ""No boarders"",
    ""NurseryProvisionName"": ""Has Nursery Classes"",
    ""OfficialSixthFormCode"": 2,
    ""OfficialSixthForm"": ""Does not have a sixth form"",
    ""GenderCode"": 3,
    ""Gender"": ""Mixed"",
    ""ReligiousCharacterCode"": 0,
    ""ReligiousCharacter"": ""Does not apply"",
    ""ReligiousEthos"": ""Does not apply"",
    ""DioceseCode"": 0,
    ""Diocese"": ""Not applicable"",
    ""AdmissionsPolicyCode"": 0,
    ""AdmissionsPolicy"": ""Not applicable"",
    ""SchoolCapacity"": 236,
    ""SpecialClassesCode"": 2,
    ""SpecialClasses"": ""No Special Classes"",
    ""CensusDate"": ""21/01/2021"",
    ""NumberOfPupils"": 191,
    ""NumberOfBoys"": ""104"",
    ""NumberOfGirls"": ""87"",
    ""PercentageFSM"": ""40.1"",
    ""TrustSchoolFlagCode"": 0,
    ""TrustSchoolFlag"": ""Not applicable"",
    ""UID"": null,
    ""Trusts"": """",
    ""SchoolSponsorFlag"": ""Not applicable"",
    ""SchoolSponsors"": """",
    ""FederationFlag"": ""Supported by a federation"",
    ""Federations"": ""The Bridges Federation"",
    ""UKPRN"": ""10074607"",
    ""FEHEIdentifier"": """",
    ""FurtherEducationType"": ""Not applicable"",
    ""OfstedLastInsp"": ""29/09/2021"",
    ""OfstedSpecialMeasuresCode"": 0,
    ""OfstedSpecialMeasures"": ""Not applicable"",
    ""LastChangedDate"": ""14-12-2021"",
    ""Street"": ""King and Queen Street"",
    ""Locality"": ""Walworth"",
    ""Address3"": """",
    ""Town"": ""London"",
    ""County"": """",
    ""Postcode"": ""SE17 1DQ"",
    ""SchoolWebsite"": ""www.thebridgesfederation.org.uk"",
    ""TelephoneNum"": ""02077083456"",
    ""HeadTitle"": ""Mrs"",
    ""HeadFirstName"": ""Sarah"",
    ""HeadLastName"": ""Manley"",
    ""HeadPreferredJobTitle"": ""Headteacher"",
    ""InspectorateName"": """",
    ""InspectorateReport"": """",
    ""DateOfLastInspectionVisit"": """",
    ""NextInspectionVisit"": """",
    ""TeenMoth"": ""Not applicable"",
    ""TeenMothPlaces"": """",
    ""CCF"": ""Not applicable"",
    ""SENPRU"": ""Not applicable"",
    ""EBD"": ""Not applicable"",
    ""PlacesPRU"": """",
    ""FTProv"": """",
    ""EdByOther"": ""Not applicable"",
    ""Section41Approved"": ""Not applicable"",
    ""SEN1"": """",
    ""SEN2"": """",
    ""SEN3"": """",
    ""SEN4"": """",
    ""SEN5"": """",
    ""SEN6"": """",
    ""SEN7"": """",
    ""SEN8"": """",
    ""SEN9"": """",
    ""SEN10"": """",
    ""SEN11"": """",
    ""SEN12"": """",
    ""SEN13"": """",
    ""TypeOfResourcedProvision"": """",
    ""ResourcedProvisionOnRoll"": """",
    ""ResourcedProvisionCapacity"": """",
    ""SenUnitOnRoll"": """",
    ""SenUnitCapacity"": """",
    ""GORCode"": null,
    ""GOR"": ""London"",
    ""DistrictAdministrativeCode"": null,
    ""DistrictAdministrative"": ""Southwark"",
    ""AdministrativeWardCode"": null,
    ""AdministrativeWard"": ""North Walworth"",
    ""ParliamentaryConstituencyCode"": null,
    ""ParliamentaryConstituency"": ""Bermondsey and Old Southwark"",
    ""UrbanRuralCode"": null,
    ""GSSLACode"": ""E09000028"",
    ""Easting"": ""532525"",
    ""Northing"": ""178379"",
    ""CensusAreaStatisticWard"": null,
    ""MSOA"": ""Southwark 016"",
    ""LSOA"": ""Southwark 016A"",
    ""Inspectorate"": null,
    ""SENStat"": """",
    ""SENNoStat"": """",
    ""BoardingEstablishment"": """",
    ""PropsName"": """",
    ""PreviousLACode"": 999,
    ""PreviousLA"": """",
    ""PreviousEstablishmentNumber"": """",
    ""OfstedRatingName"": ""Good"",
    ""OfstedRating"": ""2"",
    ""RSCRegion"": ""South-East England and South London"",
    ""Country"": """",
    ""UPRN"": ""10000811654"",
    ""SiteName"": """",
    ""MSOACode"": null,
    ""LSOACode"": null,
    ""UrbanRuralInner"": ""Conurbation"",
    ""UrbanRuralOuter"": ""Urban"",
    ""EstablishmentNameUpperCase"": ""ROBERT BROWNING PRIMARY SCHOOL"",
    ""FinanceType"": ""Maintained"",
    ""OverallPhase"": ""Primary"",
    ""CompanyNumber"": null,
    ""CompanyNumberD8"": null,
    ""id"": ""100809"",
    ""Location"": {
        ""type"": ""Point"",
        ""coordinates"": [
            -0.09258911836571118,
            51.48883801038701
        ]
    },
    ""_rid"": ""qgt3ANXL-6UMAAAAAAAAAA=="",
    ""_self"": ""dbs/qgt3AA==/colls/qgt3ANXL-6U=/docs/qgt3ANXL-6UMAAAAAAAAAA==/"",
    ""_etag"": ""\""28008644-0000-0d00-0000-6419b06b0000\"""",
    ""_attachments"": ""attachments/"",
    ""FullAddress"": ""King and Queen Street, Walworth, London, SE17 1DQ"",
    ""_ts"": 1679405163
}";

        // act
        var parsed = JsonConvert.DeserializeObject<EdubaseDataObject>(document);

        // assert
        Assert.AreEqual(100809, parsed.URN);
        Assert.AreEqual(210, parsed.LACode);
        Assert.AreEqual(2516, parsed.EstablishmentNumber);
        Assert.AreEqual(2102516, parsed.LAEstab);
        Assert.AreEqual("Robert Browning Primary School", parsed.EstablishmentName);
        Assert.AreEqual("Community school", parsed.TypeOfEstablishment);
        Assert.AreEqual("Open", parsed.EstablishmentStatus);
        Assert.AreEqual(null, parsed.OpenDate);
        Assert.AreEqual(null, parsed.CloseDate);
        Assert.AreEqual("Infant and junior", parsed.PhaseOfEducation);
        Assert.AreEqual(3, parsed.StatutoryLowAge);
        Assert.AreEqual(11, parsed.StatutoryHighAge);
        Assert.AreEqual("Has Nursery Classes", parsed.NurseryProvision);
        Assert.AreEqual("Does not have a sixth form", parsed.OfficialSixthForm);
        Assert.AreEqual("Does not apply", parsed.ReligiousCharacter);
        Assert.AreEqual(191, parsed.NumberOfPupils);
        Assert.AreEqual(null, parsed.UID);
        Assert.AreEqual(string.Empty, parsed.Trusts);
        Assert.AreEqual(string.Empty, parsed.SponsorName);
        Assert.AreEqual(false, parsed.IsFederation);
        Assert.AreEqual(false, parsed.IsPartOfFederation);
        Assert.AreEqual(null, parsed.FederationName);
        Assert.AreEqual(null, parsed.FederationMembers);
        Assert.AreEqual(null, parsed.FederationUid);
        Assert.AreEqual(null, parsed.FederationsCode);
        Assert.AreEqual("The Bridges Federation", parsed.Federation);
        Assert.AreEqual(null, parsed.MatSat);
        Assert.AreEqual("2", parsed.OfstedRating);
        Assert.AreEqual("29/09/2021", parsed.OfstedLastInsp);
        Assert.AreEqual("www.thebridgesfederation.org.uk", parsed.SchoolWebsite);
        Assert.AreEqual("02077083456", parsed.TelephoneNum);
        Assert.AreEqual("Sarah", parsed.HeadFirstName);
        Assert.AreEqual("Manley", parsed.HeadLastName);
        Assert.AreEqual("Maintained", parsed.FinanceType);
        Assert.AreEqual("London", parsed.GovernmentOfficeRegion);
        Assert.AreEqual("Primary", parsed.OverallPhase);
        Assert.AreEqual(null, parsed.CompanyNumber);
        Assert.AreEqual("Point", parsed.Location.type);
        Assert.AreEqual("-0.09258911836571118", parsed.Location.coordinates[0]);
        Assert.AreEqual("51.48883801038701", parsed.Location.coordinates[1]);
        Assert.AreEqual("King and Queen Street, Walworth, London, SE17 1DQ", parsed.Address);
    }

    [Test]
    // 20231211-GIAS-2022-2023
    public void DeserializeCurrentGiasData_School_ParsesSuccessfully()
    {
        // arrange
        const string document = @"{
    ""URN"": 138704,
    ""LACode"": 371,
    ""LA"": ""Doncaster"",
    ""EstablishmentNumber"": 3007,
    ""LAEstab"": 3713007,
    ""EstablishmentName"": ""St Oswald's CofE Academy"",
    ""TypeOfEstablishmentCode"": 34,
    ""TypeOfEstablishment"": ""Academy converter"",
    ""EstablishmentTypeGroupCode"": 10,
    ""EstablishmentTypeGroup"": ""Academies"",
    ""EstablishmentStatusCode"": 1,
    ""EstablishmentStatus"": ""Open"",
    ""ReasonEstablishmentOpenedCode"": 10,
    ""ReasonEstablishmentOpened"": ""Academy Converter"",
    ""OpenDate"": ""09/01/2012"",
    ""ReasonEstablishmentClosedCode"": 99,
    ""ReasonEstablishmentClosed"": """",
    ""CloseDate"": null,
    ""PhaseOfEducationCode"": 2,
    ""PhaseOfEducation"": ""Primary"",
    ""StatutoryLowAge"": null,
    ""StatutoryHighAge"": null,
    ""BoardersCode"": 1,
    ""Boarders"": ""No boarders"",
    ""NurseryProvision"": ""Has Nursery Classes"",
    ""OfficialSixthFormCode"": 2,
    ""OfficialSixthForm"": ""Does not have a sixth form"",
    ""GenderCode"": 3,
    ""Gender"": ""Mixed"",
    ""ReligiousCharacterCode"": 2,
    ""ReligiousCharacter"": ""Church of England"",
    ""ReligiousEthos"": ""Does not apply"",
    ""DioceseCode"": null,
    ""Diocese"": ""Diocese of Sheffield"",
    ""AdmissionsPolicyCode"": 0,
    ""AdmissionsPolicy"": ""Not applicable"",
    ""SchoolCapacity"": 240,
    ""SpecialClassesCode"": 2,
    ""SpecialClasses"": ""No Special Classes"",
    ""CensusDate"": ""19/01/2023"",
    ""NumberOfPupils"": 230,
    ""NumberOfBoys"": 119,
    ""NumberOfGirls"": 111,
    ""PercentageFSM"": ""4.2"",
    ""TrustSchoolFlagCode"": 3,
    ""TrustSchoolFlag"": ""Supported by a multi-academy trust"",
    ""TrustsCode"": null,
    ""Trusts"": ""THE DIOCESE OF SHEFFIELD ACADEMIES TRUST"",
    ""SchoolSponsorFlag"": ""Linked to a sponsor"",
    ""SchoolSponsors"": ""The Diocese of Sheffield Academies Trust"",
    ""FederationFlag"": ""Not applicable"",
    ""FederationsCode"": null,
    ""Federations"": """",
    ""UKPRN"": ""10038497"",
    ""FEHEIdentifier"": """",
    ""FurtherEducationType"": ""Not applicable"",
    ""OfstedLastInsp"": ""13/06/2014"",
    ""OfstedSpecialMeasuresCode"": 0,
    ""OfstedSpecialMeasures"": ""Not applicable"",
    ""LastChangedDate"": ""13/09/2023"",
    ""Street"": ""Silver Birch Grove"",
    ""Locality"": ""Finningley"",
    ""Address3"": """",
    ""Town"": ""Doncaster"",
    ""County"": ""South Yorkshire"",
    ""Postcode"": ""DN9 3EQ"",
    ""SchoolWebsite"": ""www.stoswaldsacademy.co.uk"",
    ""TelephoneNum"": ""01302770330"",
    ""HeadTitle"": ""Mrs"",
    ""HeadFirstName"": ""Sharon"",
    ""HeadLastName"": ""Patton"",
    ""HeadPreferredJobTitle"": ""Headteacher"",
    ""InspectorateName"": """",
    ""InspectorateReport"": """",
    ""DateOfLastInspectionVisit"": """",
    ""NextInspectionVisit"": """",
    ""TeenMoth"": ""Not applicable"",
    ""TeenMothPlaces"": """",
    ""CCF"": ""Not applicable"",
    ""SENPRU"": ""Not applicable"",
    ""EBD"": ""Not applicable"",
    ""PlacesPRU"": """",
    ""FTProv"": """",
    ""EdByOther"": ""Not applicable"",
    ""Section41Approved"": ""Not applicable"",
    ""SEN1"": """",
    ""SEN2"": """",
    ""SEN3"": """",
    ""SEN4"": """",
    ""SEN5"": """",
    ""SEN6"": """",
    ""SEN7"": """",
    ""SEN8"": """",
    ""SEN9"": """",
    ""SEN10"": """",
    ""SEN11"": """",
    ""SEN12"": """",
    ""SEN13"": """",
    ""TypeOfResourcedProvision"": """",
    ""ResourcedProvisionOnRoll"": """",
    ""ResourcedProvisionCapacity"": """",
    ""SenUnitOnRoll"": """",
    ""SenUnitCapacity"": """",
    ""GORCode"": null,
    ""GOR"": ""Yorkshire and the Humber"",
    ""DistrictAdministrativeCode"": null,
    ""DistrictAdministrative"": ""Doncaster"",
    ""AdministrativeWardCode"": null,
    ""AdministrativeWard"": ""Finningley"",
    ""ParliamentaryConstituencyCode"": null,
    ""ParliamentaryConstituency"": ""Don Valley"",
    ""UrbanRuralCode"": null,
    ""GSSLACode"": ""E08000017"",
    ""Easting"": ""467607"",
    ""Northing"": ""467607"",
    ""CensusAreaStatisticWard"": null,
    ""MSOA"": ""Doncaster 026"",
    ""LSOA"": ""Doncaster 026A"",
    ""Inspectorate"": null,
    ""SENStat"": """",
    ""SENNoStat"": """",
    ""BoardingEstablishment"": """",
    ""PropsName"": """",
    ""PreviousLACode"": 999,
    ""PreviousLA"": """",
    ""PreviousEstablishmentNumber"": """",
    ""OfstedRatingName"": ""Outstanding"",
    ""OfstedRating"": ""1"",
    ""RSCRegion"": ""East Midlands and the Humber"",
    ""Country"": """",
    ""SiteName"": """",
    ""MSOACode"": null,
    ""LSOACode"": null,
    ""UrbanRuralInner"": ""Town and fringe"",
    ""UrbanRuralOuter"": ""Rural"",
    ""EstablishmentNameUpperCase"": ""ST OSWALD'S COFE ACADEMY"",
    ""FinanceType"": ""Academies"",
    ""OverallPhase"": ""Primary"",
    ""CompanyNumber"": null,
    ""CompanyNumberD8"": null,
    ""id"": ""138704"",
    ""Location"": ""{\""type\"":\""Point\"",\""coordinates\"":[-0.96762656169189831,54.099926106277557]}"",
    ""_rid"": ""qgt3AJaMiRQjAAAAAAAAAA=="",
    ""_self"": ""dbs/qgt3AA==/colls/qgt3AJaMiRQ=/docs/qgt3AJaMiRQjAAAAAAAAAA==/"",
    ""_etag"": ""\""0100d2a3-0000-0d00-0000-657b1f130000\"""",
    ""_attachments"": ""attachments/"",
    ""FullAddress"": ""Silver Birch Grove, Finningley, Doncaster, South Yorkshire, DN9 3EQ"",
    ""_ts"": 1702567699
}";

        // act
        var parsed = JsonConvert.DeserializeObject<EdubaseDataObject>(document);

        // assert
        Assert.AreEqual(138704, parsed.URN);
        Assert.AreEqual(371, parsed.LACode);
        Assert.AreEqual(3007, parsed.EstablishmentNumber);
        Assert.AreEqual(3713007, parsed.LAEstab);
        Assert.AreEqual("St Oswald's CofE Academy", parsed.EstablishmentName);
        Assert.AreEqual("Academy converter", parsed.TypeOfEstablishment);
        Assert.AreEqual("Open", parsed.EstablishmentStatus);
        Assert.AreEqual("09/01/2012", parsed.OpenDate);
        Assert.AreEqual(null, parsed.CloseDate);
        Assert.AreEqual("Primary", parsed.PhaseOfEducation);
        Assert.AreEqual(null, parsed.StatutoryLowAge);
        Assert.AreEqual(null, parsed.StatutoryHighAge);
        Assert.AreEqual(null, parsed.NurseryProvision);
        Assert.AreEqual("Does not have a sixth form", parsed.OfficialSixthForm);
        Assert.AreEqual("Church of England", parsed.ReligiousCharacter);
        Assert.AreEqual(230, parsed.NumberOfPupils);
        Assert.AreEqual(null, parsed.UID);
        Assert.AreEqual("THE DIOCESE OF SHEFFIELD ACADEMIES TRUST", parsed.Trusts);
        Assert.AreEqual("The Diocese of Sheffield Academies Trust", parsed.SponsorName);
        Assert.AreEqual(false, parsed.IsFederation);
        Assert.AreEqual(false, parsed.IsPartOfFederation);
        Assert.AreEqual(null, parsed.FederationName);
        Assert.AreEqual(null, parsed.FederationMembers);
        Assert.AreEqual(null, parsed.FederationUid);
        Assert.AreEqual(null, parsed.FederationsCode);
        Assert.AreEqual(string.Empty, parsed.Federation);
        Assert.AreEqual(null, parsed.MatSat);
        Assert.AreEqual("1", parsed.OfstedRating);
        Assert.AreEqual("13/06/2014", parsed.OfstedLastInsp);
        Assert.AreEqual("www.stoswaldsacademy.co.uk", parsed.SchoolWebsite);
        Assert.AreEqual("01302770330", parsed.TelephoneNum);
        Assert.AreEqual("Sharon", parsed.HeadFirstName);
        Assert.AreEqual("Patton", parsed.HeadLastName);
        Assert.AreEqual("Yorkshire and the Humber", parsed.GovernmentOfficeRegion);
        Assert.AreEqual("Academies", parsed.FinanceType);
        Assert.AreEqual("Primary", parsed.OverallPhase);
        Assert.AreEqual(null, parsed.CompanyNumber);
        Assert.AreEqual("Point", parsed.Location.type);
        Assert.AreEqual("-0.96762656169189831", parsed.Location.coordinates[0]);
        Assert.AreEqual("54.099926106277557", parsed.Location.coordinates[1]);
        Assert.AreEqual("Silver Birch Grove, Finningley, Doncaster, South Yorkshire, DN9 3EQ", parsed.Address);
    }

    [Test]
    // 20220221-GIAS-2022-2023
    public void DeserializeLegacyGiasData_Federation_ParsesSuccessfully()
    {
        const string document = @"{
    ""URN"": 1094,
    ""FederationMembers"": [
        109443,
        109613
    ],
    ""IsFederation"": true,
    ""IsPartOfFederation"": false,
    ""NurseryProvisionName"": ""No Nursery Classes"",
    ""HasSixthForm"": false,
    ""FinanceType"": ""Federation"",
    ""PhaseOfEducation"": ""Primary"",
    ""OverallPhase"": ""Primary"",
    ""StatutoryLowAge"": 4,
    ""StatutoryHighAge"": 11,
    ""NumberOfPupils"": 146.5,
    ""OpenDate"": ""01/09/2007"",
    ""CloseDate"": null,
    ""LACode"": 822,
    ""OfficialSixthForm"": ""Does not have a sixth form"",
    ""id"": ""d2b04c10-166e-43fd-be7f-20e07137f7b3"",
    ""_rid"": ""qgt3ANXL-6VHYwAAAAAAAA=="",
    ""_self"": ""dbs/qgt3AA==/colls/qgt3ANXL-6U=/docs/qgt3ANXL-6VHYwAAAAAAAA==/"",
    ""_etag"": ""\""4900a5c7-0000-0d00-0000-636b6b400000\"""",
    ""_attachments"": ""attachments/"",
    ""FederationUId"": 1094,
    ""FederationsCode"": 1094,
    ""FederationName"": ""North Bedfordshire Schools Trust (NBST)"",
    ""_ts"": 1667984192
}";
        
        // act
        var parsed = JsonConvert.DeserializeObject<EdubaseDataObject>(document);

        // assert
        Assert.AreEqual(1094, parsed.URN);
        Assert.AreEqual(109443, parsed.FederationMembers[0]);
        Assert.AreEqual(109613, parsed.FederationMembers[1]);
        Assert.AreEqual(true, parsed.IsFederation);
        Assert.AreEqual(false, parsed.IsPartOfFederation);
        Assert.AreEqual("No Nursery Classes", parsed.NurseryProvision);
        Assert.AreEqual("Primary", parsed.PhaseOfEducation);
        Assert.AreEqual("Primary", parsed.OverallPhase);
        Assert.AreEqual(146.5, parsed.NumberOfPupils);
        Assert.AreEqual("01/09/2007", parsed.OpenDate);
        Assert.AreEqual(null, parsed.CloseDate);
        Assert.AreEqual(822, parsed.LACode);
        Assert.AreEqual("Does not have a sixth form", parsed.OfficialSixthForm);
        Assert.AreEqual(1094, parsed.FederationUid);
        Assert.AreEqual(1094, parsed.FederationsCode);
        Assert.AreEqual("North Bedfordshire Schools Trust (NBST)", parsed.FederationName);
        Assert.AreEqual(0, parsed.EstablishmentNumber);
        Assert.AreEqual(0, parsed.LAEstab);
        Assert.AreEqual(null, parsed.EstablishmentName);
        Assert.AreEqual(null, parsed.TypeOfEstablishment);
        Assert.AreEqual(null, parsed.EstablishmentStatus);
        Assert.AreEqual(4, parsed.StatutoryLowAge);
        Assert.AreEqual(11, parsed.StatutoryHighAge);
        Assert.AreEqual(null, parsed.ReligiousCharacter);
        Assert.AreEqual(null, parsed.UID);
        Assert.AreEqual(null, parsed.Trusts);
        Assert.AreEqual(null, parsed.SponsorName);
        Assert.AreEqual(null, parsed.Federation);
        Assert.AreEqual(null, parsed.MatSat);
        Assert.AreEqual(null, parsed.OfstedRating);
        Assert.AreEqual(null, parsed.OfstedLastInsp);
        Assert.AreEqual(null, parsed.SchoolWebsite);
        Assert.AreEqual(null, parsed.TelephoneNum);
        Assert.AreEqual(null, parsed.HeadFirstName);
        Assert.AreEqual(null, parsed.HeadLastName);
        Assert.AreEqual(null, parsed.GovernmentOfficeRegion);
        Assert.AreEqual("Federation", parsed.FinanceType);
        Assert.AreEqual(null, parsed.CompanyNumber);
        Assert.AreEqual(null, parsed.Location);
        Assert.AreEqual(null, parsed.Address);
    }
}