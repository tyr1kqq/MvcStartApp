using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcStartApp.Repository
{
    public class BlogRepository : IBlogRepository
    {
        // ссылка на контекст 
        private readonly BlogContext _context;

        // метод - конструктор для инициализации 
        public BlogRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            // Добавление пользователя
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached )
            await _context.Users.AddAsync(user);
                
            // Сохранение изменений 
            await _context.SaveChangesAsync();
        }
    }
}
