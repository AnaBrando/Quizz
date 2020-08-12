using Domain.Interfaces.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repository
{
    public class PontuacaoRepository : RepositoryBase<Pontuacao> , IPontuacaoRepository
    {
    }
}
