using System.Linq;
using App.Controller;
using Domain.Commands.Input;
using Domain.Handlers;
using Infra;
using Infra.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testes.ProgramaControllerTestes
{
    [TestClass]
    [TestCategory("Programa Controller")]
    public class ProgramaControllerTest
    {
        private readonly ProgramaController _controller;

        public ProgramaControllerTest()
        {
            var contexto = new TesteContexto();
            var programaRepositorio = new ProgramaRepositorio(contexto);
            var programarHandler = new ProgramaHandler(programaRepositorio);
            _controller = new ProgramaController(programarHandler, programaRepositorio);
        }

        [TestMethod]
        public void DeveCriarUmNovoPrograma()
        {
            var novoPrograma = new NovoProgramaCommand("Frango Grelhado", "#", "00:01:30", 5, "Frango",
                "Deve ser feito congelado");

            var result = _controller.Push(novoPrograma);

            Assert.IsTrue(result.Sucesso);
        }

        [TestMethod]
        public void QueroQueReturna3RegistrosDeProgramas()
        {
            var novoPrograma = new NovoProgramaCommand("Frango Grelhado", "#", "00:01:30", 5, "Frango",
                "Deve ser feito congelado");
            _controller.Push(novoPrograma);

            var novoPrograma2 = new NovoProgramaCommand("Frango Grelhado 2", "#", "00:01:30", 5, "Frango",
                "Deve ser feito congelado");
            _controller.Push(novoPrograma2);

            var novoPrograma3 = new NovoProgramaCommand("Frango Grelhado 3", "#", "00:01:30", 5, "Frango",
                "Deve ser feito congelado");
            _controller.Push(novoPrograma3);


            var returno = _controller.Get();

            Assert.AreEqual(3, returno.Count());
        }

        [TestMethod]
        public void QueroQueReturnaO1RegistrosDe2Registados()
        {
            var nome = "Frango Grelhado";
            var novoPrograma = new NovoProgramaCommand(nome, "#", "00:01:30", 5, "Frango",
                "Deve ser feito congelado");
            _controller.Push(novoPrograma);

            var novoPrograma2 = new NovoProgramaCommand("Frango Grelhado 2", "#", "00:01:30", 5, "Frango",
                "Deve ser feito congelado");
            _controller.Push(novoPrograma2);


            var returno = _controller.Get(nome);

            Assert.AreEqual(nome, returno.Nome);
        }

    }
}