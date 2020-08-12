using CrossCutting.User;
using Domain.DTO;
using Domain.Interfaces.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Quizz.Controllers
{

    public class QuizzController : Controller
    {
        public readonly IQuizzService _service;
        private readonly UserManager<Usuario> _userManager;

        public QuizzController(IQuizzService service,UserManager<Usuario> user)
        {
            this._service = service;
            this._userManager = user;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CriarQuizz(QuizzDTO quizzDTO)
        {
            var professorId =  await _userManager.FindByNameAsync(User.Identity.Name);
            quizzDTO.Professor_ID = professorId.Id;
            _service.Add(quizzDTO);
            return RedirectToAction("Create", "Pergunta");
        }
    }
}
