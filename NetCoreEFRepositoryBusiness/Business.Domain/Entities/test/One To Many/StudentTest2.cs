using System;
using System.Collections.Generic;
using System.Text;
using Common.Domain.Entities;

namespace Business.Domain.Entities
{
    public class StudentTest2 : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GradeTest2Id { get; set; }
        public GradeTest2 GradeTest2 { get; set; }
    }
}
