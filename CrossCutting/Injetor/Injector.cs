using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
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
         
            services.AddScoped<IPerguntaRepository, PerguntaRepository>();


            services.AddScoped<IQuizzService,QuizzService>();
          

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


         //   services.AddIdentity<Usuario, IdentityRole>()
         //.AddEntityFrameworkStores<UserDbContext>();
        }
    }
}
