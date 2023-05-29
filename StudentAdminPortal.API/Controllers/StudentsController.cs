using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public StudentsController(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult GetStudents(){
            var students =  _studentRepository.GetStudents();

            var studentsDTO = new List<StudentDTO>();

            foreach (var student in students)
            {
                studentsDTO.Add(new StudentDTO{
                    Id = student.Id,
                    FirstName = student.FirstName, 
                    LastName = student.LastName, 
                    DateOfBirth = student.DateOfBirth, 
                    Email = student.Email, 
                    Mobile = student.Mobile, 
                    ProfileImageUrl= student.ProfileImageUrl, 
                    GenderId = student.GenderId,
                    Address = new Address(){
                        Id = student.Address.Id,
                        PhysicalAddress = student.Address.PhysicalAddress,
                        PostalAddress = student.Address.PostalAddress
                    },
                    Gender = new Gender(){
                        Id = student.Gender.Id,
                        Description = student.Gender.Description

                    }
                });
            }

            return Ok(studentsDTO);
            
        }

    }
}