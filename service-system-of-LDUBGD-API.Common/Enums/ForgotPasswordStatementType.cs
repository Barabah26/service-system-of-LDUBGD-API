using System.ComponentModel.DataAnnotations;

namespace service_system_of_LDUBGD_API.Common.Enums;

public enum ForgotPasswordStatementType
{
    [Display(Name = "Пароль до віртуального університету")]
    PasswordForVirtualUniversity = 1,

    [Display(Name = "Пароль до електронного журналу")]
    PasswordForElectronicJournal = 2,
}
