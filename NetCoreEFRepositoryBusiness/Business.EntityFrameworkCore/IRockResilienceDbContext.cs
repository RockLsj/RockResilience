using Business.Domain.Entities;
using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;

namespace Business.EntityFrameworkCore
{
    public interface IRockResilienceDbContext
    {
        DbSet<DeveloperTest> DeveloperTests { get; set; }
        DbSet<StudentTest> StudentTests { get; set; }
        DbSet<PeopleTest> PeopleTests { get; set; }
        DbSet<ConsumeDetailTest> ConsumeDetailTests { get; set; }

        DbSet<StudentTest2> StudentTest2s { get; set; }
        DbSet<GradeTest2> GradeTest2s { get; set; }

        DbSet<StudentTest3> StudentTest3 { get; set; }
        DbSet<CourseTest3> CourseTest3 { get; set; }
        DbSet<StudentCourse3> StudentCourse3 { get; set; }

        Task<int> SaveChanges();
    }
}
