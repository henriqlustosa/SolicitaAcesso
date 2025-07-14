using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VisualizarSolicitacoes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Global.localOrigem = Request.UrlReferrer.AbsolutePath;
            string id1 = Request.QueryString["IdChamado"];
            int id = Convert.ToInt32(id1);
            //int id2 = 22;
            carregarDadosSolicitante(id);
            id_Chamado.Text = id1;
            //id_Chamado.Text = "22";
            pegaNomeLoginUsuario.Text = User.Identity.Name.ToUpper();
            verificaCBK_SituacaoNobanco(Convert.ToInt32(id_Chamado.Text));
            verificaCBK();
            carregaExtratoSocilitaAcesso(id);
        }
        // Deslogar após 20 minutos
        Response.AppendHeader("Refresh",
        //Session TimeOut é em minutos e o Refresh e segundos, por isso o Session.Timeout * 60 JUNIOR>> 1 vale 20 segundos 3 vale 1 Minuto
        String.Concat((Session.Timeout * 60),
        //Página para onde o usuário será redirecionado
        ";URL=../login.aspx"));
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
        txtRamalFuncionario.Text = lista.ramalFuncionario;
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
        ckbExibeSigaSaude.Checked = false;
        ckbExibeDadosComp.Checked = false;

        DadosSetoresSolicitados_S lista = new DadosSetoresSolicitados_S();
        lista = SolicitaAcessoDAO.GetSetoresCom_S(id);
        if (lista.RedeCorporativa == "S" || lista.RedeCorporativa == "C" || lista.RedeCorporativa == "E" || lista.RedeCorporativa == "R" || lista.RedeCorporativa == "X")
        {
            CkbExibeRedeCorporativa.Checked = true;
        }
        if (lista.SGH == "S" || lista.SGH == "C" || lista.SGH == "E" || lista.SGH == "R" || lista.SGH == "X")
        {
            ckbExibeSGH.Checked = true;
        }
        if (lista.Simproc == "S" || lista.Simproc == "C" || lista.Simproc == "E" || lista.Simproc == "R" || lista.Simproc == "X")
        {
            ckbExibeSimproc.Checked = true;
        }
        if (lista.Grafica == "S" || lista.Grafica == "C" || lista.Grafica == "E" || lista.Grafica == "R" || lista.Grafica == "X")
        {
            ckbExibeGrafica.Checked = true;
        }
        if (lista.OS_manutencao == "S" || lista.OS_manutencao == "C" || lista.OS_manutencao == "E" || lista.OS_manutencao == "R" || lista.OS_manutencao == "X")
        {
            ckbExibeOSmanutencao.Checked = true;
        }
        if (lista.Sei == "S" || lista.Sei == "C" || lista.Sei == "E" || lista.Sei == "R" || lista.Sei == "X")
        {
            ckbExibeSEI.Checked = true;
        }
        if (lista.Siga_Saude == "S" || lista.Siga_Saude == "C" || lista.Siga_Saude == "E" || lista.Siga_Saude == "R" || lista.Siga_Saude == "X")
        {
            ckbExibeSigaSaude.Checked = true;
        }
        if (lista.DadosSolicitadosSGH == "S" || lista.DadosSolicitadosSGH == "C" || lista.DadosSolicitadosSGH == "E" || lista.DadosSolicitadosSGH == "R" || lista.DadosSolicitadosSGH == "X")
        {
            ckbExibeDadosComp.Checked = true;
        }

    }

    private void verificaCBK()
    {
        if (CkbExibeRedeCorporativa.Checked == true)
        {
            PanelRedeCorporativa.Visible = true;
            CarregaRedeCorporativa(Convert.ToInt32(id_Chamado.Text));
        }
        if (CkbExibeRedeCorporativa.Checked == false)
        {
            PanelRedeCorporativa.Visible = false;
        }
        if (ckbExibeSGH.Checked == true)
        {
            PanelSGH.Visible = true;
            CarregaSGH(Convert.ToInt32(id_Chamado.Text));
        }
        if (ckbExibeSGH.Checked == false)
        {
            PanelSGH.Visible = false;
        }
        if (ckbExibeSimproc.Checked == true)
        {
            PanelSimproc.Visible = true;
            CarregaSimproc(Convert.ToInt32(id_Chamado.Text));
        }
        if (ckbExibeSimproc.Checked == false)
        {
            PanelSimproc.Visible = false;
        }
        if (ckbExibeGrafica.Checked == true)
        {
            PanelGrafica.Visible = true;
            CarregaGrafica(Convert.ToInt32(id_Chamado.Text));
        }
        if (ckbExibeGrafica.Checked == false)
        {
            PanelGrafica.Visible = false;
        }
        if (ckbExibeOSmanutencao.Checked == true)
        {
            PanelOsManutencao.Visible = true;
            CarregaOSmanutencao(Convert.ToInt32(id_Chamado.Text));
        }
        if (ckbExibeOSmanutencao.Checked == false)
        {
            PanelOsManutencao.Visible = false;
        }
        if (ckbExibeSEI.Checked == true)
        {
            PanelSEI.Visible = true;
            CarregaSEI(Convert.ToInt32(id_Chamado.Text));
        }
        if (ckbExibeSEI.Checked == false)
        {
            PanelSEI.Visible = false;
        }
        if (ckbExibeSigaSaude.Checked == true)
        {
            PanelSiga_Saude.Visible = true;
            CarregaSigaSaude(Convert.ToInt32(id_Chamado.Text));
        }
        if (ckbExibeSigaSaude.Checked == false)
        {
            PanelSiga_Saude.Visible = false;
        }
        if (ckbExibeDadosComp.Checked == true)
        {
            PanelDadosPessoaisTerceiro.Visible = true;
            CarregaDadosSGH_Comp(Convert.ToInt32(id_Chamado.Text));
        }
        if (ckbExibeDadosComp.Checked == false)
        {
            PanelDadosPessoaisTerceiro.Visible = false;
        }
    }


    private void CarregaSigaSaude(int id)
    {
        DadosSigaSaude lista = new DadosSigaSaude();
        lista = SolicitaAcessoDAO.GetDadosSigaSaude(id);
        labelSigaSaudeDtNasc.Visible = true;
        labelSigaSaudeDtNasc_desc.Text = lista.dtNascSiga + " )";
        labelSigaSaudeNomeMae.Visible = true;
        labelSigaSaudeNomeMae_desc.Text = lista.nomeDaMaeSiga + " )";
        labelSigaSaudeCRM.Visible = true;
        labelSigaSaudeCRM_desc.Text = lista.CRM_siga + " )";
        labelSigaSaudeCPF.Visible = true;
        labelSigaSaudeCPF_desc.Text = lista.cpfSiga + " )";
        labelSigaSaudeRG.Visible = true;
        labelSigaSaudeRG_desc.Text = lista.RG_siga + " )";
        labelSigaSaudeUF.Visible = true;
        labelSigaSaudeUF_desc.Text = lista.UF_Siga + " )";
        labelSigaSaudeDtEmissao.Visible = true;
        labelSigaSaudeDtEmissao_desc.Text = lista.dtEmisaoRG_Siga + " )";
        labelSigaSaudeOrgao.Visible = true;
        labelSigaSaudeOrgao_desc.Text = lista.orgao_RG_Siga + " )";
        labelSigaSaudeNomeRua.Visible = true;
        labelSigaSaudeNomeRua_desc.Text = lista.nomeDaRuaSiga + " )";
        labelSigaSaudeNrua.Visible = true;
        labelSigaSaudeNrua_desc.Text = lista.NumeroDaRuaSiga + " )";
        labelSigaSaudeBairro.Visible = true;
        labelSigaSaudeBairro_desc.Text = lista.bairoSiga + " )";
        labelSigaSaudeCEP.Visible = true;
        labelSigaSaudeCEP_desc.Text = lista.CepSiga + " )";
        labelSigaSaudeModuloAcessar.Visible = true;
        labelSigaSaudeModuloAcessar_desc.Text = lista.ModuloAcessarSiga + " )";
        labelSigaSaudeOBS.Visible = true;
        labelSigaSaudeOBS_desc.Text = lista.ObsSiga + " )";

        if (lista.status_SigaSaude.Trim() == "S")
        {
            LabelSituacaoSigaSaude.Text = "Pendente";
            LabelSituacaoSigaSaude.ForeColor = System.Drawing.Color.Orange;
        }
        else if (lista.status_SigaSaude.Trim() == "C")
        {
            LabelSituacaoSigaSaude.Text = "Concluido";
            LabelSituacaoSigaSaude.ForeColor = System.Drawing.Color.Green;
        }
        else if (lista.status_SigaSaude.Trim() == "E")
        {
            LabelSituacaoSigaSaude.Text = "Solicitado a Remoção da permissão";
            LabelSituacaoSigaSaude.ForeColor = System.Drawing.Color.Gold;
        }
        else if (lista.status_SigaSaude.Trim() == "R")
        {
            LabelSituacaoSigaSaude.Text = "Permissão removida";
            LabelSituacaoSigaSaude.ForeColor = System.Drawing.Color.Red;
        }
        else if (lista.status_SigaSaude.Trim() == "X")
        {
            LabelSituacaoSigaSaude.Text = "Solicitação Recusada";
            LabelSituacaoSigaSaude.ForeColor = System.Drawing.Color.Red;
        }
    }

    private void CarregaSEI(int id)
    {
        DadosSei lista = new DadosSei();
        lista = SolicitaAcessoDAO.GetDadosSEI(id);
        labelSeiSiglaUnidade_1.Visible = true;
        labelSeiSiglaUnidade_1_desc.Text = lista.siglasUnidades1 + " )";
        labelSeiSiglaUnidade_2.Visible = true;
        labelSeiSiglaUnidade_2_desc.Text = lista.siglasUnidades2 + " )";
        labelSeiSiglaUnidade_3.Visible = true;
        labelSeiSiglaUnidade_3_desc.Text = lista.siglasUnidades3 + " )";
        labelSeiSiglaUnidade_4.Visible = true;
        labelSeiSiglaUnidade_4_desc.Text = lista.siglasUnidades4 + " )";
        if (lista.status_Sei.Trim() == "S")
        {
            LabelSituacaoSEI.Text = "Pendente";
            LabelSituacaoSEI.ForeColor = System.Drawing.Color.Orange;
        }
        else if (lista.status_Sei.Trim() == "C")
        {
            LabelSituacaoSEI.Text = "Concluido";
            LabelSituacaoSEI.ForeColor = System.Drawing.Color.Green;
        }
        else if (lista.status_Sei.Trim() == "E")
        {
            LabelSituacaoSEI.Text = "Solicitado a Remoção da permissão";
            LabelSituacaoSEI.ForeColor = System.Drawing.Color.Gold;
        }
        else if (lista.status_Sei.Trim() == "R")
        {
            LabelSituacaoSEI.Text = "Permissão removida";
            LabelSituacaoSEI.ForeColor = System.Drawing.Color.Red;
        }
        else if (lista.status_Sei.Trim() == "X")
        {
            LabelSituacaoSEI.Text = "Solicitação Recusada";
            LabelSituacaoSEI.ForeColor = System.Drawing.Color.Red;
        }
    }

    private void CarregaOSmanutencao(int id)
    {
        DadosOsManutencao lista = new DadosOsManutencao();
        lista = SolicitaAcessoDAO.GetDadosOsManutencao(id);
        labelOsManutencaoNcentroCustoNovo.Visible = true;
        labelOsManutencaoNcentroCustoNovo_desc.Text = lista.N_centro_custos_novo + " )";

        if (lista.N_centro_custos_antigo != "")
        {
            labelOsManutencaoNcentroCustoAntigo.Visible = true;
            labelOsManutencaoNcentroCustoAntigo_desc.Text = lista.N_centro_custos_antigo + " )";
        }

        labelOsManutencaoCPF.Visible = true;
        labelOsManutencaoCPF_desc.Text = lista.cpf_manutencao + " )";

        if (lista.status_os_manutencao.Trim() == "S")
        {
            LabelSituacaoOsManutencao.Text = "Pendente";
            LabelSituacaoOsManutencao.ForeColor = System.Drawing.Color.Orange;
        }
        else if (lista.status_os_manutencao.Trim() == "C")
        {
            LabelSituacaoOsManutencao.Text = "Concluido";
            LabelSituacaoOsManutencao.ForeColor = System.Drawing.Color.Green;
        }
        else if (lista.status_os_manutencao.Trim() == "E")
        {
            LabelSituacaoOsManutencao.Text = "Solicitado a Remoção da permissão";
            LabelSituacaoOsManutencao.ForeColor = System.Drawing.Color.Gold;
        }
        else if (lista.status_os_manutencao.Trim() == "R")
        {
            LabelSituacaoOsManutencao.Text = "Permissão removida";
            LabelSituacaoOsManutencao.ForeColor = System.Drawing.Color.Red;
        }
        else if (lista.status_os_manutencao.Trim() == "X")
        {
            LabelSituacaoOsManutencao.Text = "Solicitação Recusada";
            LabelSituacaoOsManutencao.ForeColor = System.Drawing.Color.Red;
        }
    }

    private void CarregaGrafica(int id)
    {
        DadosGrafica lista = new DadosGrafica();
        lista = SolicitaAcessoDAO.GetDadosGrafica(id);
        labelgraficaSolicitado.Visible = true;
        labelGraficaNcentroCusto.Visible = true;
        labelGraficaNcentroCusto_desc.Text = lista.N_centro_custo_grafica + " )";
        labelGraficaNcentroCusto_Antigo.Visible = true;
        labelGraficaNcentroCusto_Antigo_desc.Text = lista.N_centro_custo_grafica_antigo + " )";
        labelGraficaCPF.Visible = true;
        labelGraficaCPF_desc.Text = lista.cpf_grafica + " )";

        if (lista.status_grafica.Trim() == "S")
        {
            LabelSituacaoGrafica.Text = "Pendente";
            LabelSituacaoGrafica.ForeColor = System.Drawing.Color.Orange;
        }
        else if (lista.status_grafica.Trim() == "C")
        {
            LabelSituacaoGrafica.Text = "Concluido";
            LabelSituacaoGrafica.ForeColor = System.Drawing.Color.Green;
        }
        else if (lista.status_grafica.Trim() == "E")
        {
            LabelSituacaoGrafica.Text = "Solicitado a Remoção da permissão";
            LabelSituacaoGrafica.ForeColor = System.Drawing.Color.Gold;
        }
        else if (lista.status_grafica.Trim() == "R")
        {
            LabelSituacaoGrafica.Text = "Permissão removida";
            LabelSituacaoGrafica.ForeColor = System.Drawing.Color.Red;
        }
        else if (lista.status_grafica.Trim() == "X")
        {
            LabelSituacaoGrafica.Text = "Solicitação Recusada";
            LabelSituacaoGrafica.ForeColor = System.Drawing.Color.Red;
        }
    }

    private void CarregaSimproc(int id)
    {
        DadosSimproc lista = new DadosSimproc();
        lista = SolicitaAcessoDAO.GetDadosSimproc(id);
        labelSimprocCod_Uni.Visible = true;
        labelSimprocCod_Uni_Desc.Text = lista.CodigoUnidade_Simproc + " )";
        labelSimprocCpf.Visible = true;
        labelSimprocCpf_Desc.Text = lista.cpf_simproc + " )";
        labelSimprocRG.Visible = true;
        labelSimprocRG_Desc.Text = lista.rg_simproc + " )";
        labelSimprocDtAdmissao.Visible = true;
        labelSimprocDtAdmissao_Desc.Text = lista.dataAdmissao + " )";
        if (lista.status_Simproc.Trim() == "S")
        {
            LabelSituacaoSimproc.Text = "Pendente";
            LabelSituacaoSimproc.ForeColor = System.Drawing.Color.Orange;
        }
        else if (lista.status_Simproc.Trim() == "C")
        {
            LabelSituacaoSimproc.Text = "Concluido";
            LabelSituacaoSimproc.ForeColor = System.Drawing.Color.Green;
        }
        else if (lista.status_Simproc.Trim() == "E")
        {
            LabelSituacaoSimproc.Text = "Solicitado a Remoção da permissão";
            LabelSituacaoSimproc.ForeColor = System.Drawing.Color.Gold;
        }
        else if (lista.status_Simproc.Trim() == "R")
        {
            LabelSituacaoSimproc.Text = "Permissão removida";
            LabelSituacaoSimproc.ForeColor = System.Drawing.Color.Red;
        }
        else if (lista.status_Simproc.Trim() == "X")
        {
            LabelSituacaoSimproc.Text = "Solicitação Recusada";
            LabelSituacaoSimproc.ForeColor = System.Drawing.Color.Red;
        }
    }

    private void CarregaRedeCorporativa(int id)
    {
        DadosRedeCoorporativa lista = new DadosRedeCoorporativa();
        lista = SolicitaAcessoDAO.GetDadosRedeCorporativaSolicitacao(id);
        LabelRedeTipoSolicitacao.Text = lista.redeCorporativa;
        if (lista.emailCorporativo == "True")
        {
            LabelRedeEmail.Visible = true;
        }
        if (lista.caixaDepartamental == "True")
        {
            LabelRedeCaixaDepartamental.Visible = true;
            LabelRedeCaixaDepartamental_Descricao.Text = lista.caixaDepartamental_Descricao + " " + lista.caixaDepartamental_DescricaoNova + " )";
        }
        if (lista.pastaDeRede == "True")
        {
            LabelRedePastaDeRede.Visible = true;
            LabelRedePastaEspecifica.Text = lista.PastaEspecifica + " )";
        }
        if (lista.status_redeCoorporativa.Trim() == "S")
        {
            LabelSituacaoRedeCorporativa.Text = "Pendente";
            LabelSituacaoRedeCorporativa.ForeColor = System.Drawing.Color.Orange;
        }
        else if (lista.status_redeCoorporativa.Trim() == "C")
        {
            LabelSituacaoRedeCorporativa.Text = "Concluido";
            LabelSituacaoRedeCorporativa.ForeColor = System.Drawing.Color.Green;
        }
        else if (lista.status_redeCoorporativa.Trim() == "E")
        {
            LabelSituacaoRedeCorporativa.Text = "Solicitado a Remoção da permissão";
            LabelSituacaoRedeCorporativa.ForeColor = System.Drawing.Color.Gold;
        }
        else if (lista.status_redeCoorporativa.Trim() == "R")
        {
            LabelSituacaoRedeCorporativa.Text = "Permissão removida";
            LabelSituacaoRedeCorporativa.ForeColor = System.Drawing.Color.Red;
        }
        else if (lista.status_redeCoorporativa.Trim() == "X")
        {
            LabelSituacaoRedeCorporativa.Text = "Solicitação Recusada";
            LabelSituacaoRedeCorporativa.ForeColor = System.Drawing.Color.Red;
        }
    }

    private void CarregaSGH(int id)
    {
        DadosSGH lista = new DadosSGH();
        lista = SolicitaAcessoDAO.GetDadosSGH(id);

        if (lista.Amb == "True")
        {
            labelAmb.Visible = true;
            labelAmb_descricao.Text = "( " + lista.Amb_Desc + " )";
        }
        if (lista.CenCir == "True")
        {
            labelCentroCir.Visible = true;
            labelCentroCir_descricao.Text = "( " + lista.CenCir_Desc + " )";
        }
        if (lista.Internacao == "True")
        {
            labelInternacao.Visible = true;
            labelInternacao_descricao.Text = "( " + lista.Internacao_Desc + " )";
        }
        if (lista.PS == "True")
        {
            labelProntoSocorro.Visible = true;
            labelProntoSocorro_descricao.Text = "( " + lista.PS_Desc + " )";
        }
        if (lista.status_SGH.Trim() == "S")
        {
            LabelSituacaoSGH.Text = "Pendente";
            LabelSituacaoSGH.ForeColor = System.Drawing.Color.Orange;
        }
        else if (lista.status_SGH.Trim() == "C")
        {
            LabelSituacaoSGH.Text = "Concluido";
            LabelSituacaoSGH.ForeColor = System.Drawing.Color.Green;
        }
        else if (lista.status_SGH.Trim() == "E")
        {
            LabelSituacaoSGH.Text = "Solicitado a Remoção da permissão";
            LabelSituacaoSGH.ForeColor = System.Drawing.Color.Gold;
        }
        else if (lista.status_SGH.Trim() == "R")
        {
            LabelSituacaoSGH.Text = "Permissão removida";
            LabelSituacaoSGH.ForeColor = System.Drawing.Color.Red;
        }
        else if (lista.status_SGH.Trim() == "X")
        {
            LabelSituacaoSGH.Text = "Solicitação Recusada";
            LabelSituacaoSGH.ForeColor = System.Drawing.Color.Red;

        }

    }
    private void CarregaDadosSGH_Comp(int id)
    {
        DadosCompSGH lista = new DadosCompSGH();
        lista = SolicitaAcessoDAO.GetDadosSGH_Comp(id);
        LabelDadosCompDtNasc.Visible = true;
        LabelDadosCompDtNasc_desc.Text = "( " + lista.dtNasci_dadosComp + " )";
        LabelDadosCompNomeDaMae.Visible = true;
        LabelDadosCompNomeDaMae_desc.Text = "( " + lista.nomeMae_dadosComp + " )";
        LabelDadosCompCRM.Visible = true;
        LabelDadosCompCRM_desc.Text = "( " + lista.crm_dadosComp + " )";
        LabelDadosCompRG.Visible = true;
        LabelDadosCompRG_desc.Text = "( " + lista.rg_dadosComp + " )";
        LabelDadosCompCPF.Visible = true;
        LabelDadosCompCPF_desc.Text = "( " + lista.cpf_dadosComp + " )";
    }

    public static class Global
    {
        public static string localOrigem;
    }
    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        string url;
        url = "" + Global.localOrigem + "";
        Response.Redirect(url, false);
    }

    private void carregaExtratoSocilitaAcesso(int idChamado)
    {
        txt_OBS_Funcionario.Text = SolicitaAcessoDAO.GetDadosExtratoAcesso(idChamado);
        int numberOfLines = txt_OBS_Funcionario.Text.Split('\n').Length;
        txt_OBS_Funcionario.Rows = numberOfLines;
    }


}