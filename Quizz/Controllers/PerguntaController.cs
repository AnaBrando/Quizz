using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Infra.Context;

namespace Quizz.Controllers
{
    public class PerguntaController : Controller
    {

        public IActionResult Create()
        {
            return View();
        }

    }
}
