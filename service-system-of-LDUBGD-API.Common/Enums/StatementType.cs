using System.ComponentModel.DataAnnotations;

namespace service_system_of_LDUBGD_API.Common.Enums;

public enum StatementType
{
    [Display(Name = "Довідка для військкомату (Форма 20)")]
    MilitaryOfficeCertificate = 1,

    [Display(Name = "Довідка з місця навчання")]
    StudyCertificate = 2,

    [Display(Name = "Довідка (Форма 9)")]
    Form9Certificate = 3
}


