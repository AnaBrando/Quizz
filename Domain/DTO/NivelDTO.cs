using System.Collections.Generic;

namespace Domain.DTO
{
    public class NivelDTO
    {
        public NivelDTO()
        {
            Pergunta = new HashSet<PerguntaDTO>();
        }

        public int NivelId { get; set; }
        public string Descricao { get; set; }
        public int PontuacaoId { get; set; }
        public virtual PontuacaoDTO Pontuacao { get; set; }
        public virtual ICollection<PerguntaDTO> Pergunta { get; set; }

    }
}
