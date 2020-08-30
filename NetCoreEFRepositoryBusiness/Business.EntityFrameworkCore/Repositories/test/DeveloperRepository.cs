using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;

using Business.Domain.Entities;
using EntityFrameworkCore.Repository;

namespace Business.EntityFrameworkCore.Repositories
{
    public class DeveloperRepository :
        BaseRepository<RockResilienceContext, DeveloperTest, int>,
        IDeveloperRepository
    {
        public DeveloperRepository(RockResilienceContext context) : base(context)
        {

        }

        #region Already testing

        //insert--------------------------------------------------------------------------------------------

        /// <summary>
        /// Add DeveloperTest
        /// </summary>
        /// <param name="developer"></param>
        /// <returns></returns>
        public bool Insert(DeveloperTest developer)
        {
            return base.Insert(developer);
        }

        /// <summary>
        /// add some DeveloperTests
        /// </summary>
        /// <param name="developers"></param>
        /// <returns></returns>
        public bool Insert(List<DeveloperTest> developers)
        {
            return base.Insert(developers);
        }

        //update--------------------------------------------------------------------------------------------

        /// <summary>
        /// update DeveloperTest
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool Update(DeveloperTest e)
        {
            return base.Update(e);
        }

        /// <summary>
        /// update some DeveloperTest
        /// </summary>
        /// <param name="developers"></param>
        /// <returns></returns>
        public bool Update(List<DeveloperTest> developers)
        {
            return base.Update(developers);
        }

        //select--------------------------------------------------------------------------------------------

        /// <summary>
        /// Gete all DeveloperTests
        /// </summary>
        /// <returns></returns>
        public List<DeveloperTest> GetAllDeveloperTest()
        {
            var iq = base.GetAll();
            return iq != null ? iq.ToList() : new List<DeveloperTest>();
        }

        /// <summary>
        /// Get DeveloperTest by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DeveloperTest GetDeveloperTestById(int id)
        {
            return base.FirstOrDefault(id);
        }

        /// <summary>
        /// Get DeveloperTests by conditions
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IEnumerable<DeveloperTest> GetDeveloperTestByWhere(Expression<Func<DeveloperTest, bool>> where)
        {
            return base.GetByQuery(where);
        }

        /// <summary>
        /// Get DeveloperTests by conditions(asynchronous)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<List<DeveloperTest>> GetDeveloperTestByWhereAsync(Expression<Func<DeveloperTest, bool>> predicate)
        {
            return base.GetAllListAsync(predicate);
        }

        //public async Task<List<DeveloperTest>> GetDeveloperTestByWhereAsync(Expression<Func<DeveloperTest, bool>> predicate)
        //{
        //    return await base.GetAllListAsync(predicate);
        //}

        #region extention

        /// <summary>
        /// Validate if exists DeveloperTest or not by conditions
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public bool exist(Expression<Func<DeveloperTest, bool>> predicate)
        {
            long nCount = base.Count(predicate);
            return nCount > 0 ? true : false;
        }

        /// <summary>
        /// Get the IQueryable of DeveloperTest
        /// </summary>
        /// <returns></returns>
        public IQueryable<DeveloperTest> GetDeveloperTestAll()
        {
            return base.GetAll();
        }

        /// <summary>
        /// Get IQueryable of DeveloperTests by conditions
        /// </summary>
        /// <param name="propertySelectors"></param>
        /// <returns></returns>
        public IQueryable<DeveloperTest> GetDeveloperTestAllIncluding(params Expression<Func<DeveloperTest, bool>>[] propertySelectors)
        {
            return base.GetAllIncluding(propertySelectors);
        }

        /// <summary>
        /// Get DeveloperTest by conditions
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        public DeveloperTest FirstOrDefaultDeveloperTest(Expression<Func<DeveloperTest, bool>> predicate, bool isNoTracking = true)
        {
            return base.FirstOrDefault(predicate, isNoTracking);
        }

        /// <summary>
        /// Get DeveloperTest by conditions(asynchronous)
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        public Task<DeveloperTest> FirstOrDefaultAsyncDeveloperTest(Expression<Func<DeveloperTest, bool>> predicate, bool isNoTracking = true)
        {
            return base.FirstOrDefaultAsync(predicate, isNoTracking);
        }

        /// <summary>
        /// Get DeveloperTest by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DeveloperTest FirstOrDefaultDeveloperTest(int id)
        {
            return base.FirstOrDefault(id);
        }

        /// <summary>
        /// Get DeveloperTest by Id(asynchronous)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<DeveloperTest> FirstOrDefaultAsyncDeveloperTest(int id)
        {
            return base.FirstOrDefaultAsync(id);
        }

        /// <summary>
        /// Get row count of DeveloperTest by conditions
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public long DeveloperTestCount(Expression<Func<DeveloperTest, bool>> predicate = null)
        {
            return base.Count(predicate);
        }

        /// <summary>
        /// Get row count of DeveloperTest by conditions(asynchronous)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<long> DeveloperTestCountAsync(Expression<Func<DeveloperTest, bool>> predicate = null)
        {
            return base.CountAsync(predicate);
        }

        /// <summary>
        /// Get IQueryable of DeveloperTest by conditions
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        public IQueryable<DeveloperTest> DeveloperTestLoad(Expression<Func<DeveloperTest, bool>> predicate, bool isNoTracking = true)
        {
            return base.Load(predicate, isNoTracking);
        }

        /// <summary>
        /// Get IQueryable of DeveloperTest by conditions(asynchronous)
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        public Task<IQueryable<DeveloperTest>> DeveloperTestLoadAsync(Expression<Func<DeveloperTest, bool>> predicate, bool isNoTracking = true)
        {
            return base.LoadAsync(predicate, isNoTracking);
        }

        #endregion

        //delete--------------------------------------------------------------------------------------------

        /// <summary>
        /// Delete DeveloperTest
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool DeleteById(DeveloperTest e)
        {
            return base.Delete(e);
        }

        /// <summary>
        /// delete some DeveloperTests
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public bool Delete(List<DeveloperTest> entitys)
        {
            return base.Delete(entitys);
        }

        /// <summary>
        /// Delete DeveloperTest(asynchronous)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        public Task<bool> DeleteAsyncDeveloperTest(DeveloperTest entity, bool isSaveChange = true)
        {
            return base.DeleteAsync(entity, isSaveChange);
        }

        /// <summary>
        /// Delete DeveloperTest(asynchronous)
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        public Task<bool> DeleteAsyncDeveloperTest(List<DeveloperTest> entitys, bool isSaveChange = true)
        {
            return base.DeleteAsync(entitys, isSaveChange);
        }

        //Execute sql--------------------------------------------------------------------------------------------

        /// <summary>
        /// Execute sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteSqlDeveloperTest(string sql)
        {
            return base.ExecuteSql(sql);
        }

        /// <summary>
        /// Execute sql(asynchronous)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public Task<int> ExecuteSqlAsyncDeveloperTest(string sql)
        {
            return base.ExecuteSqlAsync(sql);
        }

        /// <summary>
        /// Execute sql with parameters
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spList"></param>
        /// <returns></returns>
        public int ExecuteSqlDeveloperTest(string sql, List<DbParameter> spList)
        {
            return base.ExecuteSql(sql, spList);
        }

        /// <summary>
        /// Execute sql with parameters(asynchronous)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spList"></param>
        /// <returns></returns>
        public Task<int> ExecuteSqlAsyncDeveloperTest(string sql, List<DbParameter> spList)
        {
            return base.ExecuteSqlAsync(sql, spList);
        }

        /// <summary>
        /// Execute sql and return DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetDataTableWithSqlDeveloperTest(string sql)
        {
            return base.GetDataTableWithSql(sql);
        }

        /// <summary>
        /// Execute sql with parameters and return DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spList"></param>
        /// <returns></returns>
        public DataTable GetDataTableWithSqlDeveloperTest(string sql, List<DbParameter> spList)
        {
            return base.GetDataTableWithSql(sql, spList);
        }

        #endregion

        #region Testing

        public List<DeveloperTest> Testing()
        {
            return new List<DeveloperTest>();
        }

        #endregion

        #region not Testing

        public IQueryable<DeveloperTest> GetDeveloperTestsByConditionNoAsync(params Expression<Func<DeveloperTest, bool>>[] predicate)
        {
            return base.GetAllIncluding(predicate);
        }

        #endregion
    }
}
