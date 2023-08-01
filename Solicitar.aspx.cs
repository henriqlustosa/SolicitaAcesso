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
            // EscondeCampos();
        }
        verificaCBK();
    }

    private void verificaCBK()
    {
        if (CkbRedeCorporativa.Checked == true)
        {
            PanelRedeCorporativa.Visible = true;
            // mostraConteudoRedeCorporativa();
        }
        if (CkbRedeCorporativa.Checked == false)
        {
            PanelRedeCorporativa.Visible = false;
            // escondeConteudoRedeCorporativa();
        }
        if (ckbSGHexibe.Checked == true)
        {
            PanelSGH.Visible = true;
            //  mostraConteudoSGH();
        }
        if (ckbSGHexibe.Checked == false)
        {
            PanelSGH.Visible = false;
            //  escondeConteudoSGH();
        }
        if (ckbExibeSimproc.Checked == true)
        {
            PanelSimproc.Visible = true;
            //   mostraConteudoSimproc();
        }
        if (ckbExibeSimproc.Checked == false)
        {
            PanelSimproc.Visible = false;
            //   escondeConteudoSimproc();
        }
        if (ckbExibeGrafica.Checked == true)
        {
            PanelGrafica.Visible = true;
            //  mostraConteudoGrafica();
        }
        if (ckbExibeGrafica.Checked == false)
        {
            PanelGrafica.Visible = false;
            //  escondeConteudoGrafica();
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
        if (CkbRedeCorporativa.Checked == true)
        {
            cadastrarRedeCorporativa();
        }
        
        if (ckbSGHexibe.Checked == true)
        {
            cadastrarSGH();
        }
    }

    private void cadastrarSGH()
    {
        DadosSGH d = new DadosSGH();
        d.Amb = CkbSGHamb.Checked.ToString();
        d.Amb_Desc = txtSGHAmb.Text;
        d.CenCir = CkbCenCir.Checked.ToString();
        d.CenCir_Desc = txtSGHcentroCirurgico.Text;
        d.Amb = CkbSGHamb.Checked.ToString();
        d.Amb_Desc = txtSGHAmb.Text;
        d.Amb = CkbSGHamb.Checked.ToString();
        d.Amb_Desc = txtSGHAmb.Text;
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
        }
        else if (Result == true)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Já existe Solicitação pedente para esse Funcionario, Espere a Informatica dar baixa em todos os Itens da Solicitação que está ativa ou Ligue 8123 ou 8124 e verifique a Situação!');", true);
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
    //private void EscondeCampos()
    //{

    //    //rede corperativa        
    //    rdAcesso.Visible = false;
    //    rdBloqueio.Visible = false;
    //    rdAtualizar.Visible = false;
    //    CkbEmail.Visible = false;
    //    CkbCaixaDepartamental.Visible = false;
    //    CkbPastaRede.Visible = false;
    //    txtEspecificarRedeCorporativa.Visible = false;
    //    //SGH
    //    CkbSGHamb.Visible = false;
    //    CkbSGH.Visible = false;
    //    CkbSGHInternacao.Visible = false;
    //    CkbSGHprontoSocorro.Visible = false;
    //    txtSGHAmb.Visible = false;
    //    txtSGHcentroCirurgico.Visible = false;
    //    txtSGHInternacao.Visible = false;
    //    txtSGHProntoSocorro.Visible = false;
    //    //Simproc
    //    labelSimprocCodicoUnidade.Visible = false;
    //    labelSimprocCPF.Visible = false;
    //    labelSimprocRG.Visible = false;
    //    labelSimprocDataAdmissao.Visible = false;
    //    txtSimprocCodigoUnidade.Visible = false;
    //    txtSimprocCPF.Visible = false;
    //    txtSimprocRG.Visible = false;
    //    txtDtAdmissao.Visible = false;
    //    //Grafica
    //    ckbCentral.Visible = false;
    //    ckbGrafica.Visible = false;
    //    ckbfarmacia.Visible = false;
    //    ckbSND.Visible = false;
    //    ckbManutencao.Visible = false;
    //    ckbMecanica.Visible = false;
    //    ckbEstoqueLab.Visible = false;
    //    labelNcentroCusto.Visible = false;//Todo
    //    labelnovoGrafica.Visible = false;
    //    txtNcentroDeCustoGrafica.Visible = false;
    //    labelGraficaCpf.Visible = false;
    //    txtCPFgrafica.Visible = false;
    //    labelGraficaCota.Visible = false;
    //    rdbDiaria.Visible = false;
    //    rdbSemanal.Visible = false;
    //    rdbQuinzenal.Visible = false;
    //    rdbMensal.Visible = false;
    //   //OS-Manutencao
    //}

    //private void escondeConteudoRedeCorporativa()
    //{
    //    labelRedeCorporativa.Visible = false;
    //    rdAcesso.Visible = false;
    //    rdBloqueio.Visible = false;
    //    rdAtualizar.Visible = false;
    //    CkbEmail.Visible = false;
    //    CkbCaixaDepartamental.Visible = false;
    //    CkbPastaRede.Visible = false;
    //    txtEspecificarRedeCorporativa.Visible = false;
    //}

    //private void mostraConteudoRedeCorporativa()
    //{
    //    labelRedeCorporativa.Visible = true;
    //    rdAcesso.Visible = true;
    //    rdBloqueio.Visible = true;
    //    rdAtualizar.Visible = true;
    //    CkbEmail.Visible = true;
    //    CkbCaixaDepartamental.Visible = true;
    //    CkbPastaRede.Visible = true;
    //    txtEspecificarRedeCorporativa.Visible = true;
    //}

    //private void escondeConteudoSGH()
    //{
    //    labelSGH.Visible = false;
    //    CkbSGHamb.Visible = false;
    //    CkbSGH.Visible = false;
    //    CkbSGHInternacao.Visible = false;
    //    CkbSGHprontoSocorro.Visible = false;
    //    txtSGHAmb.Visible = false;
    //    txtSGHcentroCirurgico.Visible = false;
    //    txtSGHInternacao.Visible = false;
    //    txtSGHProntoSocorro.Visible = false;
    //}

    //private void mostraConteudoSGH()
    //{
    //    labelSGH.Visible = true;
    //    CkbSGHamb.Visible = true;
    //    CkbSGH.Visible = true;
    //    CkbSGHInternacao.Visible = true;
    //    CkbSGHprontoSocorro.Visible = true;
    //    txtSGHAmb.Visible = true;
    //    txtSGHcentroCirurgico.Visible = true;
    //    txtSGHInternacao.Visible = true;
    //    txtSGHProntoSocorro.Visible = true;
    //}
    //private void escondeConteudoSimproc()
    //{
    //    labelSimproc.Visible = false;
    //    labelSimprocCodicoUnidade.Visible = false;
    //    labelSimprocCPF.Visible = false;
    //    labelSimprocRG.Visible = false;
    //    labelSimprocDataAdmissao.Visible = false;
    //    txtSimprocCodigoUnidade.Visible = false;
    //    txtSimprocCPF.Visible = false;
    //    txtSimprocRG.Visible = false;
    //    txtDtAdmissao.Visible = false;
    //}

    //private void mostraConteudoSimproc()
    //{
    //    labelSimproc.Visible = true;
    //    labelSimprocCodicoUnidade.Visible = true;
    //    labelSimprocCPF.Visible = true;
    //    labelSimprocRG.Visible = true;
    //    labelSimprocDataAdmissao.Visible = true;
    //    txtSimprocCodigoUnidade.Visible = true;
    //    txtSimprocCPF.Visible = true;
    //    txtSimprocRG.Visible = true;
    //    txtDtAdmissao.Visible = true;
    //}
    //private void escondeConteudoGrafica()
    //{
    //    labelGrafica.Visible = false;
    //    ckbCentral.Visible = false;
    //    ckbGrafica.Visible = false;
    //    ckbfarmacia.Visible = false;
    //    ckbSND.Visible = false;
    //    ckbManutencao.Visible = false;
    //    ckbMecanica.Visible = false;
    //    ckbEstoqueLab.Visible = false;
    //    labelNcentroCusto.Visible = false;//Todo
    //    labelnovoGrafica.Visible = false;
    //    txtNcentroDeCustoGrafica.Visible = false;
    //    labelGraficaCpf.Visible = false;
    //    txtCPFgrafica.Visible = false;
    //    labelGraficaCota.Visible = false;
    //    rdbDiaria.Visible = false;
    //    rdbSemanal.Visible = false;
    //    rdbQuinzenal.Visible = false;
    //    rdbMensal.Visible = false;
    //}

    //private void mostraConteudoGrafica()
    //{
    //    labelGrafica.Visible = true;
    //    ckbCentral.Visible = true;
    //    ckbGrafica.Visible = true;
    //    ckbfarmacia.Visible = true;
    //    ckbSND.Visible = true;
    //    ckbManutencao.Visible = true;
    //    ckbMecanica.Visible = true;
    //    ckbEstoqueLab.Visible = true;
    //    labelNcentroCusto.Visible = true;//Todo
    //    labelnovoGrafica.Visible = true;
    //    txtNcentroDeCustoGrafica.Visible = true;
    //    labelGraficaCpf.Visible = true;
    //    txtCPFgrafica.Visible = true;
    //    labelGraficaCota.Visible = true;
    //    rdbDiaria.Visible = true;
    //    rdbSemanal.Visible = true;
    //    rdbQuinzenal.Visible = true;
    //    rdbMensal.Visible = true;
    //}
}
