using System;
using System.IO;
using App.Controller;
using Domain.Commands.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testes.ProgramaControllerTestes
{
    [TestClass]
    [TestCategory("AquecimentoController")]
    public class AquecimentoControllerTest
    {
        private const string Arquivo = "teste.txt";
        private const string ArquivoErro = "erro.txt";
        private readonly AquecimentoController _controller;
        public AquecimentoControllerTest()
        {
            _controller = new AquecimentoController();;

            ExcluirECriarArquivos(Arquivo, "Frango");
            ExcluirECriarArquivos(ArquivoErro, "Macarrao");
        }


        [TestMethod]
        public void RealizarAquecimentoComString()
        {
            var aquecimento = new AquecimentoCommand("00:00:30", 2, "*", null, String.Empty);
            var result = _controller.RealizarAquecimento(aquecimento);
            Assert.IsTrue(result.Sucesso);
        }

        [TestMethod]
        public void RealizarAquecimentoComStringComChave()
        {
            var aquecimento = new AquecimentoCommand("00:00:30", 2, "*", "Frango", "Frango");
            var result = _controller.RealizarAquecimento(aquecimento);
            Assert.IsTrue(result.Sucesso);
        }

        [TestMethod]
        public void RealizarAquecimentoComStringComChaveMasComCampoStringDiferenteDeveOcorrerErro()
        {
            var aquecimento = new AquecimentoCommand("00:00:30", 2, "*", "Frango", "Macarrao");
            var result = _controller.RealizarAquecimento(aquecimento);
            Assert.IsFalse(result.Sucesso);
        }

        [TestMethod]
        public void RealizarAquecimentoComArquivoComChave()
        {
            var aquecimento = new AquecimentoCommand("00:00:30", 2, "*", "Frango",Arquivo);
            var result = _controller.RealizarAquecimento(aquecimento);
            Assert.IsTrue(result.Sucesso);
        }

        [TestMethod]
        public void RealizarAquecimentoComArquivoComChaveComErro()
        {
            var aquecimento = new AquecimentoCommand("00:00:30", 2, "*", "Frango", ArquivoErro);
            var result = _controller.RealizarAquecimento(aquecimento);
            Assert.IsFalse(result.Sucesso);
        }
        private void ExcluirECriarArquivos(string arquivo, string texto)
        {
            if(File.Exists(arquivo))
                File.Delete(arquivo);

            using (var x = File.CreateText(arquivo))
            {
                x.WriteLine(texto);
            }
        }
    }
}