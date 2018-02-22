using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.ValueObject
{
    public class Potencia : Notifiable
    {
        public Potencia(int forca)
        {
            Forca = forca == 0 ? 10 : forca;
            AddNotifications(new Contract()
                .Requires()
                .IsBetween(Forca, 1, 10, "Potencia", "Potencia fora da faixa permitida"));

        }

        public int Forca { get; private set; }
    }
}