using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Common.Data;
using Business.EntityFrameworkCore.UnitOfWorks;
using Business.Domain.Entities;
using Business.Services;
using Business.Services.DTO.Req;

namespace Business.Api.Controllers
{
    /// <summary>
    /// 用于测试
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        private TestService _service = new TestService();

        private Rsp rsp = new Rsp();

        public DeveloperController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _service.UnitOfWork = _unitOfWork;
        }

        #region ***select***

        /// <summary>
        /// 获取第一个StudentTest3和关联的信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetFirstStudentTest3AndRelatedInfo")]
        public IActionResult GetFirstStudentTest3AndRelatedInfo()
        {
            StudentTest3 studentTest3 = _service.GetFirstStudentTest3AndRelatedInfo();

            rsp.Success = true;
            rsp.Data = studentTest3;

            return Ok(rsp);
        }

        /// <summary>
        /// 根据:"姓名",获取单个开发人员信息
        /// </summary>
        /// <param name="req">
        /// strName:姓名
        /// </param>
        /// <returns></returns>
        [HttpPost("GetDeveloperTestByName")]
        public IActionResult GetDeveloperTestByName(ReqGetDeveloperTestByName req)
        {
            var e = _service.GetDeveloperTestByName(req.strName);

            rsp.Success = true;
            rsp.Data = e;

            return Ok(rsp);
        }

        /// <summary>
        /// 根据:Id,获取DeveloperTest
        /// </summary>
        /// <param name="req">
        /// Id:DeveloperTest的Id
        /// </param>
        /// <returns></returns>
        [HttpPost("GetDeveloperTestById")]
        public IActionResult GetDeveloperTestById(ReqGetDeveloperTestById req)
        {
            var e = _service.GetDeveloperTestById(req.Id);

            rsp.Success = true;
            rsp.Data = e;

            return Ok(rsp);
        }

        /// <summary>
        /// 根据:Id,获取DeveloperTest V2
        /// </summary>
        /// <param name="req">
        /// Id:DeveloperTest的Id
        /// </param>
        /// <returns></returns>
        [HttpPost("GetDeveloperTestById2")]
        public IActionResult GetDeveloperTestById2(ReqGetDeveloperTestById req)
        {
            var e = _service.GetDeveloperTestById2(req.Id);

            rsp.Success = true;
            rsp.Data = e;

            return Ok(rsp);
        }

        /// <summary>
        /// 根据:Id,获取DeveloperTest(异步)
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("GetDeveloperTestByIdAsync")]
        public IActionResult GetDeveloperTestByIdAsync(ReqGetDeveloperTestById req)
        {
            var e = _service.GetDeveloperTestByIdAsync(req.Id);

            rsp.Success = true;
            rsp.Data = e;

            return Ok(rsp);
        }

        /// <summary>
        /// 根据:Id,获取DeveloperTest v2(异步)
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("GetDeveloperTestByIdAsync2")]
        public IActionResult GetDeveloperTestByIdAsync2(ReqGetDeveloperTestById req)
        {
            var e = _service.GetDeveloperTestByIdAsync2(req.Id);

            rsp.Success = true;
            rsp.Data = e;

            return Ok(rsp);
        }

        /// <summary>
        /// 根据查询条件，获取DeveloperTest的记录数(同步)
        /// </summary>
        /// <param name="req">
        /// ListName:姓名列表
        /// </param>
        /// <returns></returns>
        [HttpPost("GetDeveloperTestCount")]
        public IActionResult GetDeveloperTestCount(ReqGetDeveloperTestCount req)
        {
            long lCount = _service.GetDeveloperTestCount(req.ListName);

            rsp.Success = true;
            rsp.Data = lCount;

            return Ok(rsp);
        }

        /// <summary>
        /// 根据查询条件，获取DeveloperTest的记录数(异步)
        /// </summary>
        /// <param name="req">
        /// ListName:姓名列表
        /// </param>
        /// <returns></returns>
        [HttpPost("GetDeveloperTestCountAsync")]
        public IActionResult GetDeveloperTestCountAsync(ReqGetDeveloperTestCount req)
        {
            long lCount = _service.GetDeveloperTestCountAsync(req.ListName);

            rsp.Success = true;
            rsp.Data = lCount;

            return Ok(rsp);
        }

        /// <summary>
        /// 根据查询条件获取DeveloperTest列表
        /// </summary>
        /// <param name="req">
        /// ListName:姓名列表
        /// </param>
        /// <returns></returns>
        [HttpPost("GetDeveloperTestsByWhere1")]
        public IActionResult GetDeveloperTestsByWhere1(ReqGetDeveloperTestsByWhere req)
        {
            var list = _service.GetDeveloperTestsByWhere1(req.ListName);

            rsp.Success = true;
            rsp.Data = list;

            return Ok(rsp);
        }

        /// <summary>
        /// 根据查询条件获取DeveloperTest列表(异步)
        /// </summary>
        /// <param name="req">
        /// ListName:姓名列表
        /// </param>
        /// <returns></returns>
        [HttpPost("GetDeveloperTestsByWhere1Asyc")]
        public IActionResult GetDeveloperTestsByWhere1Asyc(ReqGetDeveloperTestsByWhere req)
        {
            var list = _service.GetDeveloperTestsByWhere1Asyc(req.ListName);

            rsp.Success = true;
            rsp.Data = list;

            return Ok(rsp);
        }

        /// <summary>
        /// 根据查询条件获取DeveloperTest列表(异步)
        /// </summary>
        /// <param name="req">
        /// listId:Id列表
        /// </param>
        /// <returns></returns>
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

        /// <summary>
        /// 根据:用户名列表,获取DeveloperTest列表
        /// </summary>
        /// <param name="listName">
        /// 用户名列表
        /// </param>
        /// <returns></returns>
        [HttpPost("GetDeveloperTestsByWhere")]
        public IActionResult GetDeveloperTestsByWhere(List<string> listName)
        {
            List<DeveloperTest> list = _service.GetDeveloperTestsByWhere2Asyc(listName);

            rsp.Success = true;
            rsp.Data = list;

            return Ok(rsp);
        }

        /// <summary>
        /// 根据:姓名列表,id列表(串),获取DeveloperTest列表
        /// </summary>
        /// <param name="req">
        /// ListName:姓名列表<br></br>
        /// ListId:Id列表
        /// </param>
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

        /// <summary>
        /// 从“1对1的关系表”中，进行查询
        /// </summary>
        /// <returns></returns>
        [HttpGet("QueryFromOneToOne")]
        public IActionResult QueryFromOneToOne()
        {
            var list = _service.QueryFromOneToOne();

            rsp.Success = true;
            rsp.Data = list;

            return Ok(rsp);
        }

        /// <summary>
        /// 从“1对多关系表”中，进行查询
        /// </summary>
        /// <returns></returns>
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
        /// <param name="e">
        /// Name:姓名<br></br>
        /// Followers:关注者<br></br>
        /// Id
        /// </param>
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
        /// <param name="list">
        /// DeveloperTest列表<br></br>
        /// Name:姓名<br></br>
        /// Followers:关注者<br></br>
        /// Id
        /// </param>
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
        /// <param name="e">
        /// Name:姓名<br></br>
        /// Followers:关注者<br></br>
        /// Id
        /// </param>
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
        /// <param name="list">
        /// DeveloperTest列表<br></br>
        /// Name:姓名<br></br>
        /// Followers:关注者<br></br>
        /// Id
        /// </param>
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
        /// <param name="ids">Id列表</param>
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

        /// <summary>
        /// 删除DeveloperTest(异步)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteAsyncDeveloperTest")]
        public IActionResult DeleteAsyncDeveloperTest(int id)
        {
            rsp.Success = _service.DeleteAsyncDeveloperTest(id);

            return Ok(rsp);
        }

        /// <summary>
        /// 删除多个DeveloperTest。根据id列表(串)(异步)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpDelete("DeleteAsyncDeveloperTests")]
        public IActionResult DeleteAsyncDeveloperTests(List<int> ids)
        {
            rsp.Success = _service.DeleteAsyncDeveloperTests(ids);

            return Ok(rsp);
        }

        #endregion

        #region ***execute sql***

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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