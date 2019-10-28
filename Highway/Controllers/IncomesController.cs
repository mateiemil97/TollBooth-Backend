using AutoMapper;
using Highway.Entities;
using Highway.Models.IncomesModel;
using Highway.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Highway.Controllers
{
    [Route("api/incomes", Name ="Income")]
    public class IncomesController: Controller
    {
        private IRepository<Incomes> _repository;
        private IMapper _mapper;

        public IncomesController(IRepository<Incomes> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var incomes = _repository.GetAll();
            return Ok(incomes);
        }

        [HttpGet("${id}")]
        public IActionResult GetAll(int id)
        {
            if(!_repository.Exist(id))
            {
                return NotFound();
            }
            var income = _repository.Get(id);
            return Ok(income);
        }

        [HttpPost]
        public IActionResult Add([FromBody] IncomesForCreationDto income)
        {
            if(income == null)
            {
                return BadRequest();
            }

            var incomeForCreation = _mapper.Map<Incomes>(income);

            _repository.Add(incomeForCreation);

            if(!_repository.Save())
            {
                return StatusCode(500, "Unexpected error occured during income creation");
            }

            return CreatedAtRoute("Income", new { id = incomeForCreation.Id }, incomeForCreation);
        }

    }
}
