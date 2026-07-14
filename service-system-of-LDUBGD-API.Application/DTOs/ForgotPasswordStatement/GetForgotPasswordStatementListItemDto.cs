using service_system_of_LDUBGD_API.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_system_of_LDUBGD_API.Application.DTOs.ForgotPasswordStatement;

public record GetForgotPasswordStatementListItemDto(
   int Id,
   ForgotPasswordStatementType TypeOfForgotPassword,
   string Login,
   string Password,
   StatementStatus Status,
   string UserId);

