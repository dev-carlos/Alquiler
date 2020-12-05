using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Alquiler
{
   public abstract class Vehiculo : I_Alquilable
    {
        public String matricula { get; set; }
        public Enums.Marca marca { get; set; }
        public Enums.TipoVehiculo tipo { get; set; }
        public Boolean alquilado { get; set; } = false;
        public static String marcaEnOferta { get; set; }

        public abstract double calcularPrecio();
        
        public bool alquilar()
        {
            Boolean salida = false;
            if (this.alquilado == salida)
            {
                this.alquilado = true;
                salida = true;
            }
            return salida;

        }
        public bool devolver()
        {
            Boolean salida = false;
            if (this.alquilado == true)
            {
                this.alquilado = false;
                salida = true;
            }
            return salida;
        }

        public Boolean esIgual(Vehiculo v)
        {
            Boolean igual = false;
            if (this.matricula.Equals(v.matricula))
            {
                igual = true;
            }
            return igual;
        }

        public Boolean comprobarMat()
        {
            Boolean salida = true;
            Regex myRegularExpression = new Regex("[^a-zA-Z0-9]");
            if(this.matricula != null)
            {
                if (this.matricula.Length < 4 || this.matricula.Length > 12 || this.matricula.Equals(null))
                {
                    salida = false;
                }
                else if (myRegularExpression.IsMatch(matricula))
                {
                    salida = false;
                }
            }
            else
            {
                salida = false;
            }
            

            return salida;
        }
    }
}
