using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Application
{
    public interface IResposta
    {

        int ObterPerguntaId(PerguntaDTO perguntaDTO);

     
    }
}
