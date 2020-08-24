using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityFrameworkCore.Repository;
using Business.Domain.Entities;

namespace Business.EntityFrameworkCore.Repositories
{
    public class StudentTest2Repository :
        BaseRepository<ApplicationContext, StudentTest2, int>,
        IStudentTest2Repository
    {
        public StudentTest2Repository(ApplicationContext context) : base(context)
        {

        }

        public IQueryable<StudentTest2> GetStudentTest2s()
        {
            return base.GetAll();
        }

    }
}
