using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.ValueObject
{
    public class Tempo : Notifiable
    {
        public Tempo(string horario) : this(TimeSpan.Parse(horario))
        {
            
        }
        public Tempo(TimeSpan horario)
        {
            Horario = horario;
            AddNotifications(new Contract()
                .Requires()
                .IsBetween(Horario.Seconds, 15, 120, "Tempo", "Tempo fora do intervalo permitido"));
        }

        public TimeSpan Horario { get; private set; }

        
    }
}