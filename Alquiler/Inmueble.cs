using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Alquiler
{
    public abstract class Inmueble : I_Alquilable
    {
        public String referencia { get; set; }
        public Enums.Poblacion poblacion { get; set; }
        public Double precioBase { get; set; }
        public Boolean alquilado { get; set; } = false;
        public static String poblacionEnOferta { get; set; }



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

        public Boolean esIgual(Inmueble In)
        {
            Boolean igual = false;
            if (this.referencia.Equals(In.referencia))
            {
                igual = true;
            }
            return igual;
        }

        public Boolean comprobarRef()
        {
            Boolean salida = true;
            Regex myRegularExpression = new Regex("[^a-zA-Z0-9]");
            if(this.referencia != null)
            {
                if (this.referencia.Length < 4 || this.referencia.Length > 12)
                {
                    salida = false;
                }
                else if (myRegularExpression.IsMatch(referencia))
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
