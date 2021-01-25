using System;

namespace RhinoMock
{
    public class Transporte : ITransporte
    {
        public Transporte()
        {
        }

        public int Capacidad { get; internal set; }
        public int CargaActual { get; private set; }

        public void Cargar(int peso)
        {
             CargaActual += peso;
        }

        public double PorcentajeCarga()
        {
            return CargaActual / Convert.ToDouble(Capacidad);
        }
    }
}