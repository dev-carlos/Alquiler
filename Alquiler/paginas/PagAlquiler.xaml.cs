using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Alquiler.paginas
{
    /// <summary>
    /// Lógica de interacción para PagAlquiler.xaml
    /// </summary>
    public partial class PagAlquiler : Page
    {
        public PagAlquiler()
        {
            InitializeComponent();
        }

        private void Click_seleccinar_alquiler(object sender, RoutedEventArgs e)
        {
            Boolean encontrado = false;
            Vehiculo svehiculo;
            Inmueble sinmueble;

            foreach(Object dato in Principal.datos)
            {
                if(dato is Inmueble && !encontrado)
                {
                    sinmueble = dato as Inmueble;
                    if(sinmueble.alquilado == false)
                    {
                        txtSelectAlquiler.Text = sinmueble.referencia;
                        
                        
                            
                                if (sinmueble.alquilar())
                                {
                                    txtResultalquiler.Content = "alquilado inmueble ok!";
                                }
                                else
                                {
                                    txtResultalquiler.Content = "error al alquilar inmueble !";
                                }
                                
                            
                        
                        encontrado = true;
                    }
                }
                if (dato is Vehiculo && !encontrado)
                {
                    svehiculo = dato as Vehiculo;
                    if (svehiculo.alquilado == false)
                    {
                        txtSelectAlquiler.Text = svehiculo.matricula;

                       
                                    if (svehiculo.alquilar())
                                    {
                                        txtResultalquiler.Content = "alquilado vehiculo ok!";
                                    }
                                    else
                                    {
                                        txtResultalquiler.Content = "error al alquilar vehiculo !";
                                    }
                                
                            
                            
                        

                        encontrado = true;
                    }
                }
                
            }
            if (!encontrado)
            {
                txtResultalquiler.Content = "Error al seleccionar alquiler";
            }
        }

        private void Click_seleccinar_devolver(object sender, RoutedEventArgs e)
        {
            Boolean encontrado = false;
            Vehiculo svehiculo;
            Inmueble sinmueble;

            foreach (Object dato in Principal.datos)
            {
                if (dato is Inmueble && !encontrado)
                {
                    sinmueble = dato as Inmueble;
                    if (sinmueble.alquilado == true)
                    {
                        txtSelectDevolver.Text = sinmueble.referencia;

                        foreach (Inmueble I in Principal.datos)
                        {
                            if (I.esIgual(sinmueble))
                            {
                                if (I.devolver())
                                {
                                    txtResultdevolver.Content = "devuelto inmueble ok!";
                                }
                                else
                                {
                                    txtResultdevolver.Content = "error al devolver inmueble !";
                                }

                            }
                        }
                        encontrado = true;
                    }
                }
                if (dato is Vehiculo && !encontrado)
                {
                    svehiculo = dato as Vehiculo;
                    if (svehiculo.alquilado == true)
                    {
                        txtSelectDevolver.Text = svehiculo.matricula;

                        foreach (Vehiculo V in Principal.datos)
                        {
                            if (V.esIgual(svehiculo))
                            {
                                if (V.devolver())
                                {
                                    txtResultdevolver.Content = "devuelto vehiculo ok!";
                                }
                                else
                                {
                                    txtResultdevolver.Content = "error al devolver vehiculo !";
                                }
                            }
                        }

                        encontrado = true;
                    }
                }

            }
            if (!encontrado)
            {
                txtResultdevolver.Content = "Error al seleccionar para devolver";
            }
        }
    }
}
