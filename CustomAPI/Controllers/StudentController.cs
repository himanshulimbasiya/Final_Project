using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomAPI.Interface;
using CustomAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace CustomAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IEnumerable<Students> GetAll()
        {
            var students = _studentService.GetAll();
            return students;
        }

        [HttpGet("{id:int}")]
        public Students GetOne(int id)
        {
            var students = _studentService.GetOne(id);
            return students;
        }
    }
}
