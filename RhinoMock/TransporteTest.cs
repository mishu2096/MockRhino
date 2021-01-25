using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhinoMock
{
    [TestClass]
    public class TransporteTest
    {
        [TestMethod]
        public void SiElTransporteEstaLlenoLaMitadOMasPuedePartirMock()
        {
            var transporte = MockRepository.GenerateStub<ITransporte>();
            transporte.Stub(t => t.PorcentajeCarga()).Return(0.5);

            var mercancia = new Mercancia();
            mercancia.Peso = 15;
            mercancia.Enviar(transporte);

            Assert.IsTrue(mercancia.SeEnvio);
            transporte.AssertWasCalled(t => t.PorcentajeCarga());
            transporte.AssertWasCalled(t => t.Cargar(mercancia.Peso));
        }

        [TestMethod]
        public void SiElTransporteEstaLlenoLaMitadOMasPuedePartir()
        {
            var transporte = new Transporte();
            transporte.Capacidad = 1000;
            transporte.Cargar(500);

            var mercancia = new Mercancia();
            mercancia.Peso = 15;
            mercancia.Enviar(transporte);

            Assert.IsTrue(mercancia.SeEnvio);
        }
    }
}
