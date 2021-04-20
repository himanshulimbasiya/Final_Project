
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomAPI.Interface;
using CustomAPI.Models;

namespace CustomAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly List<Students> students = new List<Students>()
        {
            new Students { Id = 200468958, Name = "Himanshu", Subject= "IES", Marks= 100 },
            new Students { Id = 200468959, Name = "MIT", Subject= "IES", Marks= 100 },
            new Students { Id = 200468960, Name = "Pulkit", Subject= "IES", Marks= 100 },
            new Students { Id = 200468961, Name = "Misam", Subject= "IES", Marks= 100 }
        };

        public IEnumerable<Students> GetAll()
        {
            return students;
        }

        public Students GetOne(int id)
        {
            return students.SingleOrDefault(x => x.Id == id);
        }
    }
}
