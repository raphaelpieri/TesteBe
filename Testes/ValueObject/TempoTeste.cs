using System;
using Domain.ValueObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testes.ValueObject
{
    [TestClass]
    [TestCategory("Value Object")]
    public class TempoTeste
    {
        [TestMethod]
        public void DesejoInformarUmTempoSemValor()
        {
            var tempo = new Tempo(TimeSpan.Zero);
            Assert.IsTrue(tempo.Invalid);
        }

        [TestMethod]
        public void DesejoInformarUmTempoAbaixoDoPermitido()
        {
            var tempo = new Tempo(TimeSpan.FromSeconds(4));
            Assert.IsTrue(tempo.Invalid);
        }


        [TestMethod]
        public void DesejoInformarUmTempoAcimaDoPermitido()
        {
            var tempo = new Tempo(TimeSpan.FromMinutes(4));
            Assert.IsTrue(tempo.Invalid);
        }

        [TestMethod]
        public void DesejoInformarUmTempoCorreto()
        {
            var tempo = new Tempo(TimeSpan.FromMinutes(1));
            Assert.IsTrue(tempo.Invalid);
        }
    }
}
