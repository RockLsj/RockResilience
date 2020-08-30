using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Common.Domain.Entities;

namespace EntityFrameworkCore.Interface
{
    public interface IRepository<TDbContext, TEntity> : 
        IRepository<TDbContext, TEntity, int>
        where TDbContext : DbContext
        where TEntity : class, IEntity
    {

    }

    public interface IRepository<TDbContext, TEntity, TKey>
        where TDbContext : DbContext
        where TEntity : class, IEntity<TKey>
    {
        #region insert entity or entities

        /// <summary>
        /// insert single entity(synchronize)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        bool Insert(TEntity entity, bool isSaveChange = true);

        /// <summary>
        /// insert single entity(asynchronous)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        Task<bool> InsertAsync(TEntity entity, bool isSaveChange = true);

        /// <summary>
        /// insert entities(synchronize)
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        bool Insert(List<TEntity> entitys, bool isSaveChange = true);

        /// <summary>
        /// insert entities(asynchronous)
        /// </summary>
        /// <param name="entitys">要保存的实体列表</param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        Task<bool> InsertAsync(List<TEntity> entitys, bool isSaveChange = true);

        #endregion

        #region update entity or entities

        /// <summary>
        /// update specified properties of a table(synchronize)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSaveChange"></param>
        /// <param name="updatePropertyList"></param>
        /// <returns></returns>
        bool Update(TEntity entity, bool isSaveChange = true, List<string> updatePropertyList = null);

        /// <summary>
        /// update specified properties of a table(asynchronous)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="updatePropertyList"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(TEntity entity, bool isSaveChange = true, List<string> updatePropertyList = null);

        /// <summary>
        /// update entities(synchronize)
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        bool Update(List<TEntity> entitys, bool isSaveChange = true);

        /// <summary>
        /// update entities(asynchronous)
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(List<TEntity> entitys, bool isSaveChange = true);

        #endregion

        #region query entity or entities

        /// <summary>
        /// Get the IQueryable of all data of a table
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Get IQueryable of particular entity by query conditions
        /// </summary>
        /// <param name="predicate">query conditions</param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        IQueryable<TEntity> Load(Expression<Func<TEntity, bool>> predicate, bool isNoTracking = true);

        /// <summary>
        /// Get IQueryable of particular entity by conditions
        /// </summary>
        /// <param name="propertySelectors"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, bool>>[] propertySelectors);

        /// <summary>
        /// Get IQueryable of particular entity by conditions(asynchronous)
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        Task<IQueryable<TEntity>> LoadAsync(Expression<Func<TEntity, bool>> predicate, bool isNoTracking = true);

        /// <summary>
        /// Get List of particular entity by conditions(asynchronous)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Get enumerable of particular entity by conditions(asynchronous)
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetByQuery(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// Get the first entity from the list which queried by conditions
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, bool isNoTracking = true);

        /// <summary>
        /// Get the first entity from the list which queried by conditions(asynchronous)
        /// </summary>
        /// <param name="predicate">query conditions</param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool isNoTracking = true);

        /// <summary>
        /// Get the entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity FirstOrDefault(TKey id);

        /// <summary>
        /// Get the entity by Id(asynchronous)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync(TKey id);

        /// <summary>
        /// Get the queried row count by conditions
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        long Count(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Get the queried row count by conditions(asynchronous)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate = null);

        //TEntity Single(Expression<Func<TEntity, bool>> predicate);
        //Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);
        //IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);
        //IQueryable<TEntity> GetAllAsNoFilter(params object[] noFilterStrings);
        //List<TEntity> GetAllList();
        //Task<List<TEntity>> GetAllListAsync();

        #endregion

        #region delete entity or entities

        /// <summary>
        /// delete a entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        bool Delete(TEntity entity, bool isSaveChange = true);

        /// <summary>
        /// delete entities
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        bool Delete(List<TEntity> entitys, bool isSaveChange = true);

        /// <summary>
        /// delete a entity(asynchronous)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TEntity entity, bool isSaveChange = true);

        /// <summary>
        /// delete entities(asynchronous)
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(List<TEntity> entitys, bool isSaveChange = true);

        #endregion

        #region Execute sql

        /// <summary>
        /// Execute sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        int ExecuteSql(string sql);

        /// <summary>
        /// Execute sql(asynchronous)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        Task<int> ExecuteSqlAsync(string sql);

        /// <summary>
        /// Execute sql which has parameters
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spList"></param>
        /// <returns></returns>
        int ExecuteSql(string sql, List<DbParameter> spList);

        /// <summary>
        /// Execute sql which has parameters(asynchronous)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spList"></param>
        /// <returns></returns>
        Task<int> ExecuteSqlAsync(string sql, List<DbParameter> spList);

        /// <summary>
        /// Execute query sql and return DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        DataTable GetDataTableWithSql(string sql);

        /// <summary>
        /// Execute query sql which has parameters and return DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spList"></param>
        /// <returns></returns>
        DataTable GetDataTableWithSql(string sql, List<DbParameter> spList);

        //void BulkInsert<T>(IList<T> entities);

        #endregion

        /// <summary>
        /// make change commit
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
