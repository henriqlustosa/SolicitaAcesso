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
        }
        verificaCBK();
    }

    private void verificaCBK()
    {
        if (CkbRedeCorporativa.Checked == true)
        {
            PanelRedeCorporativa.Visible = true;          
        }
        if (CkbRedeCorporativa.Checked == false)
        {
            PanelRedeCorporativa.Visible = false;           
        }
        if (ckbSGHexibe.Checked == true)
        {
            PanelSGH.Visible = true;           
        }
        if (ckbSGHexibe.Checked == false)
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
        if (ckbOSmanutencao.Checked == true)
        {
            PanelOsManutencao.Visible = true;
        }
        if (ckbOSmanutencao.Checked == false)
        {
            PanelOsManutencao.Visible = false;
        }
        if (ckbSEI.Checked == true)
        {
            PanelSEI.Visible = true;
        }
        if (ckbSEI.Checked == false)
        {
            PanelSEI.Visible = false;
        }
    }

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        cadastrarDadosDoSolicitante();
       

        if (LabelJaExiste.Text == "NAO")
        {
            if (CkbRedeCorporativa.Checked == true)
            {
                cadastrarRedeCorporativa();
            }
            if (ckbSGHexibe.Checked == true)
            {
                cadastrarSGH();
            }
            if (ckbExibeSimproc.Checked == true)
            {
                cadastrarSimproc();
            }
        }
        else if (LabelJaExiste.Text == "SIM")
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Já existe Solicitação pedente para esse Funcionario, Espere a Informatica dar baixa em todos os Itens da Solicitação que está ativa ou Ligue 8123 ou 8124 e verifique a Situação!');", true);

        }



    }

    private void cadastrarSimproc()
    {
        DadosSimproc d = new DadosSimproc();
        d.id_chamado_Simproc = Convert.ToInt32(labelIdChamado.Text);
        d.CodigoUnidade_Simproc = txtSimprocCodigoUnidade.Text;
        d.cpf_simproc = txtSimprocCPF.Text;
        d.rg_simproc = txtSimprocRG.Text;
        d.dataAdmissao = txtDtAdmissao.Text;    
        d.status_Simproc = "S";
        SolicitaAcessoDAO.GravaDadosSImproc(d);
    }

    private void cadastrarSGH()
    {
        DadosSGH d = new DadosSGH();
        d.id_chamado_SGH= Convert.ToInt32(labelIdChamado.Text);
        d.Amb = CkbSGHamb.Checked.ToString();
        d.Amb_Desc = txtSGHAmb.Text;
        d.CenCir = CkbCenCir.Checked.ToString();
        d.CenCir_Desc = txtSGHcentroCirurgico.Text;
        d.Internacao = CkbSGHInternacao.Checked.ToString();
        d.Internacao_Desc = txtSGHInternacao.Text;
        d.PS = CkbSGHprontoSocorro.Checked.ToString();
        d.PS_Desc = txtSGHProntoSocorro.Text;
        d.status_SGH = "S";
        SolicitaAcessoDAO.GravaDadosSGH(d);
    }

    private void cadastrarRedeCorporativa()
    {
        DadosRedeCoorporativa d = new DadosRedeCoorporativa();
        d.id_chamado_rede_corporativa = Convert.ToInt32(labelIdChamado.Text);
        if (rdAcesso.Checked == true)
        {
            d.redeCorporativa = rdAcesso.Text;
        }
        if (rdBloqueio.Checked == true)
        {
            d.redeCorporativa = rdBloqueio.Text;
        }
        if (rdAtualizar.Checked == true)
        {
            d.redeCorporativa = rdAtualizar.Text;
        }
        d.emailCorporativo = CkbEmail.Checked.ToString();
        d.caixaDepartamental = CkbCaixaDepartamental.Checked.ToString();
        d.pastaDeRede = CkbPastaRede.Checked.ToString();
        d.PastaEspecifica = txtEspecificarRedeCorporativa.Text;
        d.status_redeCoorporativa = "S";
        SolicitaAcessoDAO.GravaDadosRedeCorporativa(d);

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


        bool Result = SolicitaAcessoDAO.GravaDadosSolicitacao(d);
        labelIdChamado.Text = Convert.ToString(SolicitaAcessoDAO.pegaID_BancoDeDados(d.dtSolicitacao, d.RF_Funcionario));

        if (CkbRedeCorporativa.Checked == true && Result == false)
        {
            DadosRedeCoorporativa r = new DadosRedeCoorporativa();
            r.id_chamado_rede_corporativa = Convert.ToInt32(labelIdChamado.Text);
        }

        if (Result == false)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Solicitação Gravada com suecesso!');", true);
            LabelJaExiste.Text = "NAO";
        }
        else if (Result == true)
        {
            LabelJaExiste.Text = "SIM";   
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
  
}
