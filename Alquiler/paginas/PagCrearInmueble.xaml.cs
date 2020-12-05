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
    /// Lógica de interacción para PagCrearInmueble.xaml
    /// </summary>
    public partial class PagCrearInmueble : Page
    {
        public PagCrearInmueble()
        {
            
            InitializeComponent();
            obtenerItemsPoblacion();
        }

        public void obtenerItemsPoblacion()
        {
            string[] valores = Enum.GetNames(typeof(Enums.Poblacion));
            int contador = 0;
            foreach (string poblacion in valores)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = poblacion;
                item.Tag = contador;
                cbPoblacion.Items.Add(item);
                contador++;

            }
            
        }

        private void cbTipoinmueble_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if(cb.SelectedIndex != -1)
            {
                ComboBoxItem item = cb.SelectedItem as ComboBoxItem;

                string valor = item.Content.ToString();

                if (valor == "Local Comercial")
                {
                    spOptionsLocal.Visibility = Visibility.Visible;
                    spOptionsVivienda.Visibility = Visibility.Collapsed;
                }
                else
                {
                    spOptionsLocal.Visibility = Visibility.Collapsed;
                    spOptionsVivienda.Visibility = Visibility.Visible;
                }
            }
            
        }

        private void click_crearInmueble(object sender, RoutedEventArgs e)
        {
            Inmueble nuevoInmueble;
            if (cbTipoinmueble.SelectedIndex == 0)
            {
                nuevoInmueble = new LocalComercial();
            }
            else
            {
                nuevoInmueble = new Vivienda();
            }
            
            
           // LocalComercial lc = i as LocalComercial;
            //i is LocalComercial
            ComboBoxItem item = (ComboBoxItem)cbPoblacion.SelectedItem;
            Boolean existe = false;
            Boolean valida = false;
            if (cbTipoinmueble.SelectedIndex == 0)
            {
                if (txtReferencia.Text.Length > 0 && txtPrecioBase.Text.Length > 0 && item != null && txtTamano.Text.Length > 0 && cbReformado.Text != "")
                {
                    string referencia = txtReferencia.Text;
                    Enums.Poblacion poblacion = (Enums.Poblacion)item.Tag;
                    double precio = double.Parse(txtPrecioBase.Text);
                    int tamano = Int32.Parse(txtTamano.Text);
                    Boolean reformado = cbReformado.Text == "no" ? false : true;
                    nuevoInmueble = new LocalComercial(referencia, poblacion, precio ,reformado, tamano);
                }
                else
                {
                    lblError.Content = "Datos no validos";
                }
            }
            else
            {

                if (txtReferencia.Text.Length > 0 && txtPrecioBase.Text.Length > 0 && item != null && txtNumHab.Text.Length > 0)
                {
                    string referencia = txtReferencia.Text;
                    Enums.Poblacion poblacion = (Enums.Poblacion)item.Tag;
                    double precio = double.Parse(txtPrecioBase.Text);
                    int numHab = Int32.Parse(txtNumHab.Text);
                    nuevoInmueble = new Vivienda(referencia, poblacion, precio,numHab);
                }
                else
                {
                    lblError.Content = "Datos no validos";
                }
            }
          
               

                //compruebo si solo hay letras y numeros en la referencia
                if (!nuevoInmueble.comprobarRef())
                {
                    lblError.Content = "Referencia, caracteres no validos";
                    valida = true;
                }
                else
                {
                    //compruebo si ya existe la referencia
                    foreach (Object dato in Principal.datos)
                    {
                            if(dato is Inmueble)
                        
                                if (nuevoInmueble.esIgual(dato as Inmueble))
                                {
                                    existe = true;

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
                    if (Principal.NuevoInmueble(nuevoInmueble))
                    {
                        txtReferencia.Clear();
                        txtTamano.Clear();
                        txtPrecioBase.Clear();
                        cbPoblacion.SelectedIndex = -1;
                        cbTipoinmueble.SelectedIndex = -1;
                        txtNumHab.Clear();
                        lblError.Content = "";
                    }
                }

            
            
            

        }

        
    }
}
