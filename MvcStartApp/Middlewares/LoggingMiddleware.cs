using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using MvcStartApp.Models.Db;
using Microsoft.Extensions.DependencyInjection;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IRequestRepository _requestRepository;

    public LoggingMiddleware(RequestDelegate next, IRequestRepository requestRepository)
    {
        _next = next;
        _requestRepository = requestRepository;
    }

    /// <summary>
    ///  Необходимо реализовать метод Invoke  или InvokeAsync
    /// </summary>
    public async Task InvokeAsync(HttpContext context)
    {
        // Для логирования данных о запросе используем свойста объекта HttpContext
        Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");

        // Создание объекта запроса
        var request = new Request
        {
            Id = Guid.NewGuid(),
            Date = DateTime.UtcNow,
            Url = context.Request.Path
        };

        // Сохранение запроса в БД
        await _requestRepository.AddRequestAsync(request);

        // Передача управления следующему middleware
        await _next(context);
    }
}