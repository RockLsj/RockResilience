using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Common.Domain.Entities;
using EntityFrameworkCore.Interface;
using Business.Domain.Entities;

namespace Business.EntityFrameworkCore.Repositories
{
    public interface IDeveloperRepository
        : IDeveloperRepository<DeveloperTest, int>
    {
        #region Already testing

        //insert--------------------------------------------------------------------------------------------

        /// <summary>
        /// Add DeveloperTest
        /// </summary>
        /// <param name="developer"></param>
        /// <returns></returns>
        public bool Insert(DeveloperTest developer);

        /// <summary>
        /// add some DeveloperTests
        /// </summary>
        /// <param name="developers"></param>
        /// <returns></returns>
        public bool Insert(List<DeveloperTest> developers);

        //update--------------------------------------------------------------------------------------------

        /// <summary>
        /// update DeveloperTest
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool Update(DeveloperTest e);

        /// <summary>
        /// update some DeveloperTest
        /// </summary>
        /// <param name="developers"></param>
        /// <returns></returns>
        public bool Update(List<DeveloperTest> developers);

        //select--------------------------------------------------------------------------------------------

        /// <summary>
        /// Gete all DeveloperTests
        /// </summary>
        /// <returns></returns>
        public List<DeveloperTest> GetAllDeveloperTest();

        /// <summary>
        /// Get DeveloperTest by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DeveloperTest GetDeveloperTestById(int id);

        /// <summary>
        /// Get DeveloperTests by conditions
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IEnumerable<DeveloperTest> GetDeveloperTestByWhere(Expression<Func<DeveloperTest, bool>> where);

        /// <summary>
        /// Get DeveloperTests by conditions(asynchronous)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<List<DeveloperTest>> GetDeveloperTestByWhereAsync(Expression<Func<DeveloperTest, bool>> predicate);

        #region extention

        /// <summary>
        /// Validate if exists DeveloperTest or not by conditions
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public bool exist(Expression<Func<DeveloperTest, bool>> predicate);

        /// <summary>
        /// Get the IQueryable of DeveloperTest
        /// </summary>
        /// <returns></returns>
        public IQueryable<DeveloperTest> GetDeveloperTestAll();

        /// <summary>
        /// Get IQueryable of DeveloperTests by conditions
        /// </summary>
        /// <param name="propertySelectors"></param>
        /// <returns></returns>
        public IQueryable<DeveloperTest> GetDeveloperTestAllIncluding(params Expression<Func<DeveloperTest, bool>>[] propertySelectors);

        /// <summary>
        /// Get DeveloperTest by conditions
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        public DeveloperTest FirstOrDefaultDeveloperTest(Expression<Func<DeveloperTest, bool>> predicate, bool isNoTracking = true);

        /// <summary>
        /// Get DeveloperTest by conditions(asynchronous)
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        public Task<DeveloperTest> FirstOrDefaultAsyncDeveloperTest(Expression<Func<DeveloperTest, bool>> predicate, bool isNoTracking = true);

        /// <summary>
        /// Get DeveloperTest by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DeveloperTest FirstOrDefaultDeveloperTest(int id);

        /// <summary>
        /// Get DeveloperTest by Id(asynchronous)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<DeveloperTest> FirstOrDefaultAsyncDeveloperTest(int id);

        /// <summary>
        /// Get row count of DeveloperTest by conditions
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public long DeveloperTestCount(Expression<Func<DeveloperTest, bool>> predicate = null);

        /// <summary>
        /// Get row count of DeveloperTest by conditions(asynchronous)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<long> DeveloperTestCountAsync(Expression<Func<DeveloperTest, bool>> predicate = null);

        /// <summary>
        /// Get IQueryable of DeveloperTest by conditions
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        public IQueryable<DeveloperTest> DeveloperTestLoad(Expression<Func<DeveloperTest, bool>> predicate, bool isNoTracking = true);

        /// <summary>
        /// Get IQueryable of DeveloperTest by conditions(asynchronous)
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        public Task<IQueryable<DeveloperTest>> DeveloperTestLoadAsync(Expression<Func<DeveloperTest, bool>> predicate, bool isNoTracking = true);

        #endregion

        //public Task<List<DeveloperTest>> GetDeveloperTestByWhereAsync(Expression<Func<DeveloperTest, bool>> predicate);

        //delete--------------------------------------------------------------------------------------------

        /// <summary>
        /// Delete DeveloperTest
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool DeleteById(DeveloperTest e);

        /// <summary>
        /// delete some DeveloperTests
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public bool Delete(List<DeveloperTest> entitys);

        /// <summary>
        /// Delete DeveloperTest(asynchronous)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        public Task<bool> DeleteAsyncDeveloperTest(DeveloperTest entity, bool isSaveChange = true);

        /// <summary>
        /// Delete DeveloperTest(asynchronous)
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        public Task<bool> DeleteAsyncDeveloperTest(List<DeveloperTest> entitys, bool isSaveChange = true);

        //Execute sql--------------------------------------------------------------------------------------------

        /// <summary>
        /// Execute sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteSqlDeveloperTest(string sql);

        /// <summary>
        /// Execute sql(asynchronous)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public Task<int> ExecuteSqlAsyncDeveloperTest(string sql);

        /// <summary>
        /// Execute sql with parameters
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spList"></param>
        /// <returns></returns>
        public int ExecuteSqlDeveloperTest(string sql, List<DbParameter> spList);

        /// <summary>
        /// Execute sql with parameters(asynchronous)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spList"></param>
        /// <returns></returns>
        public Task<int> ExecuteSqlAsyncDeveloperTest(string sql, List<DbParameter> spList);

        /// <summary>
        /// Execute sql and return DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetDataTableWithSqlDeveloperTest(string sql);

        /// <summary>
        /// Execute sql with parameters and return DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spList"></param>
        /// <returns></returns>
        public DataTable GetDataTableWithSqlDeveloperTest(string sql, List<DbParameter> spList);

        #endregion

        #region Testing

        public List<DeveloperTest> Testing();

        #endregion

        #region not Testing

        public IQueryable<DeveloperTest> GetDeveloperTestsByConditionNoAsync(Expression<Func<DeveloperTest, bool>>[] predicate);

        #endregion
    }

    public interface IDeveloperRepository<TEntity, TKey>
        : IRepository<RockResilienceContext, TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
    }
}
