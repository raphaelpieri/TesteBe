namespace Domain.Entities
{
    public class Programa
    {
        public Programa(string nome, string instrucoes, Aquecimento aquecimento)
        {
            Nome = nome;
            Instrucoes = instrucoes;
            Aquecimento = aquecimento;
        }

        public string Nome { get; private set; }
        public string Instrucoes { get; private set; }

        public Aquecimento Aquecimento { get; private set; }
    }
}