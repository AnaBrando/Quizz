using Domain.DTO;
using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.RespostaService
{
    public class RespostaService : IRespostaService
    {
        public readonly IRespostaRepository _repositoyResposta;

        public readonly IPerguntaRepository _repositoryPergunta;

        public RespostaService(IRespostaRepository repo, IPerguntaRepository _repo)
        {
            _repositoyResposta = repo;
            _repositoryPergunta = _repo;
        }
        public void Add(RespostaDTO reposta)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void GerarReposta(string EstudanteId,int perguntaId)
        {
            Resposta resposta = new Resposta();
            resposta.Descricao = DateTime.Now.ToString();
            resposta.EstudanteId = EstudanteId;
            resposta.PerguntaId = perguntaId;
            _repositoyResposta.Add(resposta);
        }

        public ICollection<RespostaDTO> GetAll(int quiizId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(RespostaDTO pergunta)
        {
            throw new NotImplementedException();
        }
    }
}
