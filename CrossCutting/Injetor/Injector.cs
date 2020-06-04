using Domain.Interfaces.Repository;
using Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

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
        }
    }
}
