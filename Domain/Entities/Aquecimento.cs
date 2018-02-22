using System;
using Domain.ValueObject;
using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Entities
{
    public class Aquecimento : Notifiable
    {
        public Aquecimento(Tempo tempo, Potencia potencia, Caracter caracter, string chave)
        {
            Tempo = tempo;
            Potencia = potencia;
            Caracter = caracter;
            Chave = chave;
        }

        public Tempo Tempo { get; private set; }
        public Potencia Potencia { get; private set; }
        public Caracter Caracter { get; private set; }
        public string Chave { get; private set; }
    }
}