using System.Text;
using Domain.Entities;

namespace Domain.Handlers
{
    public class AquecimentoStringHandler : AquecimentoHandler
    {
        protected override string RealizaAquecimento(string campoString, Aquecimento aquecimento)
        {
            var campoNovo = new StringBuilder(campoString);
            for (var i = 1; i <= aquecimento.Tempo.Horario.TotalSeconds; i++)
            {
                for (var j = 1; j <= aquecimento.Potencia.Forca; j++)
                {
                    campoNovo.Append(aquecimento.Caracter.Valor);
                }
            }
            return campoNovo.ToString();
        }

        protected override void VerificaSeAChaveEstaCorreta(string campoString, string aquecimentoChave)
        {
            if (!string.IsNullOrEmpty(campoString) && !campoString.Contains(aquecimentoChave))
                AddNotification("Campo String", "Campo de String não contém chave igual ao programa de aqueciemnto");
        }
    }
}