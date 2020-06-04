using CrossCutting.Contexto;
using CrossCutting.User;
using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using Infra.Context;
using Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Service;
using Service.Perguntas;

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
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();


            services.AddScoped<IResposta,RespostaService>();
            services.AddScoped<IPerguntaService, PerguntaService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddIdentity<Usuario, IdentityRole>(options =>
            //{
            //    options.Password.RequireDigit = true;
            //    options.Password.RequiredLength = 7;
            //    options.Password.RequireUppercase = true;
            //    options.User.RequireUniqueEmail = true;
            //})
            //.AddEntityFrameworkStores<UserDbContext>();

        }
    }
}
