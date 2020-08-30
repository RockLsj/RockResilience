using Business.EntityFrameworkCore.Repositories;

namespace Business.EntityFrameworkCore.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRockResilienceDbContext _context;

        //test
        public IDeveloperRepository Developers { get; private set; }
        public IPeopleTestsRepository PeopleTests { get; private set; }
        public IConsumeDetailTestsRepository ConsumeDetailTests { get; private set; }
        public IStudentTest2Repository StudentTest2s { get; private set; }
        public IStudentTest3Repository StudentTest3s { get; private set; }

        public UnitOfWork(
            IRockResilienceDbContext context,

            IDeveloperRepository developers,
            IPeopleTestsRepository peopleTests,
            IConsumeDetailTestsRepository consumeDetailTests,
            IStudentTest2Repository studentTest2s,
            IStudentTest3Repository studentTest3s
            )
        {
            _context = context;

            //test
            Developers = developers;
            PeopleTests = peopleTests;
            ConsumeDetailTests = consumeDetailTests;
            StudentTest2s = studentTest2s;
            StudentTest3s = studentTest3s;
        }
    }
}
