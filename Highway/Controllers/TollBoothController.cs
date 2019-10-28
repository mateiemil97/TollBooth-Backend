using AutoMapper;
using Highway.Entities;
using Highway.Models.TollBoothModel;
using Highway.Repository;
using Highway.Repository.TollBoothRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Highway.Controllers
{
    [Route("api/locations",Name ="TollBooth")]
    public class TollBoothController: Controller
    {
        private IRepository<TollBooth> _repository;
        private IMapper _mapper;
        private ITollBoothRepository _repositoryTollBooth;
        public TollBoothController(IRepository<TollBooth> repository, IMapper mapper, ITollBoothRepository repositoryTollBooth)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryTollBooth = repositoryTollBooth;
        }

        //[HttpGet("/tollbooths")]
        //public IActionResult GetAll()
        //{
        //    var price = _repository;

        //    var priceToReturn = _mapper.Map<PriceDto>(price);

        //    return Ok(priceToReturn);
        //}


        [HttpGet("{locationId}/tollbooths")]
        public IActionResult GetAll(int locationId)
        {
            if (_repository.Exist(locationId))
            {
                return NotFound();
            }

            var tollbooth = _repositoryTollBooth.GetTollBoothByLocation(locationId);
           //  var tollboothToReturn = _mapper.Map<PriceDto>(tollbooth);

            return Ok(tollbooth);
        }

        [HttpGet("{locationId}/tollbooths/{id}")]
        public IActionResult Get(int locationId, int id)
        {
            if (_repository.Exist(locationId))
            {
                return NotFound();
            }

            if(!_repository.Exist(id))
            {
                return NotFound();
            }

            var tollbooth = _repositoryTollBooth.GetTollBooth(locationId, id);
            
            return Ok(tollbooth);
        }

        [HttpPost()]
        public IActionResult AddPrice([FromBody] TollboothForCreationDto tollbooth)
        {
            if (tollbooth == null)
            {
                return BadRequest();
            }

            var tollboothToReturn = _mapper.Map<TollBooth>(tollbooth);
            _repository.Add(tollboothToReturn);
            if (!_repository.Save())
            {
                return StatusCode(500, "Unexpected error on creating tollbooth");
            }
            return CreatedAtRoute("Price", new { id = tollboothToReturn.Id }, tollboothToReturn);

        }
    }
}
