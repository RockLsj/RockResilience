using Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.EntityFrameworkCore
{
    public interface IApplicationDbContext
    {
        DbSet<DeveloperTest> DeveloperTests { get; set; }
        DbSet<StudentTest> StudentTests { get; set; }
        DbSet<PeopleTest> PeopleTests { get; set; }
        DbSet<ConsumeDetailTest> ConsumeDetailTests { get; set; }
        public DbSet<StudentTest2> StudentTest2s { get; set; }
        public DbSet<GradeTest2> GradeTest2s { get; set; }

        public DbSet<StudentTest3> StudentTest3 { get; set; }
        public DbSet<CourseTest3> CourseTest3 { get; set; }
        public DbSet<StudentCourse3> StudentCourse3 { get; set; }

        public DbSet<AutoRepairStation> AutoRepairStation { get; set; }
        public DbSet<BAH_MOProcessFlow> BAH_MOProcessFlow { get; set; }
        public DbSet<BAJ_MO> BAJ_MO { get; set; }
        public DbSet<R_STATION_REC_T> R_STATION_REC_T { get; set; }
        public DbSet<R_WIP_TRACKING_T> R_WIP_TRACKING_T { get; set; }
        public DbSet<Rawdata> Rawdata { get; set; }
        public DbSet<Station_information> Station_information { get; set; }
        public DbSet<StationResume> StationResume { get; set; }
        public DbSet<StationResume_Fail> StationResume_Fail { get; set; }
        public DbSet<WriteNumber> WriteNumber { get; set; }
        public DbSet<C_WORK_DESC_T> C_WORK_DESC_T { get; set; }

        Task<int> SaveChanges();

        void Dispose();

    }
}
