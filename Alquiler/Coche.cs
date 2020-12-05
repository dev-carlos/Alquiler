using System;
using System.Collections.Generic;
using System.Text;

namespace Alquiler
{
    class Coche : Vehiculo
    {
        public int numeroDePlazas { get; set; }

        public Coche()
        {

        }


        public Coche(string matricula, Enums.Marca marca, Enums.TipoVehiculo tipo, int numeroDePlazas, Boolean alquilado = false)
        {
            this.matricula = matricula;
            this.marca = marca;
            this.tipo = tipo;
            this.numeroDePlazas = numeroDePlazas;
            this.alquilado = alquilado;
        }
        

        public override double calcularPrecio()
        {
            double precio = 0;
            if(this.tipo == Enums.TipoVehiculo.Diesel || this.tipo == Enums.TipoVehiculo.Gasolina)
            {
                precio = 400;
            }
            else if(this.tipo == Enums.TipoVehiculo.Diesel || this.tipo == Enums.TipoVehiculo.Gasolina && this.numeroDePlazas > 3)
            {
                precio = 300;
            }
            else if (this.tipo == Enums.TipoVehiculo.Diesel || this.tipo == Enums.TipoVehiculo.Gasolina && this.numeroDePlazas <= 3)
            {
                precio = 200;
            }

            if(Principal.marcaOferta != null)
            {
                
                if (Principal.marcaOferta.Equals(this.marca.ToString()))
                {
                    precio = precio * 0.85;
                }
            }
            
            return precio;

        }

        
    }
}
