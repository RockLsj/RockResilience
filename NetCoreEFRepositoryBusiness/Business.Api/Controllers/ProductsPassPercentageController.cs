using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.Data;
using Business.EntityFrameworkCore.UnitOfWorks;
using Business.Services;

namespace Business.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsPassPercentageController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        private ProductsPassPercentageService _service = new ProductsPassPercentageService();

        private Rsp rsp = new Rsp();

        public ProductsPassPercentageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _service.UnitOfWork = _unitOfWork;
        }

        [HttpGet("Testing")]
        public IActionResult Testing()
        {
            _service.Testing();
            return Ok(null);
        }

    }
}
