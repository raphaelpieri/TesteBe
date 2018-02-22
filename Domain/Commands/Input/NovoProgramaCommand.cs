using Shareds.Commands;

namespace Domain.Commands.Input
{
    public class NovoProgramaCommand : ICommand
    {
        public NovoProgramaCommand(string nome, string caracter, string tempo, int potencia, string chave, string instrucoes)
        {
            Nome = nome;
            Caracter = caracter;
            Tempo = tempo;
            Potencia = potencia;
            Chave = chave;
            Instrucoes = instrucoes;
        }

        public string Nome { get; private set; }
        public string Caracter { get; private set; }
        public string Tempo { get; private set; }
        public int Potencia { get; private set; }
        public string Chave { get; private set; }
        public string Instrucoes { get; private set; }
    }
}