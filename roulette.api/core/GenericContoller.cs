using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using roulette.api.Repository;

namespace roulette.api
{
    public abstract class GenericController<T, TRepo>: ControllerBase
    where T : class 
    where TRepo : IRepository<T>
    {
        private readonly IRepository<T> Repository;

        public GenericController(TRepo repository)
        {
            Repository = repository;
        }

        [HttpGet("{N?}")]
        public async Task<ActionResult<IList<T>>> Get(int? N = 1)
        {
            return Ok(await Repository.Random((int)N));
        }

        // GET api/domainentity/first/1
        [HttpGet("first/{N}")]
        public async Task<ActionResult<IList<T>>> First(int N = 1)
        {
            return Ok(await Repository.First(N));
        }

        // GET api/domainentity/1
        [HttpGet("last/{N}")]
        public async Task<ActionResult<IList<T>>> Last(int N = 1)
        {
            return Ok(await Repository.Last(N));
        }


        [Route("GetById/{id}")]
        public async Task<ActionResult<T>> GetById(string id)
        {
            return Ok(await Repository.Get(id));
        }

        // POST api/domainentity
        [HttpPost]
        public async void Post([FromBody] T value)
        {
            await Repository.Create(value);
        }

        // PUT api/domainentity/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/domainentity/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

}