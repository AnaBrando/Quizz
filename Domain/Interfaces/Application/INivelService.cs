using Domain.DTO;

namespace Domain.Interfaces.Application
{
    public interface INivelService
    {
        void Add(NivelDTO pergunta);
        void Update(NivelDTO pergunta);
        void Save();
        PerguntaDTO buscarNiveis();
    }
}
