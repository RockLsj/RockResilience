using Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace Business.EntityFrameworkCore
{
    public class RockResilienceContext : DbContext, IRockResilienceDbContext
    {
        public RockResilienceContext(DbContextOptions<RockResilienceContext> options) : base(options)
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
        }

    }
}
