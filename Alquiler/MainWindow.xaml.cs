using Alquiler.paginas;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Alquiler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        
        public MainWindow()
        {
            
            InitializeComponent();
            inicio();
        }

        private void inicio()
        {
            PagMostrar p = new PagMostrar();
            frame_principal.Content = p as Page;
        }

        private void click_crearInmueble(object sender, RoutedEventArgs e)
        {
            PagCrearInmueble p = new PagCrearInmueble();
            frame_principal.Content = p as Page;
        }

        private void click_oferta(object sender, RoutedEventArgs e)
        {
            PagOferta p = new PagOferta();
            frame_principal.Content = p as Page;
        }

        private void click_alquiler(object sender, RoutedEventArgs e)
        {
            PagAlquiler p = new PagAlquiler();
            frame_principal.Content = p as Page;
        }

        private void click_mostrar(object sender, RoutedEventArgs e)
        {
            PagMostrar p = new PagMostrar();
            frame_principal.Content = p as Page;
        }

        private void click_salir(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void click_crearVehiculo(object sender, RoutedEventArgs e)
        {
            PagCrearVehiculo p = new PagCrearVehiculo();
            frame_principal.Content = p as Page;
        }

        
    }
}
