using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Alquiler
{
    public static class Principal
    {
        public static ArrayList datos = new ArrayList();
        public static List<string> arrayTxt = new List<string>();

        public static string marcaOferta = "";
        public static string poblacionOferta = "";

        public static Boolean nuevaOferta(string datoOferta)
        {
            Boolean salida = false;
            string[] marcas = Enum.GetNames(typeof(Enums.Marca));
            string[] poblaciones = Enum.GetNames(typeof(Enums.Poblacion));
            if (datoOferta.Equals(marcaOferta) || datoOferta.Equals(poblacionOferta))
            {
                salida = true;
            }
            else
            {
                foreach( string marca in marcas)
                {
                   
                    if (marca.Equals(datoOferta))
                    {
                        marcaOferta = datoOferta;
                    }
                }

                foreach( string poblacion in poblaciones)
                {
                    if (poblacion.Equals(datoOferta))
                    {
                        poblacionOferta = datoOferta;
                    }
                }
            }
            


            return salida;
        }

        public static Boolean NuevoInmueble(Inmueble In)
        {
             Boolean salida = false;
            
            if (datos.Add(In) != -1)
            {
                salida = true;
            }
             return salida;

        }

        public static Boolean NuevoVehiculo(Vehiculo In)
        {
            Boolean salida = false;

            if (datos.Add(In) != -1)
            {
                salida = true;
            }
            return salida;

        }

        public static List<string> mostrarTodos()
        {
            arrayTxt.Clear();

            foreach(Object dato in datos)
            {
                if(dato is Inmueble)
                {
                    if(dato is LocalComercial)
                    {
                        LocalComercial lc = new LocalComercial();
                        lc = dato as LocalComercial;
                        string referencia = lc.referencia;
                        Enums.Poblacion poblacion = lc.poblacion;
                        double pb = lc.precioBase;
                        int tamano = lc.tamano;
                        Boolean reformado = lc.reformado;
                        string rf = reformado == false ? "N" : "S";
                        Boolean alquilado = lc.alquilado;
                        string alq = alquilado == false ? "DISPONIBLE" : "ALQUILADO";
                        string precioTotal = lc.calcularPrecio().ToString();
                        string texto = "L " + referencia + " Poblacion: " + poblacion.ToString().ToUpper() + " PB: " + pb.ToString() + " Superficie: "+ tamano + " " + rf + " " + alq + " " + precioTotal;
                        arrayTxt.Add(texto);
                    }
                    else if(dato is Vivienda)
                    {
                        Vivienda vi = new Vivienda();
                        vi = dato as Vivienda;
                        string referencia = vi.referencia;
                        Enums.Poblacion poblacion = vi.poblacion;
                        double pb = vi.precioBase;
                        int numHab = vi.numeroDeHabitaciones;
                        Boolean alquilado = vi.alquilado;
                        string alq = alquilado == false ? "DISPONIBLE" : "ALQUILADO";
                        string precioTotal = vi.calcularPrecio().ToString();
                        string texto = "V " + referencia + " Poblacion: " + poblacion.ToString().ToUpper() + " PB: " + pb.ToString() + " " + numHab  + " " + alq + " " + precioTotal;
                        arrayTxt.Add(texto);
                    }
                }

                if (dato is Vehiculo)
                {
                    if (dato is Coche)
                    {
                        Coche ch = new Coche();
                        ch = dato as Coche;
                        string matricula = ch.matricula;
                        Enums.Marca marca = ch.marca;
                        Enums.TipoVehiculo tipo = ch.tipo;
                        int numPlazas = ch.numeroDePlazas;
                        Boolean alquilado = ch.alquilado;
                        string alq = alquilado == false ? "DISPONIBLE" : "ALQUILADO";
                        string precioTotal = ch.calcularPrecio().ToString();
                        string texto = "C " + matricula + " Marca: " + marca.ToString().ToUpper() + " Tipo: " + tipo.ToString().ToUpper() + " Plazas: " + numPlazas + " " + alq + " " + precioTotal;
                        arrayTxt.Add(texto);
                    }
                    else if (dato is Furgoneta)
                    {
                        Furgoneta fg = new Furgoneta();
                        fg = dato as Furgoneta;
                        string matricula = fg.matricula;
                        Enums.Marca marca = fg.marca;
                        Enums.TipoVehiculo tipo = fg.tipo;
                        int carga = fg.cargaMaxima;
                        Boolean alquilado = fg.alquilado;
                        string alq = alquilado == false ? "DISPONIBLE" : "ALQUILADO";
                        string precioTotal = fg.calcularPrecio().ToString();
                        string texto = "F " + matricula + " Marca: " + marca.ToString().ToUpper() + " Tipo: " + tipo.ToString().ToUpper() + " Carga max: " + carga + " " + alq + " " + precioTotal;
                        arrayTxt.Add(texto);
                    }
                }
            }

            return arrayTxt;
        }

        public static List<string> mostrarInmuebles()
        {
            arrayTxt.Clear();

            foreach(Object dato in datos)
            {
                if (dato is Inmueble)
                {
                    if (dato is LocalComercial)
                    {
                        LocalComercial lc = new LocalComercial();
                        lc = dato as LocalComercial;
                        string referencia = lc.referencia;
                        Enums.Poblacion poblacion = lc.poblacion;
                        double pb = lc.precioBase;
                        int tamano = lc.tamano;
                        Boolean reformado = lc.reformado;
                        string rf = reformado == false ? "N" : "S";
                        Boolean alquilado = lc.alquilado;
                        string alq = alquilado == false ? "DISPONIBLE" : "ALQUILADO";
                        string precioTotal = lc.calcularPrecio().ToString();
                        string texto = "L " + referencia + " Poblacion: " + poblacion.ToString().ToUpper() + " PB: " + pb.ToString() + " Superficie: " + tamano + " " + rf + " " + alq + " " + precioTotal;
                        arrayTxt.Add(texto);
                    }
                    else if (dato is Vivienda)
                    {
                        Vivienda vi = new Vivienda();
                        vi = dato as Vivienda;
                        string referencia = vi.referencia;
                        Enums.Poblacion poblacion = vi.poblacion;
                        double pb = vi.precioBase;
                        int numHab = vi.numeroDeHabitaciones;
                        Boolean alquilado = vi.alquilado;
                        string alq = alquilado == false ? "DISPONIBLE" : "ALQUILADO";
                        string precioTotal = vi.calcularPrecio().ToString();
                        string texto = "V " + referencia + " Poblacion: " + poblacion.ToString().ToUpper() + " PB: " + pb.ToString() + " " + numHab + " " + alq + " " + precioTotal;
                        arrayTxt.Add(texto);
                    }
                }
            }

            return arrayTxt;
        }

        public static List<string> mostrarVehiculos()
        {
            arrayTxt.Clear();
            foreach(Object dato in datos)
            {
                if (dato is Vehiculo)
                {
                    if (dato is Coche)
                    {
                        Coche ch = new Coche();
                        ch = dato as Coche;
                        string matricula = ch.matricula;
                        Enums.Marca marca = ch.marca;
                        Enums.TipoVehiculo tipo = ch.tipo;
                        int numPlazas = ch.numeroDePlazas;
                        Boolean alquilado = ch.alquilado;
                        string alq = alquilado == false ? "DISPONIBLE" : "ALQUILADO";
                        string precioTotal = ch.calcularPrecio().ToString();
                        string texto = "C " + matricula + " Marca: " + marca.ToString().ToUpper() + " Tipo: " + tipo.ToString().ToUpper() + " Plazas: " + numPlazas + " " + alq + " " + precioTotal;
                        arrayTxt.Add(texto);
                    }
                    else if (dato is Vivienda)
                    {
                        Furgoneta fg = new Furgoneta();
                        fg = dato as Furgoneta;
                        string matricula = fg.matricula;
                        Enums.Marca marca = fg.marca;
                        Enums.TipoVehiculo tipo = fg.tipo;
                        int carga = fg.cargaMaxima;
                        Boolean alquilado = fg.alquilado;
                        string alq = alquilado == false ? "DISPONIBLE" : "ALQUILADO";
                        string precioTotal = fg.calcularPrecio().ToString();
                        string texto = "F " + matricula + " Marca: " + marca.ToString().ToUpper() + " Tipo: " + tipo.ToString().ToUpper() + " Carga max: " + carga + " " + alq + " " + precioTotal;
                        arrayTxt.Add(texto);
                    }
                }
            }
            return arrayTxt;
        }

    }
}
