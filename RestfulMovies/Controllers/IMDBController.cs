using System.Threading.Tasks;
using IMDB.Libs.Services;
using Microsoft.AspNetCore.Mvc;

namespace RestfulMovies.Controllers
{
    public class IMDBController : Controller
    {
        private readonly IIMDBServices _IMDBServices;

        public IMDBController(IIMDBServices IMDBServices)
        {
            _IMDBServices = IMDBServices;
        }

        [HttpGet]
        [Route("imdb8/get250Top")]
        public async Task<IActionResult> get250Top()
        {
            var result = await _IMDBServices.getTop250();

            return Ok(result);
        }
    }
}