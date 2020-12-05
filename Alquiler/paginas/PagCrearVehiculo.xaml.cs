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
    /// Lógica de interacción para PagCrearVehiculo.xaml
    /// </summary>
    public partial class PagCrearVehiculo : Page
    {
        public PagCrearVehiculo()
        {
            InitializeComponent();
            obtenerItemsMarca();
            obtenerItemsTipo();
        }

        public void obtenerItemsMarca()
        {
            string[] valores = Enum.GetNames(typeof(Enums.Marca));
            int contador = 0;
            foreach (string marca in valores)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = marca;
                item.Tag = contador;
                cbMarca.Items.Add(item);
                contador++;

            }

        }

        public void obtenerItemsTipo()
        {
            string[] valores = Enum.GetNames(typeof(Enums.TipoVehiculo));
            int contador = 0;
            foreach (string tipo in valores)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = tipo;
                item.Tag = contador;
                cbTipoCombustible.Items.Add(item);
                contador++;

            }

        }

        private void cbTipoVehiculo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedIndex != -1)
            {
                ComboBoxItem item = cb.SelectedItem as ComboBoxItem;

                string valor = item.Content.ToString();

                if (valor == "Coche")
                {
                    optCoche.Visibility = Visibility.Visible;
                    optFurgoneta.Visibility = Visibility.Collapsed;
                }
                else
                {
                    optCoche.Visibility = Visibility.Collapsed;
                    optFurgoneta.Visibility = Visibility.Visible;
                }
            }
        }

        private void Click_nuevo_vehiculo(object sender, RoutedEventArgs e)
        {
            Vehiculo nuevoVehiculo;

            if(cbTipoVehiculo.SelectedIndex == 0)
            {
                nuevoVehiculo = new Coche();
            }
            else
            {
                nuevoVehiculo = new Furgoneta();
            }

            ComboBoxItem marcaItem = (ComboBoxItem)cbMarca.SelectedItem;
            ComboBoxItem combustibleItem = (ComboBoxItem)cbTipoCombustible.SelectedItem;
            Boolean existe = false;
            Boolean valida = false;
            if (cbTipoVehiculo.SelectedIndex == 0)
            {
                if (txtMatricula.Text.Length > 0  && marcaItem != null && combustibleItem != null && txtNumPlazas.Text.Length > 0)
                {
                    string matricula = txtMatricula.Text;
                    Enums.Marca marca = (Enums.Marca)marcaItem.Tag;
                    Enums.TipoVehiculo tipo = (Enums.TipoVehiculo)combustibleItem.Tag;
                    
                    int numPlazas = Int32.Parse(txtNumPlazas.Text);
                   
                    nuevoVehiculo = new Coche(matricula, marca, tipo, numPlazas);
                }
                else
                {
                    lblError.Content = "Datos no validos";
                }
            }
            else
            {

                if (txtMatricula.Text.Length > 0 && marcaItem != null && combustibleItem != null && txtCarga.Text.Length > 0)
                {
                    string matricula = txtMatricula.Text;
                    Enums.Marca marca = (Enums.Marca)marcaItem.Tag;
                    Enums.TipoVehiculo tipo = (Enums.TipoVehiculo)combustibleItem.Tag;

                    int carga = Int32.Parse(txtCarga.Text);

                    nuevoVehiculo = new Furgoneta(matricula, marca, tipo, carga);
                }
                else
                {
                    lblError.Content = "Datos no validos";
                }
            }


            //compruebo si solo hay letras y numeros en la referencia
            if (!nuevoVehiculo.comprobarMat())
            {
                lblError.Content = "Matricula, caracteres no validos";
                valida = true;
            }
            else
            {
                //compruebo si ya existe la referencia
                foreach (Object dato in Principal.datos)
                {
                    if(dato is Vehiculo)
                    {
                        if (nuevoVehiculo.esIgual(dato as Vehiculo))
                        {
                            existe = true;

                        }
                    }
                    
                }
            }
            //error si existe la referencia
            if (existe)
            {
                lblError.Content = "Ya existe en la bbdd!";

            }
            //si todo va bien inserto
            if (!existe && !valida)
            {
                if (Principal.NuevoVehiculo(nuevoVehiculo))
                {
                    txtMatricula.Clear();
                    txtNumPlazas.Clear();
                    txtCarga.Clear();
                    cbMarca.SelectedIndex = -1;
                    cbTipoCombustible.SelectedIndex = -1;
                    
                    lblError.Content = "";
                }
            }
        }
    }
}
