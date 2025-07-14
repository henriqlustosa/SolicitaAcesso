using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ExcluirPermissoes : System.Web.UI.Page
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


        DadosSetoresSolicitados_S lista = new DadosSetoresSolicitados_S();
        lista = SolicitaAcessoDAO.GetSetoresCom_S(id);
        if (lista.RedeCorporativa == "C")
        {
            CkbExibeRedeCorporativa.Checked = true;
        }
        if (lista.SGH == "C")
        {
            ckbExibeSGH.Checked = true;
        }
        if (lista.Simproc == "C")
        {
            ckbExibeSimproc.Checked = true;
        }
        if (lista.Grafica == "C")
        {
            ckbExibeGrafica.Checked = true;
        }
        if (lista.OS_manutencao == "C")
        {
            ckbExibeOSmanutencao.Checked = true;
        }
        if (lista.Sei == "C")
        {
            ckbExibeSEI.Checked = true;
        }
        if (lista.Siga_Saude == "C")
        {
            ckbExibeSigaSaude.Checked = true;
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
            LabelRedeCaixaDepartamental_Descricao.Text = lista.caixaDepartamental_Descricao + " )";
        }
        if (lista.pastaDeRede == "True")
        {
            LabelRedePastaDeRede.Visible = true;
            LabelRedePastaEspecifica.Text = lista.PastaEspecifica + " )";
        }
    }

    private void CarregaSGH(int id)
    {
        DadosSGH lista = new DadosSGH();
        lista = SolicitaAcessoDAO.GetDadosSGH(id);

        if (lista.Amb == "True")
        {
            labelAmb.Visible = true;
            labelAmb_descricao.Text = lista.Amb_Desc + " )";
        }
        if (lista.CenCir == "True")
        {
            labelCentroCir.Visible = true;
            labelCentroCir_descricao.Text = lista.CenCir_Desc + " )";
        }
        if (lista.Internacao == "True")
        {
            labelInternacao.Visible = true;
            labelInternacao_descricao.Text = lista.Internacao_Desc + " )";
        }
        if (lista.PS == "True")
        {
            labelProntoSocorro.Visible = true;
            labelProntoSocorro_descricao.Text = lista.PS_Desc + " )";
        }
    }


    public static class Global
    {
        public static string localOrigem;
    }
    //protected void btnVoltar_Click(object sender, EventArgs e)
    //{
    //    string url;
    //    url = "" + Global.localOrigem + "";
    //    Response.Redirect(url, false);
    //}

    protected void SolicitarExcluir_Click(object sender, EventArgs e)
    {
        if (ckbExcluirRedePermisao.Checked == true || ckbExcluirPermisaoSGH.Checked == true || ckbExcluirPermissaoSimproc.Checked == true || ckbExcluirPermissaoGrafica.Checked == true || ckbExcluirPermissaoOSmanutencao.Checked == true || ckbExcluirPermissaoSei.Checked == true || ckbExcluirPermissaoSigaSaude.Checked == true)
        {

            int idChamado = Convert.ToInt32(id_Chamado.Text);

            if (ckbExcluirRedePermisao.Checked == true)
            {
                SolicitaAcessoDAO.Atualiza_Solicitacoes_setores_Update(idChamado, "RedeCorporativa", "E");
            }

            if (ckbExcluirPermisaoSGH.Checked == true)
            {
                SolicitaAcessoDAO.Atualiza_Solicitacoes_setores_Update(idChamado, "SGH", "E");
            }
            if (ckbExcluirPermissaoSimproc.Checked == true)
            {
                SolicitaAcessoDAO.Atualiza_Solicitacoes_setores_Update(idChamado, "Simproc", "E");
            }
            if (ckbExcluirPermissaoGrafica.Checked == true)
            {
                SolicitaAcessoDAO.Atualiza_Solicitacoes_setores_Update(idChamado, "Grafica", "E");
            }
            if (ckbExcluirPermissaoOSmanutencao.Checked == true)
            {
                SolicitaAcessoDAO.Atualiza_Solicitacoes_setores_Update(idChamado, "OS_manutencao", "E");
            }
            if (ckbExcluirPermissaoSei.Checked == true)
            {
                SolicitaAcessoDAO.Atualiza_Solicitacoes_setores_Update(idChamado, "Sei", "E");
            }
            if (ckbExcluirPermissaoSigaSaude.Checked == true)
            {
                SolicitaAcessoDAO.Atualiza_Solicitacoes_setores_Update(idChamado, "SigaSaude", "E");
            }

            SolicitaAcessoDAO.GravaOBSpermissaoExcluir(idChamado, txtOBSpermissaoExcluir.Text);
          


            string answer = "Solicitação de Retirada de Permissão enviada com sucesso";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                        "alert('" + answer + "'); window.location.href='PaginaInicial.aspx';", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Você não selecionou nenhum modulo para solicitar a retirada da permissão é obrigatório pelo menos 1 modulo selecionado');", true);

        }

    }
}