using System.Collections.Generic;
using Domain.Entities;

namespace Infra
{
    public class TesteContexto
    {
        public IList<Programa> Programas { get; private set; }

        public TesteContexto()
        {
            Programas = new List<Programa>();
        }
    }
}