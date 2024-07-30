using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Repository;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _repo;

        public UsersController(IBlogRepository repo)
        {
            _repo = repo;
        }

        public async Task <IActionResult> Index()
        {
            var Authors = await _repo.GetUsers();
            return View(Authors);
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }
    }
}
