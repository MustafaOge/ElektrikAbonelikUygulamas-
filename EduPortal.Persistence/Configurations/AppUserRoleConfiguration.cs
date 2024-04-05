﻿using EduPortal.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPortal.Models.Configurations
{
    public class AppUserRoleConfiguration  : BaseConfiguration<AppUserRole>
    {
        public override void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            base.Configure(builder);
            builder.Ignore(x => x.ID);
            builder.HasKey(x => new
            {
                x.UserId,
                x.RoleId
            });
        }
    }
}
