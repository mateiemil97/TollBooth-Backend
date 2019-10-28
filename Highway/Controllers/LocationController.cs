using AutoMapper;
using Highway.Entities;
using Highway.Models.LocationModel;
using Highway.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Highway.Controllers
{
    [Route("api/locations")]
    public class LocationController: Controller
    {
        private IRepository<Location> _repository;
        private IMapper _mapper;
        
        public LocationController(IRepository<Location> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var loc = _repository.GetAll();

            var locToReturn = _mapper.Map<IEnumerable<LocationDto>>(loc);

            return Ok(locToReturn);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if(!_repository.Exist(id))
            {
                return NotFound();
            }
            var loc = _repository.Get(id);

            var locToReturn = _mapper.Map<LocationDto>(loc);

            return Ok(locToReturn);
        }


    }
}
