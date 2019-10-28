using AutoMapper;
using Highway.Entities;
using Highway.Models.PriceModel;
using Highway.Repository;
using Highway.Repository.PriceRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Highway.Controllers
{
    [Route("api/prices", Name = "Price")]
    public class PriceController : Controller
    {
        private IRepository<Price> _repository;
        private IPriceRepository _repositoryPrice;

        private IMapper _mapper;

        public PriceController(IRepository<Price> repository, IMapper mapper, IPriceRepository repositoryPrice)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryPrice = repositoryPrice;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var price = _repository.GetAll();

            var priceToReturn = _mapper.Map<IEnumerable<PriceDto>>(price);

            return Ok(priceToReturn);
        }

        [HttpGet("${id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            if (!_repository.Exist(id))
            {
                return NotFound();
            }

            var price = _repository.Get(id);
            var priceToReturn = _mapper.Map<PriceDto>(price);

            return Ok(priceToReturn);
        }

        [HttpGet("{CategoryId}/{LocationId}")]
        [Authorize]
        public IActionResult GetPriceByCatAndLoc(int CategoryId,int LocationId)
        {
            var price = _repositoryPrice.GetPriceByLocationAndCategory(CategoryId, LocationId);

            return Ok(price);
        }

        [HttpPost()]
        public IActionResult AddPrice([FromBody] PriceForCreationDto price)
        {
            if(price ==null)
            {
                return BadRequest();
            }

            var priceToReturn = _mapper.Map<Price>(price);
            _repository.Add(priceToReturn);
            if(!_repository.Save())
            {
                return StatusCode(500, "Unexpected error on creating price");
            }
            return CreatedAtRoute("Price", new { id = priceToReturn.Id }, priceToReturn);
            
        }
    }
}
