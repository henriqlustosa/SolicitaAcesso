using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adm_SolicitacoesAbertas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            LabelExtratoChamado.Text = "";
            pegaNomeLoginUsuario.Text = User.Identity.Name.ToUpper();         
            carregaGrid();
        }     

    }

    private void carregaGrid()
    {
        GridViewSolicitacoes.DataSource = SolicitaAcessoDAO.MostraSolicitacoesNaTelaStatus();
        GridViewSolicitacoes.DataBind();
    }



    protected void grdSolicitacoesExibe_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int id = Convert.ToInt32(GridViewSolicitacoes.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());        
        Response.Redirect("~/adm/AtenderSolicitacao.aspx?IdChamado=" + id);
    }
}