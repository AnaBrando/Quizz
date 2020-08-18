using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using Infra.Context;
using Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Service.NivelService;
using Service.PerguntaService;
using Service.PontuacaoService;
using Service.ProfessorService;
using Service.QuizzService;

namespace CrossCutting
{
    public class Injector
    {
        public static void RegistrarServicos(IServiceCollection services)
        {
            services.AddScoped<IRespostaRepository, RespostaRepository>();
            services.AddScoped<INivelRepository, NivelRepository>();
            services.AddScoped<IQuizzRepository, QuizzRepository>();
            services.AddScoped<IPontuacaoRepository, PontuacaoRepository>();
            services.AddScoped<IPerguntaRepository, PerguntaRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();

            services.AddScoped<IQuizzService,QuizzService>();
            services.AddScoped<IPerguntaService, PerguntaService>();
            services.AddScoped<IPerguntaService, PerguntaService>();
            services.AddScoped<IProfessorService, ProfessorService>();

            services.AddScoped<INivelService, NivelService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<BancoContext>();

         //   services.AddIdentity<Usuario, IdentityRole>()
         //.AddEntityFrameworkStores<UserDbContext>();
        }
    }
}
