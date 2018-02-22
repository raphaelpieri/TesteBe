using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;

namespace Infra.Repositories
{
    public class ProgramaRepositorio : IProgramaRepositorio
    {
        private readonly TesteContexto _contexto;

        public ProgramaRepositorio(TesteContexto contexto)
        {
            _contexto = contexto;
        }

        public void Novo(Programa programa)
        {
            _contexto.Programas.Add(programa);
        }

        public Programa Get(string nome)
        {
            return _contexto.Programas.FirstOrDefault(x => x.Nome.Equals(nome));
        }

        public IEnumerable<Programa> Get()
        {
            return _contexto.Programas;
        }
    }
}