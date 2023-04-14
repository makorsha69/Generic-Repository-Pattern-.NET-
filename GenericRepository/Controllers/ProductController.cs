using GenericRepository.Models;
using GenericRepository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IGenericRepository<Product> repository = null;
        public ProductController(IGenericRepository<Product> _repository)
        {
            this.repository = _repository;
        }

        #region GetAll
        [HttpGet("GetAll")]

        public IEnumerable<Product> GetAll()
        {
            return repository.GetAll();
        }
        #endregion

        #region Insert
        [HttpPost("Insert")]
        public void AddEmployee(Product model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(model);
                repository.Save();

            }
        }
        #endregion
    }
}
