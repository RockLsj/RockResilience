using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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

    /// <summary>
    /// 数据仓库接口(Repository interface)
    /// </summary>
    /// <typeparam name="TDbContext">
    /// Microsoft.EntityFrameworkCore.DbContext type object
    /// (Microsoft.EntityFrameworkCore.DbContext类型)
    /// </typeparam>
    /// <typeparam name="TEntity">IEntity<TKey>接口类型</typeparam>
    /// <typeparam name="TKey">表的主键数据类型(The primary key data type of table)</typeparam>
    public interface IRepository<TDbContext, TEntity, TKey>
        where TDbContext : DbContext
        where TEntity : class, IEntity<TKey>
    {
        #region 插入数据(同步和异步方式，保存单个实体和实体列表)

        /// <summary>
        /// 保存单个实体到表[used]
        /// </summary>
        /// <param name="entity">要保存的实体</param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        bool Insert(TEntity entity, bool isSaveChange = true);

        /// <summary>
        /// 保存单个实体到表(异步方式)
        /// </summary>
        /// <param name="entity">要保存的实体</param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        Task<bool> InsertAsync(TEntity entity, bool isSaveChange = true);

        /// <summary>
        /// 保存实体列表到表[used]
        /// </summary>
        /// <param name="entitys">要保存的实体列表</param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        bool Insert(List<TEntity> entitys, bool isSaveChange = true);

        /// <summary>
        /// 保存实体列表到表(异步方式)
        /// </summary>
        /// <param name="entitys">要保存的实体列表</param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        Task<bool> InsertAsync(List<TEntity> entitys, bool isSaveChange = true);

        #endregion

        #region 修改数据

        /// <summary>
        /// 更新某实体字段[used]
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSaveChange"></param>
        /// <param name="updatePropertyList"></param>
        /// <returns></returns>
        bool Update(TEntity entity, bool isSaveChange = true, List<string> updatePropertyList = null);

        /// <summary>
        /// 更新某实体字段(异步方式)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="updatePropertyList"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(TEntity entity, List<string> updatePropertyList = null, bool isSaveChange = true);

        /// <summary>
        /// 更新实体列表[used]
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        bool Update(List<TEntity> entitys, bool isSaveChange = true);

        /// <summary>
        /// 更新实体列表(异步方式)
        /// </summary>
        /// <param name="entitys"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(List<TEntity> entitys, bool isSaveChange = true);

        #endregion

        #region 查找数据

        //IQueryable<TEntity> GetAllAsNoFilter(params object[] noFilterStrings);

        //Testing
        IQueryable<TEntity> GetAll();

        //IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);

        //Testing
        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, bool>>[] propertySelectors);


        //List<TEntity> GetAllList();

        //Task<List<TEntity>> GetAllListAsync();

        //Testing
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);

        //Testing
        /// <summary>
        /// 根据查询条件，获取查询结果的第一个实体
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, bool isNoTracking = true);

        //Testing
        /// <summary>
        /// 根据查询条件，获取查询结果的第一个实体(异步方式)
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool isNoTracking = true);

        //Testing
        /// <summary>
        /// 根据id，获取某个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity FirstOrDefault(TKey id);

        //Testing
        /// <summary>
        /// 根据id，获取某个实体(异步方式)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync(TKey id);

        //TEntity Single(Expression<Func<TEntity, bool>> predicate);

        //Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);

        //Testing
        /// <summary>
        /// 根据查询条件获取记录数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        long Count(Expression<Func<TEntity, bool>> predicate = null);

        //Testing
        /// <summary>
        /// 根据查询条件获取记录数(异步方式)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate = null);

        //Testing
        /// <summary>
        /// 根据查询条件获取IQueryable<TEntity>
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        IQueryable<TEntity> Load(Expression<Func<TEntity, bool>> predicate, bool isNoTracking = true);

        //Testing
        /// <summary>
        /// 根据查询条件获取IQueryable<TEntity>(异步方式)
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isNoTracking"></param>
        /// <returns></returns>
        Task<IQueryable<TEntity>> LoadAsync(Expression<Func<TEntity, bool>> predicate, bool isNoTracking = true);

        #endregion

        #region 删除(删除之前需要查询)

        /// <summary>
        /// 删除某个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        bool Delete(TEntity entity, bool isSaveChange = true);

        /// <summary>
        /// 删除实体列表
        /// </summary>
        /// <param name="entitys">实体列表</param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        bool Delete(List<TEntity> entitys, bool isSaveChange = true);

        /// <summary>
        /// 删除某个实体(异步方式)
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TEntity entity, bool isSaveChange = true);

        /// <summary>
        /// 删除实体列表(异步方式)
        /// </summary>
        /// <param name="entitys">实体列表</param>
        /// <param name="isSaveChange"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(List<TEntity> entitys, bool isSaveChange = true);

        #endregion

        #region 执行Sql语句

        //void BulkInsert<T>(IList<T> entities);

        /// <summary>
        /// 执行纯Sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        int ExecuteSql(string sql);

        /// <summary>
        /// 执行纯Sql语句(异步方式)
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        Task<int> ExecuteSqlAsync(string sql);

        /// <summary>
        /// 执行带参数的sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spList"></param>
        /// <returns></returns>
        int ExecuteSql(string sql, List<DbParameter> spList);

        /// <summary>
        /// 执行带参数的sql语句(异步方式)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spList"></param>
        /// <returns></returns>
        Task<int> ExecuteSqlAsync(string sql, List<DbParameter> spList);

        /// <summary>
        /// 执行sql语句,获取DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        DataTable GetDataTableWithSql(string sql);

        /// <summary>
        /// 执行带参数的sql语句,获取DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="spList"></param>
        /// <returns></returns>
        DataTable GetDataTableWithSql(string sql, List<DbParameter> spList);

        #endregion

        #region 保存数据

        /// <summary>
        /// 提交操作
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        #endregion

        #region add by 罗世杰 on 202008.12

        IEnumerable<TEntity> GetByQuery(Expression<Func<TEntity, bool>> where);

        #endregion
    }
}
