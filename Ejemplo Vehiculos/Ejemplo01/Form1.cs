using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ejemplo01.BLL;

namespace Ejemplo01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            AutoBLL ab = new AutoBLL();

            dgAutos.AutoGenerateColumns = false;        
            dgAutos.DataSource = ab.GetAutos();
        }

        private void btnAgregarAuto_Click(object sender, EventArgs e)
        {
            AutoBLL ab = new AutoBLL();

            ab.Agregar(txtMarca.Text.Trim(), txtModelo.Text.Trim(), txtPatente.Text.Trim());

            dgAutos.DataSource = null;
            dgAutos.DataSource = ab.GetAutos();

            txtMarca.Clear();
            txtModelo.Clear();
            txtPatente.Clear();

            txtMarca.Focus();
        }

        private void dgAutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Auto auto = (Auto)senderGrid.Rows[e.RowIndex].DataBoundItem;
                DialogResult result = MessageBox.Show(string.Format("Desea borrar el auto Placa Patente {0}",auto.Patente),"Confirmación Borrado",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //MessageBox.Show(string.Format("Id: {0}, Patente: {1}", auto.AutoID, auto.Patente));
                    AutoBLL ab = new AutoBLL();
                    ab.Borrar(auto.AutoID);
                    dgAutos.DataSource = null;
                    dgAutos.DataSource = ab.GetAutos();
                }
            }
        }
    }
}
