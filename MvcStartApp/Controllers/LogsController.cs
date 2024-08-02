using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvcStartApp.Models.Db;
using Microsoft.EntityFrameworkCore;

public class LogsController : Controller
{
    private readonly IRequestRepository _requestRepository;
    

    public LogsController(IRequestRepository requestRepository)
    {
        _requestRepository = requestRepository;
    }


    [Route("Request")]
    public async Task<IActionResult> Index()
    {
        var requests = await _requestRepository.GetAllRequestsAsync();
        return View(requests);
    }
}