using System.Linq;

using EntityFrameworkCore.Repository;
using Business.Domain.Entities;

namespace Business.EntityFrameworkCore.Repositories
{
    public class StudentTest2Repository :
        BaseRepository<RockResilienceContext, StudentTest2, int>,
        IStudentTest2Repository
    {
        public StudentTest2Repository(RockResilienceContext context) : base(context)
        {

        }

        public IQueryable<StudentTest2> GetStudentTest2s()
        {
            return base.GetAll();
        }

    }
}
