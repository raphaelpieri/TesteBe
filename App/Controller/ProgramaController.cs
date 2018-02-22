using System.Collections.Generic;
using System.Linq;
using App.Queries;
using Domain.Commands.Input;
using Domain.Commands.Result;
using Domain.Entities;
using Domain.Handlers;
using Domain.Repositories;

namespace App.Controller
{
    public class ProgramaController
    {
        private readonly ProgramaHandler _handler;
        private readonly IProgramaRepositorio _repositorio;

        public ProgramaController(ProgramaHandler handler, IProgramaRepositorio repositorio)
        {
            _handler = handler;
            _repositorio = repositorio;
        }

        public NovoProgramaResult Push(NovoProgramaCommand command)
        {
            return (NovoProgramaResult)_handler.Handle(command);
        }

        public IEnumerable<GetListProgramas> Get()
        {
            return _repositorio.Get().Select(x => new GetListProgramas(){Nome = x.Nome}).ToList();
        }

        public GetPrograma Get(string nome)
        {
            var programa = _repositorio.Get(nome);
            return TransformarDados(programa);
        }

        private GetPrograma TransformarDados(Programa programa)
        {
            return new GetPrograma()
            {
                Tempo = programa.Aquecimento.Tempo.ToString(),
                Potencia = programa.Aquecimento.Potencia.Forca,
                Nome = programa.Nome,
                Caracter = programa.Aquecimento.Caracter.Valor,
                Instrucoes = programa.Instrucoes,
                Chave = programa.Aquecimento.Chave
            };
        }
    }
}