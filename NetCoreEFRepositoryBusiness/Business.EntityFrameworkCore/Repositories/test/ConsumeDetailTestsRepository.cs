using EntityFrameworkCore.Repository;
using Business.Domain.Entities;

namespace Business.EntityFrameworkCore.Repositories
{
    public class ConsumeDetailTestsRepository :
        BaseRepository<RockResilienceContext, ConsumeDetailTest, int>,
        IConsumeDetailTestsRepository
    {
        public ConsumeDetailTestsRepository(RockResilienceContext context) : base(context)
        {

        }

        public bool DeleteById(ConsumeDetailTest e)
        {
            return base.Delete(e);
        }
    }
}
