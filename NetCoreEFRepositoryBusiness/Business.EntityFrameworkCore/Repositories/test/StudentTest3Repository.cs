using System.Linq;

using EntityFrameworkCore.Repository;
using Business.Domain.Entities;

namespace Business.EntityFrameworkCore.Repositories
{
    public class StudentTest3Repository :
        BaseRepository<RockResilienceContext, StudentTest3, int>,
        IStudentTest3Repository
    {
        public StudentTest3Repository(RockResilienceContext context) : base(context)
        {

        }

        public IQueryable<StudentTest3> GetStudentTest3s()
        {
            return base.GetAll();
        }
    }
}
