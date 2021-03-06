﻿using AutoMapper;
using CrossCutting.AutoMapper;
using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using Infra.Context;
using Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Service.AlunoService;
using Service.NivelService;
using Service.PerguntaService;
using Service.PontuacaoService;
using Service.ProfessorService;
using Service.QuizzService;
using Service.ReportService;
using Service.RespostaService;

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
            services.AddScoped<IEstudanteRepository, EstudanteRepository>();
            services.AddScoped<IEstudanteRespostaRepository, EstudanteRespostaRepository>();

            //mapper
            IMapper mapper = AutoMapperConfiguration.RegisterMappings().CreateMapper();
            services.AddSingleton(mapper);


            services.AddScoped<IQuizzService,QuizzService>();
            services.AddScoped<IRespostaService, RespostaService>();
            services.AddScoped<IPerguntaService, PerguntaService>();
            services.AddScoped<IProfessorService, ProfessorService>();
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<INivelService, NivelService>();
            services.AddScoped<IViewRenderService, ViewRenderService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IPdfGeneratorService, PdfGeneratorService>();
            
            services.AddScoped<BancoContext>();

            
            //   services.AddIdentity<Usuario, IdentityRole>()
            //.AddEntityFrameworkStores<UserDbContext>();
        }
    }
}
