using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoApiFramework.Models
{
    public class Student
    {
        public int student_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int? year_result { get; set; }
    }
}