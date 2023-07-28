using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adm_CadastrarCoordenador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            carregaListaCoordenadoresCadastrados();
        }
    }

    private void carregaListaCoordenadoresCadastrados()
    {
       gdvCadastroCoordenadores.DataSource=SolicitaAcessoDAO.GetListaCoordenadoresCadastrados();
        gdvCadastroCoordenadores.DataBind();
    }

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        DadosCoordenador D = new DadosCoordenador();
        try
        {
            D.NomeCoordenador = txtNomeCoordenador.Text;
            D.RF_Coordenador = Convert.ToInt32(txtRF.Text);
            D.eMail = txtEmail.Text + "@hspm.sp.gov.br";
            D.ramal1 = Convert.ToInt32(txtRamal1.Text);
            if (txtRamal2.Text=="" || txtRamal2.Text.Length<4)
            {
                D.ramal2 = 0;
            }
            D.ramal2 = Convert.ToInt32(txtRamal2.Text);
            D.setorCoordenador = txtSetor.Text;
            D.loginCoordenador = ddlLogin.Text;
            SolicitaAcessoDAO.GravaDadosCoordenador(D);
            carregaListaCoordenadoresCadastrados();
        }
        catch (Exception ex)
        {
            string erro = ex.Message;
        }
    }

    protected void gdvCadastroCoordenadoresHSPM_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Excluir")
        {
            int id = Convert.ToInt32(gdvCadastroCoordenadores.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
            SolicitaAcessoDAO.ExcluiCadastroCoordenador(id);
            carregaListaCoordenadoresCadastrados();
        }

    }
}