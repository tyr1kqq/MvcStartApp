using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;

public class RequestRepository : IRequestRepository
{
    private readonly BlogContext _context;

    public RequestRepository(BlogContext context)
    {
        _context = context;
    }

    public async Task AddRequestAsync(Request request)
    {
        await _context.AddAsync(request);
        await _context.SaveChangesAsync(); 
    }

    public async Task<List<Request>> GetAllRequestsAsync()
    {
        try
        {
            return await _context.Requests.ToListAsync();
        }
        catch (Exception ex)
        {
            
            Console.WriteLine($"Error in GetAllRequestsAsync: {ex.Message}");
            throw; 
        }
    }
}