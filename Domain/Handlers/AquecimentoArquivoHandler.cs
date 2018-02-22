using System.IO;
using System.Security.Cryptography.X509Certificates;
using Domain.Entities;

namespace Domain.Handlers
{
    public class AquecimentoArquivoHandler : AquecimentoHandler
    {
        protected override string RealizaAquecimento(string campoString, Aquecimento aquecimento)
        {
            using (var x = File.AppendText(campoString))
            {
                for (var i = 1; i <= aquecimento.Tempo.Horario.TotalSeconds; i++)
                {
                    for (var j = 1; j <= aquecimento.Potencia.Forca; j++)
                    {
                        x.Write(aquecimento.Caracter.Valor);
                    }
                    x.WriteLine();
                }
            }
            return "Arquivo gravado com sucesso";
        }

        protected override void VerificaSeAChaveEstaCorreta(string campoString, string aquecimentoChave)
        {
            using (var x = File.OpenText(campoString))
            {
                var chave = x.ReadLine();
                if (!string.IsNullOrEmpty(aquecimentoChave) && !chave.Contains(aquecimentoChave))
                    AddNotification("Campo String", "Campo de String não contém chave igual ao programa de aqueciemnto");
            }
        }
    }
}