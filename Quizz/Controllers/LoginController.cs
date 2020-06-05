using System.Threading.Tasks;
using CrossCutting.Contexto;
using CrossCutting.DTO;
using CrossCutting.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Quizz.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        public LoginController(SignInManager<Usuario> signInManager, UserManager<Usuario> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost, ActionName("RegisterPost")]
        public async Task<IActionResult> RegisterPost([FromForm] UsuarioDTO registerModel)
        {
            if (ModelState.IsValid)
            {
                Usuario user = new Usuario
                {

                    UserName = registerModel.UserName,
                    Email = registerModel.Email
                };

                var result = await _userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {
                    var resultSignIn = await _signInManager.PasswordSignInAsync(registerModel.UserName, registerModel.Password, false, false);
                    if (resultSignIn.Succeeded)
                    {
                        return RedirectToAction("Index", "Library");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();

        }
    }
}
