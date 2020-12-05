using System;
using System.Collections.Generic;
using System.Text;

namespace Alquiler
{
    class Furgoneta : Vehiculo
    {
        public int cargaMaxima { get; set; }

        public Furgoneta()
        {

        }

        public Furgoneta(string matricula, Enums.Marca marca, Enums.TipoVehiculo tipo, int carga, Boolean alquilado = false)
        {
            this.matricula = matricula;
            this.marca = marca;
            this.tipo = tipo;
            this.cargaMaxima = carga;
            this.alquilado = alquilado;
        }

        

        public override double calcularPrecio()
        {
            double precio = 0;
            if (this.tipo == Enums.TipoVehiculo.Diesel && this.cargaMaxima <= 1400 || this.tipo == Enums.TipoVehiculo.Gasolina && this.cargaMaxima <= 1400)
            {
                precio = 350;
            }
            else if (this.tipo == Enums.TipoVehiculo.Diesel && this.cargaMaxima > 1400 || this.tipo == Enums.TipoVehiculo.Gasolina && this.cargaMaxima > 1400)
            {
                precio = 450;
            }
            else if (this.tipo == Enums.TipoVehiculo.Hibrido && this.cargaMaxima <= 1400 || this.tipo == Enums.TipoVehiculo.Electrico && this.cargaMaxima <= 1400)
            {
                precio = 450;
            }
            else if (this.tipo == Enums.TipoVehiculo.Hibrido && this.cargaMaxima > 1400 || this.tipo == Enums.TipoVehiculo.Electrico && this.cargaMaxima > 1400)
            {
                precio = 550;
            }

            if (Principal.marcaOferta != null)
            {
                if (Principal.marcaOferta.Equals(this.marca.ToString()))
                {
                    precio = precio * 0.90;
                }
            }


            return precio;
        }

        
    }
}
