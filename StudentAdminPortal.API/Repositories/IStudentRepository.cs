using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAdminPortal.API.Models;

namespace StudentAdminPortal.API.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();
    }
}