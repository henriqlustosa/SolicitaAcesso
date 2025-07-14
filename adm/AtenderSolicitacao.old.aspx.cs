using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class adm_AtenderSolicitacao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string id1 = Request.QueryString["IdChamado"];
        int id = Convert.ToInt32(id1);
        carregarDadosSolicitante(id);
        id_Chamado.Text = id1;
        pegaNomeLoginUsuario.Text = User.Identity.Name.ToUpper();
        verificaCBK_SituacaoNobanco(Convert.ToInt32(id_Chamado.Text));
        verificaCBK();
    }


    private void carregarDadosSolicitante(int id)
    {
        //carrega os campos textos (Feito pelo Henrique)
        DadosSolicitacao lista = new DadosSolicitacao();
        lista = SolicitaAcessoDAO.GetDadosDaSolitacaoParaAtender(id);

        txtNomeFuncionario.Text = lista.NomeFuncionario;
        txtRF.Text = lista.RF_Funcionario.ToString();
        txtLogin.Text = lista.login;
        txtCargo.Text = lista.cargoFuncionario;
        txtEmail.Text = lista.eMail;
        txtRamal.Text = lista.ramal1;
        txtLotacao.Text = lista.lotacao;
        txtData.Text = lista.dtSolicitacao.ToShortDateString();
        txtSolicitante.Text = lista.NomeSolicitante_Coordenador;

    }



    private void verificaCBK_SituacaoNobanco(int id)
    {
        CkbExibeRedeCorporativa.Checked = false;
        ckbExibeSGH.Checked = false;
        ckbExibeSimproc.Checked = false;
        ckbExibeGrafica.Checked = false;
        ckbExibeOSmanutencao.Checked = false;
        ckbExibeSEI.Checked = false;
        DadosSetoresSolicitados_S lista = new DadosSetoresSolicitados_S();
        lista = SolicitaAcessoDAO.GetSetoresCom_S(id);
        if (lista.RedeCorporativa == "S")
        {
            CkbExibeRedeCorporativa.Checked = true;
        }
        if (lista.SGH == "S")
        {
            ckbExibeSGH.Checked = true;
        }
        if (lista.Simproc == "S")
        {
            ckbExibeSimproc.Checked = true;
        }
        if (lista.Grafica == "S")
        {
            ckbExibeGrafica.Checked = true;
        }
        if (lista.OS_manutencao == "S")
        {
            ckbExibeOSmanutencao.Checked = true;
        }
        if (lista.Sei == "S")
        {
            ckbExibeSEI.Checked = true;
        }
    }

    private void verificaCBK()
    {
        if (CkbExibeRedeCorporativa.Checked == true)
        {
            PanelRedeCorporativa.Visible = true;
        }
        if (CkbExibeRedeCorporativa.Checked == false)
        {
            PanelRedeCorporativa.Visible = false;
        }
        if (ckbExibeSGH.Checked == true)
        {
            PanelSGH.Visible = true;
        }
        if (ckbExibeSGH.Checked == false)
        {
            PanelSGH.Visible = false;
        }
        if (ckbExibeSimproc.Checked == true)
        {
            PanelSimproc.Visible = true;
        }
        if (ckbExibeSimproc.Checked == false)
        {
            PanelSimproc.Visible = false;
        }
        if (ckbExibeGrafica.Checked == true)
        {
            PanelGrafica.Visible = true;
        }
        if (ckbExibeGrafica.Checked == false)
        {
            PanelGrafica.Visible = false;
        }
        if (ckbExibeOSmanutencao.Checked == true)
        {
            PanelOsManutencao.Visible = true;
        }
        if (ckbExibeOSmanutencao.Checked == false)
        {
            PanelOsManutencao.Visible = false;
        }
        if (ckbExibeSEI.Checked == true)
        {
            PanelSEI.Visible = true;
        }
        if (ckbExibeSEI.Checked == false)
        {
            PanelSEI.Visible = false;
        }
    }

    protected void btnRedeCorporativa_Click(object sender, EventArgs e)
    {
        int idChamado = Convert.ToInt32(id_Chamado.Text);
        SolicitaAcessoDAO.Atualiza_Solicitacoes_setores_Update(idChamado, "RedeCorporativa", "C");
        SolicitaAcessoDAO.Atualiza_Solicitante_dados_status(idChamado);
        Response.Redirect("~/adm/AtenderSolicitacao.aspx?IdChamado=" + idChamado);
    }

    protected void bntSGH_Click(object sender, EventArgs e)
    {
        int idChamado = Convert.ToInt32(id_Chamado.Text);
        SolicitaAcessoDAO.Atualiza_Solicitacoes_setores_Update(idChamado, "SGH", "C");
        SolicitaAcessoDAO.Atualiza_Solicitante_dados_status(idChamado);
        Response.Redirect("~/adm/AtenderSolicitacao.aspx?IdChamado=" + idChamado);
    }

    protected void btnSimproc_Click(object sender, EventArgs e)
    {
        int idChamado = Convert.ToInt32(id_Chamado.Text);
        SolicitaAcessoDAO.Atualiza_Solicitacoes_setores_Update(idChamado, "Simproc", "C");
        SolicitaAcessoDAO.Atualiza_Solicitante_dados_status(idChamado);
        Response.Redirect("~/adm/AtenderSolicitacao.aspx?IdChamado=" + idChamado);
    }

    protected void btnGrafica_Click(object sender, EventArgs e)
    {
        int idChamado = Convert.ToInt32(id_Chamado.Text);
        SolicitaAcessoDAO.Atualiza_Solicitacoes_setores_Update(idChamado, "Grafica", "C");
        SolicitaAcessoDAO.Atualiza_Solicitante_dados_status(idChamado);
        Response.Redirect("~/adm/AtenderSolicitacao.aspx?IdChamado=" + idChamado);
    }

    protected void btnOSmanutencao_Click(object sender, EventArgs e)
    {
        int idChamado = Convert.ToInt32(id_Chamado.Text);
        SolicitaAcessoDAO.Atualiza_Solicitacoes_setores_Update(idChamado, "OS_manutencao", "C");
        SolicitaAcessoDAO.Atualiza_Solicitante_dados_status(idChamado);
        Response.Redirect("~/adm/AtenderSolicitacao.aspx?IdChamado=" + idChamado);
    }

    protected void btnSei_Click(object sender, EventArgs e)
    {
        int idChamado = Convert.ToInt32(id_Chamado.Text);
        SolicitaAcessoDAO.Atualiza_Solicitacoes_setores_Update(idChamado, "Sei", "C");
        SolicitaAcessoDAO.Atualiza_Solicitante_dados_status(idChamado);
        Response.Redirect("~/adm/AtenderSolicitacao.aspx?IdChamado=" + idChamado);
    }
}