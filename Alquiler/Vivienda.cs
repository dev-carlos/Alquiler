using System;
using System.Collections.Generic;
using System.Text;

namespace Alquiler
{
    class Vivienda : Inmueble
    {
        

        public int numeroDeHabitaciones { get; set; }

        public Vivienda(string referencia, Enums.Poblacion poblacion, double precioBase, int numeroDeHabitaciones , Boolean alquilado = false)
        {
            this.referencia = referencia;
            this.poblacion = poblacion;
            this.precioBase = precioBase;
            this.numeroDeHabitaciones = numeroDeHabitaciones;
            this.alquilado = alquilado;

        }
        public Vivienda()
        {

        }

        public override double calcularPrecio()
        {
            double precioMensual = this.precioBase;
            if(this.numeroDeHabitaciones > 3)
            {
                precioMensual += 200;
            }
            

            if (Principal.poblacionOferta.Equals(this.poblacion.ToString()))
            {
                precioMensual = precioMensual * 0.75;
            }
            return precioMensual;
        }
    }
}
