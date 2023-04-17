﻿using GenericRepository.Models;
using GenericRepository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public void AddProduct(Product model)
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
        public void UpdateProduct(Product model)
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
        public ActionResult<Product> GetbyId(int id)
        {
           return repository.GetbyId(id);

        }
    }

        #endregion
    }

