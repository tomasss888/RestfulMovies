using System.Threading.Tasks;

namespace IMDB.Libs.Services
{
    public interface IIMDBServices
    {
        Task<string> getTop250();
    }
}
