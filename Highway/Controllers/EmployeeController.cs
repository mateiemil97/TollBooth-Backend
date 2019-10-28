using AutoMapper;
using Highway.Entities;
using Highway.Models.EmployeeModels;
using Highway.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Highway.Controllers
{
    [Route("api/employees")]
    public class EmployeeController: Controller
    {
        private IRepository<Employee> _repository;
        private IMapper _mapper;
        public EmployeeController(IRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var emp = _repository.GetAll();

            var empToReturn = _mapper.Map<EmployeeDto>(emp);

            return Ok(empToReturn);
        }

        [HttpGet("${id}")]
        public IActionResult Get(int id)
        {
            if(!_repository.Exist(id))
            {
                return NotFound();
            }

            var emp = _repository.Get(id);
            var empToReturn = _mapper.Map<EmployeeDto>(emp);


            return Ok(empToReturn);
        }
    }
}
