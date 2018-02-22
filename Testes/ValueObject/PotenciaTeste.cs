using System;
using Domain.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testes
{
    [TestClass]
    [TestCategory("Value Object")]
    public class PotenciaTeste
    {
        [TestMethod]
        public void AoInformarUmaPotenciaAbaixoDoPermitidoRetornarErro()
        {
            var potencia = new Potencia(-5);
            Assert.IsTrue(potencia.Invalid);
        }

        [TestMethod]
        public void AoInformarUmaPotenciaAcimaDoPermitidoRetornarErro()
        {
            var potencia = new Potencia(16);
            Assert.IsTrue(potencia.Invalid);
        }

        [TestMethod]
        public void AoInformarUmaPotenciaNoValorPermitidoEstaValido()
        {
            var potencia = new Potencia(9);
            Assert.IsTrue(potencia.Valid);
        }
    }
}
