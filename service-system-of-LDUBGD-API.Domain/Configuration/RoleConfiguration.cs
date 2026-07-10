using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using service_system_of_LDUBGD_API.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service_system_of_LDUBGD_API.Domain.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "c78e8f15-6a6c-4c8a-b5d1-98394b071953",
                Name = RoleNames.Administrator,
                NormalizedName = RoleNames.Administrator.ToLower(),
            },
            new IdentityRole
            {
                Id = "36aac992-72ff-4527-9008-52e7c145ca39",
                Name = RoleNames.Student,
                NormalizedName = RoleNames.Student.ToLower(),
            },
            new IdentityRole
            {
                Id = "36aac992-4c8a-4527-9008-98394b071953",
                Name = RoleNames.SuperAdministrator,
                NormalizedName = RoleNames.SuperAdministrator.ToLower(),
            }
        );
    }
}
