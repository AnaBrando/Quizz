using AutoMapper;
using Domain.DTO;
using Domain.Models;

namespace CrossCutting.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<PerguntaDTO,Pergunta>();
            CreateMap<RespostaDTO,Resposta>();
            CreateMap<EstudanteDTO,Estudante>();
} } }
