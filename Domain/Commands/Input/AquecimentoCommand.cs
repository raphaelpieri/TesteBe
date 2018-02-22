using Shareds.Commands;

namespace Domain.Commands.Input
{
    public class AquecimentoCommand : ICommand
    {
        public AquecimentoCommand(string tempo, int potencia, string caracter, string chave, string campoString)
        {
            Tempo = tempo;
            Potencia = potencia;
            Caracter = caracter;
            Chave = chave;
            CampoString = campoString;
        }

        public string Tempo { get; private set; }
        public int Potencia { get; private set; }
        public string Caracter { get; private set; }
        public string Chave { get; private set; }
        public string CampoString { get; private set; }
    }
}