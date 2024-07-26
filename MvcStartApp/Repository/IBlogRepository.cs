using System.Threading.Tasks;

namespace MvcStartApp.Repository
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
    }
}
