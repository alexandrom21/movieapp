using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using movieappauth.Integration.jsonplaceholder;
using movieappauth.Integration.jsonplaceholder.dto;

namespace movieappauth.Controllers
{
    public class TodoController : Controller
    {
        private readonly ILogger<TodoController> _logger;
        private readonly JsonplaceholderApiIntegration _integracion;

        public TodoController(ILogger<TodoController> logger, JsonplaceholderApiIntegration integracion)
        {
            _logger = logger;
            _integracion = integracion;
        }

        public async Task<IActionResult> Index()
        {
            List<Todo> todos = await _integracion.GetAll();

            // logica para filtrar data del servicio
            List<Todo> filtro = todos
            .Where(todo => todo.title.Contains("provident") && todo.id > 121)
            .OrderBy(todo => todo.title)
            .ThenByDescending(todo => todo.completed)
            .ToList();

            return View(filtro);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}