using System.Linq;

using Common.Domain.Entities;
using EntityFrameworkCore.Interface;
using Business.Domain.Entities;

namespace Business.EntityFrameworkCore.Repositories
{
    public interface IStudentTest2Repository
        : IStudentTest2Repository<StudentTest2, int>
    {
        public IQueryable<StudentTest2> GetStudentTest2s();
    }

    public interface IStudentTest2Repository<TEntity, TKey>
        : IRepository<RockResilienceContext, TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
    }
}
