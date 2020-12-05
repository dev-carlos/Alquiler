using System;
using System.Collections.Generic;
using System.Text;

namespace Alquiler
{
    interface I_Alquilable
    {
        public abstract double calcularPrecio();


        public abstract Boolean alquilar();


        public abstract Boolean devolver();
       
    }
}
