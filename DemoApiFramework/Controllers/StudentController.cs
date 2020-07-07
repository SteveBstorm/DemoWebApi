using DemoApiFramework.Models;
using DemoApiFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoApiFramework.Controllers
{
    public class StudentController : ApiController
    {
        private StudentService _service;
        public StudentController()
        {
            _service = new StudentService();
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _service.GetAll();
        }

        [HttpGet]
        public Student Get(int id)
        {
            return _service.GetAll().Where(s => s.student_id == id).FirstOrDefault();
        }

        [HttpGet]
        [Route("api/student/note/{note}")]
        public IEnumerable<Student> GetNote(int note)
        {
            return _service.GetAll().Where(s => s.year_result >= note);
        }

        [HttpPost]
        public void Post(Student s)
        {
            _service.Save(s);
        }
    }
}
