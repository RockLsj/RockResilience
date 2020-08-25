using System.Collections.Generic;

using Common.Domain.Entities;

namespace Business.Domain.Entities
{
    public class CourseTest3 : IEntity
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

        public IList<StudentCourse3> StudentCourse3s { get; set; }
    }
}
