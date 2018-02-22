namespace Shareds.Commands
{
    public interface ICommandResult
    {
        bool Sucesso { get; set; }
        string Mensagem { get; set; }
        object Data { get; set; }
    }
}