using IMDB.Libs.IMDB;
using System.Threading.Tasks;

namespace IMDB.Libs.Services
{
    public class IMDBServices : IIMDBServices
    {
        private static IGetTop250 _getTop250;

        public IMDBServices(IGetTop250 getTop250)
        {
            _getTop250 = getTop250;
        }

        public async Task<string> getTop250()
        {
            return await _getTop250.ReturnTop250();
        }
    }
}
