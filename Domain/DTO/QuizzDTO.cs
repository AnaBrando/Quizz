using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class QuizzDTO
    {
        public QuizzDTO()
        {
            Pergunta = new HashSet<PerguntaDTO>();
        }

        public int QuizzId { get; set; }
        public int ProfessorId { get; set; }
        public DateTime DataInclusao { get; set; }
        [Required(ErrorMessage="Descrição é obrigatória")]
        
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<PerguntaDTO> Pergunta { get; set; }
        public string ProfessorSessao { get; set; }
        public virtual ProfessorDTO Professor { get; set; }
    }
}
