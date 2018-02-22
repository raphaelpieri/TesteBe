using System.IO;
using Domain.Commands.Input;
using Domain.Commands.Result;
using Domain.Handlers;

namespace App.Controller
{
    public class AquecimentoController
    {
        private AquecimentoHandler _handler;


        public AquecimentoResult RealizarAquecimento(AquecimentoCommand command)
        {
            if(File.Exists(command.CampoString))
                _handler = new AquecimentoArquivoHandler();
            else
                _handler = new AquecimentoStringHandler();

            return ExecutarAquecimento(command);
        }

        private AquecimentoResult ExecutarAquecimento(AquecimentoCommand command)
        {
            return (AquecimentoResult)_handler.Handle(command);
        }
    }
}