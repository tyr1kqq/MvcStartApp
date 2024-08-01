using Microsoft.EntityFrameworkCore;
using MvcStartApp.Models.Db;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRequestRepository
{
    Task AddRequestAsync(Request request);

}
