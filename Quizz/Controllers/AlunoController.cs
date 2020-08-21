using Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace Quizz.Controllers
{
    public class AlunoController : Controller
    {
        public readonly IQuizzService _service;
        public AlunoController(IQuizzService service)
        {
            _service = service;
        }
        public IActionResult Index(string id)
        {
           var quizz = _service.GetAll();
           return View();
        }
       
    }
}

