using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<int> perfis = Session["perfis"] as List<int>;
        if (perfis == null || (!perfis.Contains(1)))
        {
            BtnAdm.Visible = false;
        }
        string nome = Session["nomeUsuario"] as string;
        LabelNomeCompleto.Text = nome.ToUpper();
    }
   
}
