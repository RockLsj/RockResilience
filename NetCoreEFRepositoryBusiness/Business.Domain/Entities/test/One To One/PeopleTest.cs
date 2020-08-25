using Common.Domain.Entities;

namespace Business.Domain.Entities
{
    public class PeopleTest : IEntity
    {
        public int Id { get; set; }

        public string IDNumber { get; set; }

        public virtual ConsumeDetailTest ConsumeDetailTest { get; set; }
    }
}
