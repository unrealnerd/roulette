using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using roulette.api.Models;
using roulette.api.Repository;

namespace roulette.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhrasesController : ControllerBase
    {
        private IRepository<RouletteKeyValue> PhrasesRepo { get; set; }

        public PhrasesController(IRepository<RouletteKeyValue> phrasesRepo)
        {
            PhrasesRepo = phrasesRepo;
        }

        // GET api/phrases/1
        [HttpGet("{N?}")]
        public async Task<ActionResult<IList<RouletteKeyValue>>> Get(int? N = 1)
        {
            return Ok(await PhrasesRepo.Random((int)N));
        }

        // GET api/phrases/first/1
        [HttpGet("first/{N}")]
        public async Task<ActionResult<IList<RouletteKeyValue>>> First(int N = 1)
        {
            return Ok(await PhrasesRepo.First(N));
        }

        // GET api/phrases/1
        [HttpGet("last/{N}")]
        public async Task<ActionResult<IList<RouletteKeyValue>>> Last(int N = 1)
        {
            return Ok(await PhrasesRepo.Last(N));
        }


        [Route("GetById/{id}")]
        public async Task<ActionResult<RouletteKeyValue>> GetById(string id)
        {
            return Ok(await PhrasesRepo.Get(id));
        }

        // POST api/phrases
        [HttpPost]
        public async void Post([FromBody] RouletteKeyValue value)
        {
            await PhrasesRepo.Create(value);
        }

        // PUT api/phrases/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/phrases/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
