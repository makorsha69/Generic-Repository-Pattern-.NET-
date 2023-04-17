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

        #region GetAll
        [HttpGet("GetAll")]

        public IEnumerable<User> GetAll()
        {
            return repository.GetAll();
        }
        #endregion

        #region Insert
        [HttpPost("Insert")]
        public void AddEmployee(User model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(model);
                repository.Save();

            }
        }
        #endregion

        #region Update
        [HttpPut("Update")]
        public void UpdateProduct(User model)
        {
            if (ModelState.IsValid)
            {
                repository.Update(model);
                repository.Save();

            }
        }
        #endregion

        #region Delete
        [HttpDelete("Delete")]
        public void DeleteProduct(int id)
        {
            if (ModelState.IsValid)
            {
                repository.Delete(id);
                repository.Save();

            }
        }
        #endregion

        #region GetbyId

        [HttpGet("GetById")]
        public ActionResult<User> GetbyId(int id)
        {
            return repository.GetbyId(id);

        }
    }

    #endregion

}
    



