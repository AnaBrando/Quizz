using CrossCutting.User;
using Domain.DTO;
using Domain.Interfaces.Application;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        
            if (User.Identity.IsAuthenticated)
            {
                var userId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
                return RedirectToAction("Index", "Professor", new { id = userId });
            }
            return RedirectToAction("Index","Login");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CriarQuizz(QuizzDTO quizzDTO)
        {
            var professorId =  await _userManager.FindByNameAsync(User.Identity.Name);
            quizzDTO.ProfessorSessao = professorId.Id;
            var e = _service.AddQuizz(quizzDTO).Result;

            return RedirectToAction("Create", "Pergunta",new {id=e});
        }
    }
}
