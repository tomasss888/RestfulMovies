using System.Threading.Tasks;

namespace IMDB.Libs.IMDB
{
    public interface IGetTop250
    {
        Task<string> ReturnTop250();
    }
}
