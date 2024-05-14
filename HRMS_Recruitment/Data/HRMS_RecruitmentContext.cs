// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HRMS_Recruitment.Data
{
    public class HRMS_RecruitmentContext : IdentityDbContext<HRMS_User>
    {
        public HRMS_RecruitmentContext (DbContextOptions<HRMS_RecruitmentContext> options)
            : base(options)
        {
        }

        public DbSet<HRMS_Recruitment.Models.JobPosition> JobPosition { get; set; } = default!;
        public DbSet<HRMS_Recruitment.Models.JobDepartment> JobDepartment { get; set; } = default!;
        public DbSet<HRMS_Recruitment.Models.JobPositionVacancy> JobPositionVacancy { get; set; } = default!;
        public DbSet<HRMS_Recruitment.Models.JobApplication> JobApplication { get; set; } = default!;
        public DbSet<HRMS_Recruitment.Models.JobApplicant> JobApplicant { get; set; } = default!;
    }
}
