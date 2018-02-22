using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProgramaRepositorio
    {
        void Novo(Programa programa);
        Programa Get(string nome);
        IEnumerable<Programa> Get();
    }
}