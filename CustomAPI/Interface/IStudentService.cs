using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomAPI.Models;

namespace CustomAPI.Interface
{
    public interface IStudentService
    {
        Students GetOne(int id);

        IEnumerable<Students> GetAll();
    }
}
