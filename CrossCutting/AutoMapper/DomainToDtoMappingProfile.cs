using AutoMapper;
using Domain.DTO;
using Domain.Models;

namespace CrossCutting.AutoMapper
{

    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {

            CreateMap<Pergunta, PerguntaDTO>();
            CreateMap<Resposta, RespostaDTO>();
            CreateMap<Estudante, EstudanteDTO>();
        }
    }
}
