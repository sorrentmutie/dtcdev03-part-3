using DemoWebAPI.WorkerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoWebAPI.Models.ViewModels;

namespace DemoWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesWorkerService service;

        public CategoriesController(ICategoriesWorkerService service)
        {
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetCategories()
        {
            try
            {
                var categories = service.GetAll();
                return Ok(categories);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult GetCategory(int id)
        {

            if(id < 0) return BadRequest();

            try
            {
                var category = service.GetById(id);
                if(category != null)
                {
                    return Ok(category);
                } else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }


        [HttpPost]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public IActionResult CreateCategory([FromBody] CategoryCreateViewModel newCategory)
        {
            if(newCategory == null) return BadRequest();
            try
            {
                service.Add(newCategory);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        

    }
}
