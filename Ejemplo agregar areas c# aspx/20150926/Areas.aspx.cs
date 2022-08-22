using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _20150926.BLL;

namespace _20150926
{
    public partial class Areas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAgregarArea_Click(object sender, EventArgs e)
        {
            AreaBLL abll = new AreaBLL();
            abll.Agregar(TxtNombre.Text.Trim(), TxtEncargado.Text.Trim());
            TxtNombre.Text = "";
            TxtEncargado.Text = "";
            GvAreas.DataBind();
        }
    }
}