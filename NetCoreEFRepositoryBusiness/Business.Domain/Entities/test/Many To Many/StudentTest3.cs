using System.Collections.Generic;

using Common.Domain.Entities;

namespace Business.Domain.Entities
{
    public class StudentTest3 : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<StudentCourse3> StudentCourse3s { get; set; }
    }
}
