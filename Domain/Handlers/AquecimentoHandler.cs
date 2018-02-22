using System.Text;
using Domain.Commands.Input;
using Domain.Commands.Result;
using Domain.Entities;
using Domain.ValueObject;
using Flunt.Notifications;
using Shareds.Commands;

namespace Domain.Handlers
{
    public abstract class AquecimentoHandler : Notifiable, ICommandHandler<AquecimentoCommand>
    {
        public ICommandResult Handle(AquecimentoCommand command)
        {
            var tempo = new Tempo(command.Tempo);
            var potencia = new Potencia(command.Potencia);
            var caracter = new Caracter(command.Caracter);

            var aquecimento = new Aquecimento(tempo, potencia, caracter, command.Chave);

            AddNotifications(tempo.Notifications);
            AddNotifications(potencia.Notifications);
            AddNotifications(caracter.Notifications);

            VerificaSeAChaveEstaCorreta(command.CampoString, aquecimento.Chave);
            
            if (Invalid)
                return new AquecimentoResult(false, "Por favor corrija os campos abaixo", Notifications);

            var retorno = RealizaAquecimento(command.CampoString, aquecimento);
            
            return new AquecimentoResult(true, "Aquecimento realizado com sucesso", retorno);
        }

        protected abstract string RealizaAquecimento(string campoString, Aquecimento aquecimento);

        protected abstract void VerificaSeAChaveEstaCorreta(string campoString, string aquecimentoChave);
    }
}