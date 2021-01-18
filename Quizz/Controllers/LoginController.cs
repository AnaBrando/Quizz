using System.Linq;
using System.Threading.Tasks;
using CrossCutting.Contexto;
using CrossCutting.DTO;
using CrossCutting.User;
using Domain.DTO;
using Domain.Interfaces.Application;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Quizz.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IProfessorService _professorService;

             private readonly IAlunoService _alunoService;
        public LoginController(SignInManager<Usuario> signInManager,
            UserManager<Usuario> userManager, 
            RoleManager<IdentityRole> roleManager,
            IProfessorService service,
            IAlunoService alunoService
           )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _professorService = service;
            _alunoService = alunoService;

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
                    Email = registerModel.Email,
                    RoleName = registerModel.RoleName
                };
               
                var result = await _userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {
                    bool roleExists = await _roleManager.RoleExistsAsync(registerModel.RoleName);
                    if (!roleExists)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(registerModel.RoleName));
                    }

                    if (!await _userManager.IsInRoleAsync(user, registerModel.RoleName))
                    {
                        await _userManager.AddToRoleAsync(user, registerModel.RoleName);
                    }

                    var resultSignIn = await _signInManager.PasswordSignInAsync(registerModel.UserName, registerModel.Password, false, false);
                    if (resultSignIn.Succeeded)
                    {
                        var usuario = await _userManager.FindByNameAsync(registerModel.UserName);
                        if (usuario.RoleName.Equals("Aluno"))
                        {
                            var dto = new EstudanteDTO();
                            dto.EstudanteSessao = usuario.Id;
                            _alunoService.Add(dto);
                           
                        }
                        if (usuario.RoleName.Equals("Professor"))
                        {
                            var dto = new ProfessorDTO();
                            dto.ProfessorSessao = usuario.Id;
                            _professorService.Add(dto);
                            return RedirectToAction("Index", "Home", new { id = dto.ProfessorSessao });
                        }
                      
                    }

                }

            }
            return RedirectToAction("Index", "Login");

        }

        [HttpPost, ActionName("LoginPost")]
        public async Task<IActionResult> LoginPost([FromForm] UsuarioDTO loginModel)
        {
            if (!string.IsNullOrEmpty(loginModel.UserName))
            {
                var user = await _signInManager.UserManager.FindByNameAsync(loginModel.UserName);

                if (user != null)
                {
                    var roles = await _signInManager.UserManager.GetRolesAsync(user);
                    if (ModelState.IsValid)
                    {
                        var EhProfessor = roles.Where(x => x.Equals("Professor")).Any();
                        if (EhProfessor)
                        {
                            var result = await _signInManager.PasswordSignInAsync(user.UserName, loginModel.Password, false, false);

                            if (result.Succeeded)
                                return RedirectToAction("Index", "Professor", new { id = user.Id });
                        }


                        else
                        {
                            var EhAluno = roles.Where(x => x.Equals("Aluno")).Any();
                            if (EhAluno)
                            {
                                var result = await _signInManager.PasswordSignInAsync(user.UserName, loginModel.Password, false, false);

                                if (result.Succeeded)
                                    return RedirectToAction("Index", "Aluno", new { id = user.Id });
                            }
                        }
                    }

                }
                ModelState.AddModelError("", "Usuário não é professor , tente no usuário jogador.");
                return RedirectToAction("Index", "Login");

            }
            ModelState.AddModelError("Invalid!", "Usuário Inválido");
            return RedirectToAction("Index", "Login");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index");
        }
    }

}

