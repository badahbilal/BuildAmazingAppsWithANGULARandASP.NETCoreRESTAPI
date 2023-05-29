using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DTOs;
using StudentAdminPortal.API.Models;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository studentRepository,IMapper mapper)
        {
            this._mapper = mapper;
            this._studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentsAsync(){

            var students = await _studentRepository.GetStudents();

            return Ok(_mapper.Map<List<StudentDTO>>(students));

        }

    }
}