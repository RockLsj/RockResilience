using System.Collections.Generic;

using Common.Domain.Entities;

namespace Business.Domain.Entities
{
    public class GradeTest2 : IEntity
    {
        public int Id { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }

        public ICollection<StudentTest2> StudentTest2s { get; set; }
    }
}
