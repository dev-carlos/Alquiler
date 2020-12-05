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
    /// Lógica de interacción para PagOferta.xaml
    /// </summary>
    public partial class PagOferta : Page
    {
        public PagOferta()
        {
            InitializeComponent();
        }

        private void Click_azar_Inm_Veh(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            int num = rnd.Next(0, 2);

            if(num == 0)
            {
                txtAzarInm_Veh.Text = "Inmueble";
                sp_azar_poblacion.Visibility = Visibility.Visible;
                sp_azar_marca.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtAzarInm_Veh.Text = "Vehiculo";
                sp_azar_marca.Visibility = Visibility.Visible;
                sp_azar_poblacion.Visibility = Visibility.Collapsed;
            }
        }

        private void Click_azar_marca(object sender, RoutedEventArgs e)
        {
            string[] marcas = Enum.GetNames(typeof(Enums.Marca));

            int numMarcas = marcas.Length;

            Random rnd = new Random();
            int selecMarca = rnd.Next(0, numMarcas);

            if (!Principal.nuevaOferta(marcas[selecMarca]))
            {
                lblMarcaOferta.Content = "Marca en oferta: " + marcas[selecMarca];
            }

            txtAzarMarca.Text = marcas[selecMarca];

        }

        private void Click_azar_poblacion(object sender, RoutedEventArgs e)
        {
            string[] poblaciones = Enum.GetNames(typeof(Enums.Poblacion));

            int numPoblaciones = poblaciones.Length;

            Random rnd = new Random();
            int selecPoblacion = rnd.Next(0, numPoblaciones);

            if (!Principal.nuevaOferta(poblaciones[selecPoblacion]))
            {
                lblPoblacionOferta.Content = "Poblacion en oferta: " + poblaciones[selecPoblacion];
            }

            txtAzarPoblacion.Text = poblaciones[selecPoblacion];
        }
    }
}
