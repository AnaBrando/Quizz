using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Service.AlunoService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestesUnitarios
{
    [TestClass]
    public class RespostasTestes
    {

        private readonly IAlunoService _service;
        private readonly Mock<IPerguntaRepository> _mock = new Mock<IPerguntaRepository>();
        private readonly Mock<IPontuacaoRepository> _mock2 = new Mock<IPontuacaoRepository>();
        private readonly Mock<IEstudanteRepository> _mock3 = new Mock<IEstudanteRepository>();
        public RespostasTestes()
        {
            _service = new AlunoService(_mock.Object, _mock2.Object, _mock3.Object);
        }

        public List<Pergunta> MockListaPergunta()
        {
            var json = File.ReadAllText(@"C:\Users\anabr\Documents\Quizz\Infra\MockUnitTests\Perguntas.json", Encoding.GetEncoding("iso-8859-1"));

            var perguntas = JsonConvert.DeserializeObject<List<Pergunta>>(json);

            return perguntas;
        }
        [TestMethod]
        
        public void AcertouPergunta()
        {
            //arrange
            var pergunta = MockListaPergunta().First();
            //action
            var resposta = _service.Acertou(pergunta.PerguntaId, pergunta.OpcaoCerta);
            //assert
            Assert.IsTrue(resposta);

        }
        [TestMethod]
        public void Pontuou()
        {
            //arrange
            var pergunta = MockListaPergunta().First();

            //condicional
            var resposta = _service.Acertou(pergunta.PerguntaId, pergunta.OpcaoCerta);

            //seAcertou
            if (resposta)
            {
                //action Pontuar
                var x = _service.Pontuou(pergunta.PerguntaId);
            }
        }


    }
}