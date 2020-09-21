using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Common.Extensions;
using Business.Domain.Entities;
using Business.EntityFrameworkCore.UnitOfWorks;
using Business.Services.DTO.Rsp;

namespace Business.Services
{
    public class TestService
    {
        public IUnitOfWork UnitOfWork
        {
            get;
            set;
        }

        #region ***select***

        //QueryFroManyToMany
        public StudentTest3 GetFirstStudentTest3AndRelatedInfo()
        {
            var iq = UnitOfWork.StudentTest3s.GetStudentTest3s();
            var e = iq.Include(e => e.StudentCourse3s)
                .ThenInclude(StudentCourse3s => StudentCourse3s.CourseTest3).FirstOrDefault();

            return e;
        }

        public DeveloperTest GetDeveloperTestByName(string strName)
        {
            var iq = UnitOfWork.Developers.GetDeveloperTestAll();
            iq = iq.Where(e => e.Name == strName);
            DeveloperTest e = iq != null ? iq.FirstOrDefault() : new DeveloperTest();
            return e;
        }

        public DeveloperTest GetDeveloperTestById(int id)
        {
            Expression<Func<DeveloperTest, bool>> predicate = f => true;
            predicate = predicate.And(e => e.Id == 17);

            DeveloperTest e = UnitOfWork.Developers.FirstOrDefaultDeveloperTest(predicate);

            return e;
        }

        public DeveloperTest GetDeveloperTestById2(int id)
        {
            DeveloperTest e = UnitOfWork.Developers.FirstOrDefaultDeveloperTest(id);

            return e;
        }

        public DeveloperTest GetDeveloperTestByIdAsync(int id)
        {
            Expression<Func<DeveloperTest, bool>> predicate = f => true;
            predicate = predicate.And(e => e.Id == id);

            Task<DeveloperTest> taskE = UnitOfWork.Developers.FirstOrDefaultAsyncDeveloperTest(predicate);
            DeveloperTest e = taskE.Result;

            return e;
        }

        public DeveloperTest GetDeveloperTestByIdAsync2(int id)
        {
            Task<DeveloperTest> taskE = UnitOfWork.Developers.FirstOrDefaultAsyncDeveloperTest(id);
            DeveloperTest e = taskE.Result;

            return e;
        }

        public long GetDeveloperTestCount(List<string> listName)
        {
            Expression<Func<DeveloperTest, bool>> predicate = f => true;
            predicate = predicate.And(e => listName.Contains(e.Name));

            long ncount = UnitOfWork.Developers.DeveloperTestCount(predicate);

            return ncount;
        }

        public long GetDeveloperTestCountAsync(List<string> listName)
        {
            Expression<Func<DeveloperTest, bool>> predicate = f => true;
            predicate = predicate.And(e => listName.Contains(e.Name));

            Task<long> taskNcount = UnitOfWork.Developers.DeveloperTestCountAsync(predicate);
            long ncount = taskNcount.Result;

            return ncount;
        }

        public List<DeveloperTest> GetDeveloperTestsByWhere1(List<string> listName)
        {
            List<DeveloperTest> list = new List<DeveloperTest>();

            Expression<Func<DeveloperTest, bool>> predicate = f => true;
            predicate = predicate.And(e => listName.Contains(e.Name));

            var iq = UnitOfWork.Developers.DeveloperTestLoad(predicate);
            list = iq.ToList();

            return list;
        }

        public List<DeveloperTest> GetDeveloperTestsByWhere1Asyc(List<string> listName)
        {
            List<DeveloperTest> list = new List<DeveloperTest>();

            Expression<Func<DeveloperTest, bool>> predicate = f => true;

            predicate = predicate.And(e => listName.Contains(e.Name));
            Task<IQueryable<DeveloperTest>> taskE = UnitOfWork.Developers.DeveloperTestLoadAsync(predicate);

            var iq = taskE.Result;
            list = iq.ToList();

            return list;
        }

        public List<DeveloperTest> GetDeveloperTestByWhereAsync(List<int> listId)
        {
            List<DeveloperTest> list = new List<DeveloperTest>();

            Expression<Func<DeveloperTest, bool>> predicate = f => true;
            predicate = predicate.And(e => listId.Contains(e.Id));

            Task<List<DeveloperTest>> taskList = UnitOfWork.Developers.GetDeveloperTestByWhereAsync(predicate);
            list = taskList.Result;

            return list;
        }

        public List<DeveloperTest> GetAllDeveloperTest()
        {
            return UnitOfWork.Developers.GetAllDeveloperTest();
        }

        public List<DeveloperTest> GetDeveloperTestsByWhere2Asyc(List<string> listName)
        {
            Expression<Func<DeveloperTest, bool>> whereForm2 = ExpressionExtensions.False<DeveloperTest>();

            listName.ForEach(e =>
            {
                whereForm2 = whereForm2.Or(e2 => e2.Name.IndexOf(e) >= 0);
            });

            Task<List<DeveloperTest>> taskList = UnitOfWork.Developers.GetDeveloperTestByWhereAsync(whereForm2);
            List<DeveloperTest> list = taskList.Result;

            return list;
        }

        public List<DeveloperTest> GetDeveloperTestsByConditionV2(List<int> ListId, List<string> ListName)
        {
            Expression<Func<DeveloperTest, bool>> whereForm = ExpressionExtensions.False<DeveloperTest>();

            ListName.ForEach(e =>
            {
                whereForm = whereForm.Or(e2 => e2.Name.Contains(e));
            });

            if (ListId != null && ListId.Count > 0)
            {
                whereForm = whereForm.And(e2 => ListId.Contains(e2.Id));
            }

            var ie = UnitOfWork.Developers.GetDeveloperTestByWhere(whereForm);
            return ie != null ? ie.ToList() : new List<DeveloperTest>();
        }

        #endregion

        #region***select with obviously relationship***

        public List<TestObjRsp> QueryFromOneToOne()
        {
            /*
             * In This solution, we implement PeopleTest and ConsumeDetailTests Entities as one to one relationship.
             * And we implement the selection from the both objects(tables) with selected properties(fields).
             */
            var iq = UnitOfWork.PeopleTests.GetPeopleTests();
            var iqTestObj = iq.Include(e => e.ConsumeDetailTest)
                .Select(e => new TestObjRsp
                {
                    Id = e.Id,
                    IDNumber = e.IDNumber,
                    ConsumeType = e.ConsumeDetailTest.ConsumeType,
                    TotalPrice = e.ConsumeDetailTest.TotalPrice
                });
            return iqTestObj.ToList();
        }

        public List<GradeShowRsp> QueryFromOneToMany()
        {
            var iq = UnitOfWork.StudentTest2s.GetStudentTest2s();
            var iqGradeShow = iq.Include(e => e.GradeTest2)
                .Select(e => new GradeShowRsp
                {
                    Id = e.Id,
                    Name = e.Name,
                    GradeName = e.GradeTest2.GradeName,
                    Section = e.GradeTest2.Section
                });
            return iqGradeShow.ToList();
        }

        #endregion

        #region***add***

        public bool AddDeveloperTest(DeveloperTest e)
        {
            return UnitOfWork.Developers.Insert(e);
        }

        public bool AddDeveloperTests(List<DeveloperTest> list)
        {
            return UnitOfWork.Developers.Insert(list);
        }

        #endregion

        #region***update***

        public bool UpdateDeveloperTest(DeveloperTest e)
        {
            return UnitOfWork.Developers.Update(e);
        }

        public bool UpdateDeveloperTests(List<DeveloperTest> list)
        {
            return UnitOfWork.Developers.Update(list);
        }

        #endregion

        #region***delete***

        public bool DeleteDeveloperTest(int id)
        {
            DeveloperTest e = new DeveloperTest();
            e.Id = id;

            return UnitOfWork.Developers.DeleteById(e);
        }

        public bool DeleteDeveloperTests(List<int> ids)
        {
            List<DeveloperTest> entitys = new List<DeveloperTest>();
            ids.ForEach(e => entitys.Add(new DeveloperTest() { Id = e }));

            return UnitOfWork.Developers.Delete(entitys);
        }

        public bool DeleteAsyncDeveloperTest(int id)
        {
            DeveloperTest entity = new DeveloperTest();
            entity.Id = id;

            Task<bool> taskResult = UnitOfWork.Developers.DeleteAsyncDeveloperTest(entity);
            return taskResult.Result;
        }

        public bool DeleteAsyncDeveloperTests(List<int> ids)
        {
            List<DeveloperTest> entitys = new List<DeveloperTest>();
            ids.ForEach(e => entitys.Add(new DeveloperTest() { Id = e }));

            Task<bool> taskResult = UnitOfWork.Developers.DeleteAsyncDeveloperTest(entitys);
            return taskResult.Result;
        }

        #endregion

        #region ***execute sql***

        public int ExecuteSqlDeveloperTest(string strSql)
        {
            return UnitOfWork.Developers.ExecuteSqlDeveloperTest(strSql);
        }

        public int ExecuteSqlAsyncDeveloperTest(string strSql)
        {
            Task<int> TaskNCount = UnitOfWork.Developers.ExecuteSqlAsyncDeveloperTest(strSql);
            return TaskNCount.Result;
        }

        #endregion

        public bool IsExist(int id)
        {
            return UnitOfWork.Developers.exist(e => e.Id == id);
        }

    }
}
