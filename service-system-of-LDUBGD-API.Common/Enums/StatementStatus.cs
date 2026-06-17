
using System.ComponentModel.DataAnnotations;

namespace service_system_of_LDUBGD_API.Common.Enums;

public enum StatementStatus
{
    [Display(Name = "в Очікуванні")]
    Pending = 1,

    [Display(Name = "В Процесі")]
    InProgress = 2,

    [Display(Name = "Готово")]
    Ready = 3
}
