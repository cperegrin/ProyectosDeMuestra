using System;
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
using CP04052015b.BLL;

namespace CP04052015b
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Carrito Digital";
            VentaBLL vbll = new VentaBLL();
            itemBLL ibll = new itemBLL();

            DgVentas.ItemsSource = vbll.GetVentas();
            LboxItem.ItemsSource = ibll.GetItems();
        }

        private void BtnVentas_Click(object sender, RoutedEventArgs e)
        {
            DateTime fecha = DateTime.Now;
            int pago = Convert.ToInt32(TxtCantidadPago.Text.Trim());
            //int vuelto = 0;
        }

        // boton agregar items
        private void BtnAgregarItem_Click(object sender, RoutedEventArgs e)
        {
            itemBLL ibll = new itemBLL();
            string newnombreitem = TxtNombreItem.Text.Trim();
            string precioitem = TxtPrecioItem.Text.Trim();

            if (!String.IsNullOrEmpty(newnombreitem) && !String.IsNullOrEmpty(precioitem))
            {
                int newprecioitem = Convert.ToInt32(precioitem);
                ibll.Agregar(newnombreitem, newprecioitem);
                LboxItem.ItemsSource = ibll.GetItems();
            }

            TxtNombreItem.Clear();
            TxtPrecioItem.Clear();

        }

    }
}
