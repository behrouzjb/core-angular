using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreAngular.API.DAL.Models;
using CoreAngular.API.BLL.Services;
using System.Linq.Expressions;

namespace CoreAngular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController<T> : ControllerBase where T : Entity
    {
        private readonly IEntityService<T> _serv;

        public EntityController(IEntityService<T> serv)
        {
            _serv = serv;
        }

        // GET: api/Entity/5
        [HttpGet("get/{values}")]
        public ActionResult<T> Get(params object[] values)
        {
            return Ok(_serv.Get(values));
        }

        // GET: api/Entity
        [HttpGet("getAll")]
        public ActionResult<IEnumerable<T>> GetAll()
        {
            return Ok(_serv.GetAll());
        }
        
        // GET: api/Entity/5
        [HttpGet("find/{predicate}")]
        public ActionResult<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Ok(_serv.Find(predicate));
        }

        // POST: api/Entity
        [HttpPost]
        public void Post(T entity)
        {
            _serv.Add(entity);
        }

        // PUT: api/Entity/5
        [HttpPut]
        public void Put(T entity)
        {
            _serv.Update(entity);
        }

        // DELETE: api/Entity/5
        [HttpDelete]
        public void Delete(T entity)
        {
            _serv.Delete(entity);
        }
    }
}
