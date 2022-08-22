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
using EV4CristopherPeregrin.BLL;

namespace EV4CristopherPeregrin
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // todo lo relacionado a libros

            LibroBLL lbll = new LibroBLL();
            dgLibros.ItemsSource = lbll.ObtenerLibros();

            // todo lo relacionado a clientes
            ClienteBLL cbll = new ClienteBLL();
            dgClientes.ItemsSource = cbll.ObtenerClientes();

            // todo lo relacionado a prestamos
            PrestamoBLL pbll = new PrestamoBLL();

            cboLibros.ItemsSource = lbll.ObtenerLibros();
            cboClientes.ItemsSource = cbll.ObtenerClientes();

            dgPrestamo.ItemsSource = pbll.ObtenerPrestamos();

            // todo lo relacionado a estadisticas
            dgLibrosPrestados.ItemsSource = lbll.ObtenerLibros();

        }

        //
        // acciones con libros
        //

        private void btnAgregarLibro_Click(object sender, RoutedEventArgs e)
        {
            LibroBLL lbll = new LibroBLL();

            string numSerie = txtNumSerie.Text.Trim().ToUpper();
            string titulo = txtTitulo.Text.Trim();
            string autor = txtAutor.Text.Trim();
            string year = txtAñoEdicion.Text.Trim();

            if (!string.IsNullOrEmpty(numSerie) && !string.IsNullOrEmpty(titulo) && !string.IsNullOrEmpty(autor) && !string.IsNullOrEmpty(year))
            {
                int año = Convert.ToInt32(txtAñoEdicion.Text);
                lbll.AgregarLibro(numSerie, titulo, autor, año);

                dgLibros.ItemsSource = null;
                dgLibros.ItemsSource = lbll.ObtenerLibros();
                cboLibros.ItemsSource = lbll.ObtenerLibros();
                cboLibros.SelectedIndex = 0;
            }

        }

        private void btnBorrarLibrodg_Click(object sender, RoutedEventArgs e)
        {
            LibroBLL lbll = new LibroBLL();
            PrestamoBLL pbll = new PrestamoBLL();

             Libro obj = ((FrameworkElement)sender).DataContext as Libro;

             int libroID = obj.LibroID;

             MessageBoxResult result = MessageBox.Show("¿Seguro que quiere borrar el libro: "+obj.Titulo+"?", "Borrar", MessageBoxButton.YesNo, MessageBoxImage.Question);

             if (result == MessageBoxResult.Yes)
             {
                 //lbll.BorrarLibro(libroID);
                 MessageBox.Show(lbll.VerificarPrestamoLibro(libroID),"Info",MessageBoxButton.OK,MessageBoxImage.Information);
                 dgLibros.ItemsSource = null;
                 dgLibros.ItemsSource = lbll.ObtenerLibros();

                 cboLibros.ItemsSource = lbll.ObtenerLibros();
                 dgPrestamo.ItemsSource = pbll.ObtenerPrestamos();
                 dgLibrosPrestados.ItemsSource = lbll.ObtenerLibros();
             }
        }

        //
        // acciones con clientes
        //

        private void btnAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
            string nombres = txtNombres.Text;
            string apellidos = txtApellidos.Text;
            string rut = txtRut.Text;

            if (!string.IsNullOrEmpty(nombres) && !string.IsNullOrEmpty(apellidos) && !string.IsNullOrEmpty(rut))
            {
                ClienteBLL cbll = new ClienteBLL();

                cbll.AgregarCliente(rut, nombres, apellidos);
                dgClientes.ItemsSource = null;
                dgClientes.ItemsSource = cbll.ObtenerClientes();
                cboClientes.ItemsSource = cbll.ObtenerClientes();
                cboClientes.SelectedIndex = 0;
            }
        }

        private void btnBorrarClientedg_Click(object sender, RoutedEventArgs e)
        {
            ClienteBLL cbll = new ClienteBLL();
            PrestamoBLL pbll = new PrestamoBLL();

            Cliente obj = ((FrameworkElement)sender).DataContext as Cliente;

            int clienteID = obj.ClienteID;

            MessageBoxResult result = MessageBox.Show("¿Seguro que quiere borrar al Cliente: " + obj.Nombres+" "+ obj.Apellidos + "?", "Borrar", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                //cbll.BorrarCliente(clienteID);
                MessageBox.Show(cbll.VerificarPrestamoLibro(clienteID), "Info", MessageBoxButton.OK, MessageBoxImage.Information);

                dgClientes.ItemsSource = null;
                dgClientes.ItemsSource = cbll.ObtenerClientes();

                dgPrestamo.ItemsSource = null;
                dgPrestamo.ItemsSource = pbll.ObtenerPrestamos();

                cboClientes.ItemsSource = cbll.ObtenerClientes();
                cboClientes.SelectedIndex = 0;
            }
        }

        //
        // acciones de prestamos
        //

        private void btnAgregarPrestamo_Click(object sender, RoutedEventArgs e)
        {
            PrestamoBLL pbll = new PrestamoBLL();

            DateTime fPrestamo = DateTime.Now;
            DateTime fLimite = (DateTime)dtpFechaLimite.SelectedDate;

            Libro objLibro = cboLibros.SelectedItem as Libro;
            Cliente objCliente = cboClientes.SelectedItem as Cliente;

            int libroID = objLibro.LibroID;
            int clienteID = objCliente.ClienteID;

            MessageBox.Show(pbll.VerificarPrestamo(fPrestamo, fLimite, libroID, clienteID), "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            dgPrestamo.ItemsSource = null;
            dgPrestamo.ItemsSource = pbll.ObtenerPrestamos();

            LibroBLL lbll = new LibroBLL();
            dgLibrosPrestados.ItemsSource = lbll.ObtenerLibros();

        }

        private void btnDevolucion_Click(object sender, RoutedEventArgs e)
        {
            PrestamoBLL pbll = new PrestamoBLL();

            string numSerie = txtNumSerieDevolucion.Text.Trim().ToUpper();
            DateTime fechaDevolucion = DateTime.Now;

            MessageBox.Show(pbll.AgregarDevolucion(numSerie, fechaDevolucion), "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            
            dgPrestamo.ItemsSource = null;
            dgPrestamo.ItemsSource = pbll.ObtenerPrestamos();

            LibroBLL lbll = new LibroBLL();
            dgLibrosPrestados.ItemsSource = lbll.ObtenerLibros();
        }

        //
        // Filtrado de radio buttons
        //

        private void rdoVigentes_Checked(object sender, RoutedEventArgs e)
        {
            PrestamoBLL pbll = new PrestamoBLL();
            List<Prestamo> listaPrestamos = pbll.ObtenerPrestamos();
            List<Prestamo> listaPrestamosFiltrada = new List<Prestamo>();
            foreach (Prestamo prestamo in listaPrestamos)
            {
                if (prestamo.FechaDevolucion == null)
                {
                    listaPrestamosFiltrada.Add(prestamo);
                }
            }
            dgPrestamo.ItemsSource = null;
            dgPrestamo.ItemsSource = listaPrestamosFiltrada;
        }

        private void rdoFinalizados_Checked(object sender, RoutedEventArgs e)
        {
            PrestamoBLL pbll = new PrestamoBLL();
            List<Prestamo> listaPrestamos = pbll.ObtenerPrestamos();
            List<Prestamo> listaPrestamosFiltrada = new List<Prestamo>();
            foreach (Prestamo prestamo in listaPrestamos)
            {
                if (prestamo.FechaDevolucion != null)
                {
                    listaPrestamosFiltrada.Add(prestamo);
                }
            }
            dgPrestamo.ItemsSource = null;
            dgPrestamo.ItemsSource = listaPrestamosFiltrada;
        }

    }
}
