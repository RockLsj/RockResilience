using Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.EntityFrameworkCore
{
    public class ApplicationContext : DbContext, IApplicationDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<DeveloperTest> DeveloperTests { get; set; }
        public DbSet<StudentTest> StudentTests { get; set; }
        public DbSet<PeopleTest> PeopleTests { get; set; }
        public DbSet<ConsumeDetailTest> ConsumeDetailTests { get; set; }
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


        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

        public void Dispose()
        {
            base.Dispose();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //PeopleTest with ConsumeDetailTest one to one relationship define
            //main table
            modelBuilder.Entity<PeopleTest>()
                .HasOne<ConsumeDetailTest>(p => p.ConsumeDetailTest)

                //sub table[one to one]
                .WithOne(c => c.PeopleTest)
                .HasForeignKey<ConsumeDetailTest>(c => c.PeopleTestId);

            modelBuilder.Entity<StudentTest2>()
                .HasOne<GradeTest2>(e => e.GradeTest2)

                .WithMany(g => g.StudentTest2s)

                .HasForeignKey(s => s.GradeTest2Id);

            modelBuilder.Entity<StudentCourse3>()
                .HasKey(e => new { e.StudentTest3Id, e.CourseTest3Id });


            modelBuilder.Entity<BAH_MOProcessFlow>()
                .HasKey(e => new { e.bah_c031, e.bah_c12 });

            modelBuilder.Entity<R_STATION_REC_T>().HasNoKey();

            modelBuilder.Entity<C_WORK_DESC_T>()
               .HasKey(e => new { e.LINE_NAME, e.SECTION_NAME, e.WORK_SECTION });
        }

    }
}
