using Domain;
using Domain.DTO;
using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.PerguntaService
{
    public class PerguntaService : IPerguntaService
    {

        public readonly IPerguntaRepository perguntaRepository;

        public PerguntaService(IPerguntaRepository repo)
        {
            this.perguntaRepository = repo;
        }
        public void Add(PerguntaDTO pergunta)
        {
            var obj = new Pergunta();
            obj.Descricao = pergunta.Descricao;
            obj.OpcaoA = pergunta.OpcaoA;
            obj.OpcaoB = pergunta.OpcaoB;
            obj.OpcaoC = pergunta.OpcaoC;
            obj.OpcaoD = pergunta.OpcaoD;
            obj.OpcaoCerta = pergunta.Resposta_id;
            //obj.Nivel = pergunta.NivelDTO;
            //perguntaRepository.Add(pergunta);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(PerguntaDTO pergunta)
        {
            throw new NotImplementedException();
        }

        async Task<PerguntaDTO> IPerguntaService.QuizzIT(int id)
        {
            var perguntaDTO = new PerguntaDTO();
            perguntaDTO.Quizz_id =id;
            return perguntaDTO;
        }
    }
}
