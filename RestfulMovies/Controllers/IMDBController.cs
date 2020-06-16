using System.Threading.Tasks;
using IMDB.Libs.Services;
using Microsoft.AspNetCore.Mvc;

namespace RestfulMovies.Controllers
{
    /// <summary>
    /// Controller class of IMDB external API
    /// </summary>
    /// <param name="get250Top"> gets 250 results of movies </param>>
    /// <param name="getSimillar"> get similar movies by id </param>>
    public class IMDBController : Controller
    {
        [HttpGet]
        [Route("imdb8/get250Top")]
        public async Task<IActionResult> get250Top()
        {
            var result = await IMDBServices.getTop250();

            return Ok(result);
        }

        [HttpGet]
        [Route("imdb8/getSimillar")]
        public async Task<IActionResult> getSimillar(string mID)
        {
            var result = await IMDBServices.getSimilarMovies(mID);

            return Ok(result);
        }
    }
}