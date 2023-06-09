using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.Data;
using StudentAdminPortal.API.Models;

namespace StudentAdminPortal.API.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly StudentAdminDbContext _context;

        public SqlStudentRepository(StudentAdminDbContext context)
        {
            this._context = context;
        }
        public async Task<List<Student>> GetStudents()
        {
            return await _context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }
    }
}