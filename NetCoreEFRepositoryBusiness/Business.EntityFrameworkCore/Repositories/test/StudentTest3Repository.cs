using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkCore.Repository;
using Business.Domain.Entities;

namespace Business.EntityFrameworkCore.Repositories
{
    public class StudentTest3Repository :
        BaseRepository<ApplicationContext, StudentTest3, int>,
        IStudentTest3Repository
    {
        public StudentTest3Repository(ApplicationContext context) : base(context)
        {

        }

        public IQueryable<StudentTest3> GetStudentTest3s()
        {
            return base.GetAll();
        }
    }
}
