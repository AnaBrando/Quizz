using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DTO
{
    public class PerguntaDTO
    {
        public PerguntaDTO()
        {
            this.niveis = new List<Nivel>();
        }
        public int PerguntaId { get; set; }
        public int? NivelId { get; set; }
        public int? RespostaId { get; set; }
        public int QuizzId { get; set; }
        [Required(ErrorMessage="Opcao A é obrigatório")]
        public string OpcaoA { get; set; }
        [Required(ErrorMessage="Opcao B é obrigatório")]
        public string OpcaoB { get; set; }
        [Required(ErrorMessage="Opcao C é obrigatório")]
        public string OpcaoC { get; set; }
        [Required(ErrorMessage="Opcao D é obrigatório")]
        public string OpcaoD { get; set; }
        [Required(ErrorMessage="Descrição é obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage="Opcao Certa é obrigatório")]
        public string OpcaoCerta { get; set; }
        public virtual NivelDTO Nivel { get; set; }
        public virtual Quizz Quizz { get; set; }
        
        [Required(ErrorMessage="Resposta é obrigatório")]
        public virtual RespostaDTO Resposta { get; set; }

        [Required(ErrorMessage="Nivel é obrigatório")]

        public List<Nivel> niveis { get; set; }
       
    }
}
