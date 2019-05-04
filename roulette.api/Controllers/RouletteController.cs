using Microsoft.AspNetCore.Mvc;
using roulette.api.Models;
using roulette.api.Repository;

namespace roulette.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : GenericController<RouletteKeyValue, IRepository<RouletteKeyValue>>
    {
        public RouletteController(IRepository<RouletteKeyValue> repository) : base(repository)
        {
        }
    }
}