using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Solicitar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            pegaNomeLoginUsuario.Text = User.Identity.Name.ToUpper();
            carregaDadosDoCoordenador();
            txtData.Text = DateTime.Now.ToShortDateString();
            txtEspecificarRedeCorporativa.Enabled = false;
            txtEspecificarRedeCorporativa.Visible = false;
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "onclick.click=", "mostraRedeCorporativa()", true);
        }
        verificaCBK();
    }

    private void verificaCBK()
    {
        if (CkbRedeCorporativa.Checked == true)
        {
            txtEspecificarRedeCorporativa.Enabled = true;
            txtEspecificarRedeCorporativa.Visible = true;
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "onclick",  "mostraRedeCorporativa()", true);

        }
        else if (CkbRedeCorporativa.Checked == false)
        {
            txtEspecificarRedeCorporativa.Enabled = false;
        }
    }

    private void carregaDadosDoCoordenador()
    {
        //carrega os campos textos (Feito pelo Henrique)
        DadosCoordenador lista = new DadosCoordenador();
        lista = SolicitaAcessoDAO.GetDadosDosCoordenadoresPaginaSolicita(pegaNomeLoginUsuario.Text);
        txtRamal.Text = lista.ramal1.ToString();
        txtLotacao.Text = lista.setorCoordenador;
        txtSolicitante.Text = lista.NomeCoordenador;
    }


    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        cadastrarDadosDoSolicitante();
    }

    private void cadastrarDadosDoSolicitante()
    {
        DadosSolicitacao d = new DadosSolicitacao();
        d.NomeFuncionario = txtNomeFuncionario.Text;
        d.RF_Funcionario = Convert.ToInt32(txtRF.Text);
        d.login = txtLogin.Text;
        d.cargoFuncionario = txtCargo.Text;
        d.ramal1 = Convert.ToInt32(txtRamal.Text);
        d.lotacao = txtLotacao.Text;
        d.dtSolicitacao = DateTime.Now;
        d.NomeSolicitante_Coordenador = txtSolicitante.Text;

        labelIdChamado.Text = Convert.ToString(SolicitaAcessoDAO.pegaID_BancoDeDados(d.dtSolicitacao, d.RF_Funcionario));
        bool Result = SolicitaAcessoDAO.GravaDadosSolicitacao(d);


        if (CkbRedeCorporativa.Checked == true && Result == false)
        {
            DadosRedeCoorporativa r = new DadosRedeCoorporativa();
            r.id_chamado_rede_corporativa = Convert.ToInt32(labelIdChamado.Text);
        }





        if (Result == false)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Solicitação Gravada com suecesso!');", true);
        }
        else if (Result == true)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Já existe Solicitação pedente para esse Funcionario, Espere a Informatica dar baixa em todos os Itens da Solicitação que está ativa ou Ligue 8123 ou 8124 e verifique a Situação!');", true);
        }
    }


}
