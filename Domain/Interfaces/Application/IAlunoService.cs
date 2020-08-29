namespace Domain.Interfaces.Application
{
    public interface IAlunoService
    {
        void Responder(int perguntaId,string resposta);

        bool Acertou(string resposta);

        void Pontuar(int perguntaId);
    }
}
