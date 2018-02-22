using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.ValueObject
{
    public class Caracter : Notifiable
    {
        public Caracter(string valor)
        {
            Valor = valor;
            AddNotifications(new Contract()
                .Requires());
        }

        public string Valor { get; private set; }
    }
}