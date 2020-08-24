using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.EntityFrameworkCore;
using Business.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Business.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IApplicationDbContext _context;

        public StudentController(IApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentTest student)
        {
            _context.StudentTests.Add(student);
            await _context.SaveChanges();
            return Ok(student.Id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _context.StudentTests.ToListAsync();
            if (students == null) return NotFound();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _context.StudentTests.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.StudentTests.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (student == null) return NotFound();
            _context.StudentTests.Remove(student);
            await _context.SaveChanges();
            return Ok(student.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentTest studentUpdate)
        {
            var student = _context.StudentTests.Where(a => a.Id == id).FirstOrDefault();
            if (student == null) return NotFound();
            else
            {
                student.Age = studentUpdate.Age;
                student.Name = studentUpdate.Name;
                await _context.SaveChanges();
                return Ok(student.Id);
            }
        }
    }
}
