using System;
using System.Collections;
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
    /// Lógica de interacción para PagMostrar.xaml
    /// </summary>
    public partial class PagMostrar : Page
    {

        List<string> datos;
        

        public PagMostrar()
        {
            InitializeComponent();
            this.datos = Principal.mostrarTodos();
            dt_datos.ItemsSource = datos;
            lbl_mostrar_ofertaInm.Content = "Poblacion en oferta: " + Principal.poblacionOferta;
            lbl_mostrar_ofertaVeh.Content = "Marca en oferta: " + Principal.marcaOferta;
            //dt_datos.Items.Refresh();
        }

        private void Click_mostrar_todo(object sender, RoutedEventArgs e)
        {
            
            
            if(datos != null)
            {
                datos = Principal.mostrarTodos();
                dt_datos.Items.Refresh();
            }
        }

        private void Click_mostrar_inmueble(object sender, RoutedEventArgs e)
        {
            if(datos != null)
            {
                datos = Principal.mostrarInmuebles();
                dt_datos.Items.Refresh();
            }
            
        }

        private void Click_mostrar_vehiculo(object sender, RoutedEventArgs e)
        {
            if (datos != null)
            {
                datos = Principal.mostrarVehiculos();
                dt_datos.Items.Refresh();
            }
        }
    }
}
