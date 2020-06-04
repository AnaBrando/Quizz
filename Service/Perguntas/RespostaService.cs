using Domain;
using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;

namespace Service
{
    public class RespostaService : IResposta
    {
        private readonly IRespostaRepository _repo;

        public RespostaService(IRespostaRepository repo)
        {
            this._repo = repo;
        }


        public string ObterRespostaCerta(int id)
        {
            return this._repo.GetById(id).Result.RespostaCerta;
        }


    }
}
