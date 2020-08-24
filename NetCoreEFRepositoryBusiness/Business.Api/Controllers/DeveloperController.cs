using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.EntityFrameworkCore.Repositories;
using Business.EntityFrameworkCore.UnitOfWorks;
using System.Linq.Expressions;
using Common.Extensions;
using Common.Data;
using Business.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Business.Services.DTO.Rsp;
using Business.Services;
using Business.Services.DTO.Req;

namespace Business.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        private ProductsPassPercentageTestService _service = new ProductsPassPercentageTestService();

        private Rsp rsp = new Rsp();

        public DeveloperController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _service.UnitOfWork = _unitOfWork;
        }

        #region ***select***

        [HttpGet("GetFirstStudentTest3AndRelatedInfo")]
        public IActionResult GetFirstStudentTest3AndRelatedInfo()
        {
            StudentTest3 studentTest3 = _service.GetFirstStudentTest3AndRelatedInfo();

            rsp.Success = true;
            rsp.Data = studentTest3;

            return Ok(rsp);
        }

        [HttpPost("GetDeveloperTestByName")]
        public IActionResult GetDeveloperTestByName(ReqGetDeveloperTestByName req)
        {
            var e = _service.GetDeveloperTestByName(req.strName);

            rsp.Success = true;
            rsp.Data = e;

            return Ok(rsp);
        }

        [HttpPost("GetDeveloperTestById")]
        public IActionResult GetDeveloperTestById(ReqGetDeveloperTestById req)
        {
            var e = _service.GetDeveloperTestById(req.Id);

            rsp.Success = true;
            rsp.Data = e;

            return Ok(rsp);
        }

        [HttpPost("GetDeveloperTestById2")]
        public IActionResult GetDeveloperTestById2(ReqGetDeveloperTestById req)
        {
            var e = _service.GetDeveloperTestById2(req.Id);

            rsp.Success = true;
            rsp.Data = e;

            return Ok(rsp);
        }

        [HttpPost("GetDeveloperTestByIdAsync")]
        public IActionResult GetDeveloperTestByIdAsync(ReqGetDeveloperTestById req)
        {
            var e = _service.GetDeveloperTestByIdAsync(req.Id);

            rsp.Success = true;
            rsp.Data = e;

            return Ok(rsp);
        }

        [HttpPost("GetDeveloperTestByIdAsync2")]
        public IActionResult GetDeveloperTestByIdAsync2(ReqGetDeveloperTestById req)
        {
            var e = _service.GetDeveloperTestByIdAsync2(req.Id);

            rsp.Success = true;
            rsp.Data = e;

            return Ok(rsp);
        }

        [HttpPost("GetDeveloperTestCount")]
        public IActionResult GetDeveloperTestCount(ReqGetDeveloperTestCount req)
        {
            long lCount = _service.GetDeveloperTestCount(req.ListName);

            rsp.Success = true;
            rsp.Data = lCount;

            return Ok(rsp);
        }

        [HttpPost("GetDeveloperTestCountAsync")]
        public IActionResult GetDeveloperTestCountAsync(ReqGetDeveloperTestCount req)
        {
            long lCount = _service.GetDeveloperTestCountAsync(req.ListName);

            rsp.Success = true;
            rsp.Data = lCount;

            return Ok(rsp);
        }

        [HttpPost("GetDeveloperTestsByWhere1")]
        public IActionResult GetDeveloperTestsByWhere1(ReqGetDeveloperTestsByWhere req)
        {
            var list = _service.GetDeveloperTestsByWhere1(req.ListName);

            rsp.Success = true;
            rsp.Data = list;

            return Ok(rsp);
        }

        [HttpPost("GetDeveloperTestsByWhere1Asyc")]
        public IActionResult GetDeveloperTestsByWhere1Asyc(ReqGetDeveloperTestsByWhere req)
        {
            var list = _service.GetDeveloperTestsByWhere1Asyc(req.ListName);

            rsp.Success = true;
            rsp.Data = list;

            return Ok(rsp);
        }

        [HttpPost("GetDeveloperTestByWhereAsync")]
        public IActionResult GetDeveloperTestByWhereAsync(ReqGetDeveloperTestByWhereAsync req)
        {
            var list = _service.GetDeveloperTestByWhereAsync(req.listId);

            rsp.Success = true;
            rsp.Data = list;

            return Ok(rsp);
        }

        /// <summary>
        /// 获取DeveloperTest所有数据(用于某些类型表,一般的查询不会使用该方法)
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllDeveloperTest")]
        public IActionResult GetAllDeveloperTest()
        {
            Rsp rsp = new Rsp();

            List<DeveloperTest> list = _service.GetAllDeveloperTest();

            rsp.Success = true;
            rsp.Data = list;

            return Ok(rsp);
        }

        ///// <summary>
        ///// 根据Id获取某个DeveloperTest
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet("GetDeveloperTestById")]
        //public IActionResult GetDeveloperTestById(int id)
        //{
        //    DeveloperTest e = _unitOfWork.Developers.GetDeveloperTestById(id);
        //    rsp.Data = e;

        //    return Ok(rsp);
        //}

        [HttpPost("GetDeveloperTestsByWhere")]
        public IActionResult GetDeveloperTestsByWhere(List<string> listName)
        {
            List<DeveloperTest> list = _service.GetDeveloperTestsByWhere2Asyc(listName);

            rsp.Success = true;
            rsp.Data = list;

            return Ok(rsp);
        }

        /// <summary>
        /// 根据查询条件(姓名列表,根据id列表(串)),获取DeveloperTest列表
        /// 
        /// add by 罗世杰 on 202008.12
        /// </summary>
        /// <param name="listName"></param>
        /// <returns></returns>
        [HttpPost("GetDeveloperTestsByConditionV2")]
        public IActionResult GetDeveloperTestsByConditionV2(DeveloperTestsWhereReq req)
        {
            if (req == null || (req.ListId == null && req.ListName == null))
            {
                rsp.Success = false;
                rsp.Content = "查询条件为空";
                return Ok(rsp);
            }

            req.ListName.Remove(string.Empty);
            req.ListId.Remove(0);

            if (req.ListId.Count == 0 && req.ListName.Count == 0)
            {
                rsp.Success = false;
                rsp.Content = "查询条件全部为空";
                return Ok(rsp);
            }

            var list = _service.GetDeveloperTestsByConditionV2(req.ListId, req.ListName);

            rsp.Success = true;
            rsp.Data = list;

            return Ok(rsp);
        }

        #endregion

        #region***select with obviously relationship***

        [HttpGet("QueryFromOneToOne")]
        public IActionResult QueryFromOneToOne()
        {
            var list = _service.QueryFromOneToOne();

            rsp.Success = true;
            rsp.Data = list;

            return Ok(rsp);
        }

        [HttpGet("QueryFromOneToMany")]
        public IActionResult QueryFromOneToMany()
        {
            var list = _service.QueryFromOneToMany();

            rsp.Success = true;
            rsp.Data = list;

            return Ok(rsp);
        }

        #endregion

        #region***add***

        /// <summary>
        /// 添加单个DeveloperTest
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        [HttpPost("AddDeveloperTest")]
        public IActionResult AddDeveloperTest(DeveloperTest e)
        {
            rsp.Success = _service.AddDeveloperTest(e);

            return Ok(rsp);
        }

        /// <summary>
        /// 添加多个DeveloperTest
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPost("AddDeveloperTests")]
        public IActionResult AddDeveloperTests(List<DeveloperTest> list)
        {
            rsp.Success = _service.AddDeveloperTests(list);

            return Ok(rsp);
        }

        #endregion

        #region***update***

        /// <summary>
        /// 修改单个DeveloperTest
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        [HttpPut("UpdateDeveloperTest")]
        public IActionResult UpdateDeveloperTest(DeveloperTest e)
        {
            rsp.Success = _service.UpdateDeveloperTest(e);

            return Ok(rsp);
        }

        /// <summary>
        /// 修改多个DeveloperTest
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        [HttpPut("UpdateDeveloperTests")]
        public IActionResult UpdateDeveloperTests(List<DeveloperTest> list)
        {
            rsp.Success = _service.UpdateDeveloperTests(list);

            return Ok(rsp);
        }

        #endregion

        #region***delete***

        /// <summary>
        /// 删除单个DeveloperTest
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteDeveloperTest")]
        public IActionResult DeleteDeveloperTest(int id)
        {
            //bool bExist = _unitOfWork.Developers.exist(whereForm);
            //if (!bExist)
            //{
            //rsp.Success = false;
            //rsp.Content = NotFound().StatusCode.ToString();
            //return Ok(rsp);
            //}

            rsp.Success = _service.DeleteDeveloperTest(id);

            return Ok(rsp);
        }

        /// <summary>
        /// 删除多个DeveloperTest。根据id列表(串)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete("DeleteDeveloperTests")]
        public IActionResult DeleteDeveloperTests(List<int> ids)
        {
            //Expression<Func<DeveloperTest, bool>> whereForm = ExpressionExtensions.True<DeveloperTest>();
            //whereForm = whereForm.And(e => ids.Contains(e.Id));

            //bool bExist = _unitOfWork.Developers.exist(whereForm);
            //if (!bExist)
            //{
            //    rsp.Success = false;
            //    rsp.Content = NotFound().StatusCode.ToString();
            //    return Ok(rsp);
            //}

            rsp.Success = _service.DeleteDeveloperTests(ids);

            return Ok(rsp);
        }

        [HttpDelete("DeleteAsyncDeveloperTest")]
        public IActionResult DeleteAsyncDeveloperTest(int id)
        {
            rsp.Success = _service.DeleteAsyncDeveloperTest(id);

            return Ok(rsp);
        }

        [HttpDelete("DeleteAsyncDeveloperTests")]
        public IActionResult DeleteAsyncDeveloperTests(List<int> ids)
        {
            rsp.Success = _service.DeleteAsyncDeveloperTests(ids);

            return Ok(rsp);
        }

        #endregion

        #region ***execute sql***

        [HttpPost("ExecuteSqlDeveloperTest")]
        public IActionResult ExecuteSqlDeveloperTest()
        {
            string strSql = "insert into DeveloperTests(Name,Followers) values('张三888',888)";
            int nCount = _service.ExecuteSqlDeveloperTest(strSql);

            rsp.Success = true;
            rsp.Data = nCount;

            return Ok(rsp);
        }

        //Async
        [HttpPost("ExecuteSqlAsyncDeveloperTest")]
        public IActionResult ExecuteSqlAsyncDeveloperTest()
        {
            string strSql = "insert into DeveloperTests(Name,Followers) values('张三999',999)";
            int nCount = _service.ExecuteSqlAsyncDeveloperTest(strSql);

            rsp.Success = true;
            rsp.Data = nCount;

            return Ok(rsp);
        }

        #endregion

        [HttpPost("Testing")]
        public IActionResult Testing(ReqGetDeveloperTestById req)
        {
            return Ok(null);
        }

    }
}