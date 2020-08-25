using System.Linq;

using EntityFrameworkCore.Repository;
using Business.Domain.Entities;

namespace Business.EntityFrameworkCore.Repositories
{
    public class PeopleTestsRepository :
        BaseRepository<RockResilienceContext, PeopleTest, int>,
        IPeopleTestsRepository
    {
        public PeopleTestsRepository(RockResilienceContext context) : base(context)
        {

        }

        public IQueryable<PeopleTest> GetPeopleTests()
        {
            return base.GetAll();
        }

        public bool DeleteById(PeopleTest e)
        {
            return base.Delete(e);
        }

    }
}
