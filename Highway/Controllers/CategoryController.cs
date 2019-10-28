using AutoMapper;
using Highway.Entities;
using Highway.Models.CategoryModel;
using Highway.Repository;
using Microsoft.AspNetCore.Mvc;


namespace Highway.Controllers
{
    [Route("api/categories")]

    public class CategoryController: Controller
    {
        private IRepository<Category> _repository;
        private IMapper _mapper;
        public CategoryController(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var categoryToReturn = _repository.GetAll();
            return Ok(categoryToReturn);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            if (_repository.Exist(id))
                return NotFound();

            var categories = _repository.Get(id);
            return Ok(categories);
        }

        [HttpPost(Name ="post")]
        public IActionResult AddCategory([FromBody] CategoryForCreationDto category)
        {
            var cat = _mapper.Map<Category>(category);
            _repository.Add(cat);
            if (!_repository.Save())
            {
                return StatusCode(500, "Somethingn wrong with posting category happened!");
            }
            return CreatedAtRoute("post", new { id = cat.Id }, cat);
        }

    }
}
