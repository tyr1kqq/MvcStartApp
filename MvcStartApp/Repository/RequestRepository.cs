using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;

public class RequestRepository : IRequestRepository
{
    private readonly ApplicationDbContext _context;

    public RequestRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddRequestAsync(Request request)
    {
        await _context.Requests.AddAsync(request);
        await _context.SaveChangesAsync(); // Обязательно сохраняем изменения
    }
    public async Task<List<Request>> GetAllRequestsAsync()
    {
        return await _context.Requests.ToListAsync();
    }
}