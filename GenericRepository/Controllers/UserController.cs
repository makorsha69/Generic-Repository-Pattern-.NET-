using GenericRepository.Models;
using GenericRepository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IGenericRepository<User> repository = null;
        public UserController(IGenericRepository<User> _repository)
        {
            this.repository = _repository;
        }

        [HttpGet("GetAll")]

        public IEnumerable<User> GetAll()
        {
            return repository.GetAll();
        }

        

        [HttpPost("Insert")]
        public void AddEmployee(User model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(model);
                repository.Save();
               
            }
            
           
        }
    }
    


}
