using Domain.DTO;
using Domain.Models;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Interfaces.Application
{
    public interface INivelService
    {
        void Add(NivelDTO pergunta);
        void Update(NivelDTO pergunta);
        void Save();
        ICollection<Nivel> buscarNiveis();
    }
}
