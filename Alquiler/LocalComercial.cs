using System;
using System.Collections.Generic;
using System.Text;

namespace Alquiler
{
    class LocalComercial : Inmueble
    {
        public int tamano { get; set; }
        public Boolean reformado { get; set; }

        public LocalComercial(string referencia, Enums.Poblacion poblacion, double precioBase, Boolean reformado, int tamano, Boolean alquilado = false)
        {
            this.referencia = referencia;
            this.poblacion = poblacion;
            this.precioBase = precioBase;
            this.reformado = reformado;
            this.tamano = tamano;
            this.alquilado = alquilado;
            
        }

        

        public LocalComercial()
        {
        }

        public override double calcularPrecio()
        {
            double precioMensual = this.precioBase;

            if (this.reformado == true)
            {
                precioMensual +=  100;
            }
            if (this.tamano > 200)
            {
                precioMensual += 100;
            }

            if (Principal.poblacionOferta.Equals(this.poblacion.ToString()))
            {
                precioMensual = precioMensual * 0.95;
            }
            return precioMensual;
        }

    }
}
