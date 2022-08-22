using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _20150926.BLL;

namespace _20150926
{
    public partial class Carreras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            CarreraBLL cbll = new CarreraBLL();
            cbll.Agregar(TxtNombre.Text.Trim(), Convert.ToInt32(TxtDuracion.Text.Trim()), Convert.ToInt32(DlArea.SelectedValue));
            TxtNombre.Text = "";
            TxtDuracion.Text = "";
            DlArea.SelectedIndex = 0;
            GvCarreras.DataBind();
        }
    }
}