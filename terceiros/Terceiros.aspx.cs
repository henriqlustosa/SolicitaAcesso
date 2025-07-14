using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class funcionario_Terceiros : System.Web.UI.Page
{
    public static class VariaveisGlobais
    {
        public static string login { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("~/login.aspx"); // Redireciona se não estiver logado
                return;
            }
            // 2. Verifica se o perfil é diferente de "1" (Administrador)
            List<int> perfis = Session["perfis"] as List<int>;
            if (perfis == null || (!perfis.Contains(1) && !perfis.Contains(2) && !perfis.Contains(3)))
            {
                Response.Redirect("~/aberto/SemPermissao.aspx");
            }
            string nome = Session["nomeUsuario"] as string;
            VariaveisGlobais.login = Session["login"] as string;

            pegaNomeLoginUsuario.Text = nome.ToUpper();
          //  pegaNomeLoginUsuario.Text = User.Identity.Name.ToUpper();
            carregaDadosDoCoordenador();
            txtData.Text = DateTime.Now.ToShortDateString();
            dtHoraExtrato.Text = DateTime.Now.ToString();
            LabelMais1.Text = "0";
            ddlEmpresTerceiros.SelectedValue = "**SELECIONE**";
        }

        verificaCBK();
        verificaNovaExistenteRedeCoporativa();
        verificaSGHExibeCampos();
        verificaRedeCoporativaBloqueio();
        verificaLoginAcessoNovo();
        // Deslogar após 20 minutos
        Response.AppendHeader("Refresh",
        //Session TimeOut é em minutos e o Refresh e segundos, por isso o Session.Timeout * 60 JUNIOR>> 1 vale 20 segundos 3 vale 1 Minuto
        String.Concat((Session.Timeout * 60),
        //Página para onde o usuário será redirecionado
        ";URL=../login.aspx"));
    }

    private void verificaLoginAcessoNovo()
    {
        if (rdAcesso.Checked == true)
        {
            labelAsterisco3.Visible = false;
        }
    }

    private void verificaRedeCoporativaBloqueio()
    {
        CkbLoginBloqueio.Visible = rdBloqueio.Checked;
    }

    private void verificaSGHExibeCampos()
    {
        if (CkbSGHamb.Checked == false)
        {
            txtSGHAmb.Visible = false;
        }
        else
        {
            txtSGHAmb.Visible = true;
        }
        if (CkbCenCir.Checked == false)
        {
            txtSGHcentroCirurgico.Visible = false;
        }
        else
        {
            txtSGHcentroCirurgico.Visible = true;
        }
        if (CkbSGHInternacao.Checked == false)
        {
            txtSGHInternacao.Visible = false;
        }
        else
        {
            txtSGHInternacao.Visible = true;
        }
        if (CkbSGHprontoSocorro.Checked == false)
        {
            txtSGHProntoSocorro.Visible = false;
        }
        else
        {
            txtSGHProntoSocorro.Visible = true;
        }
    }
    private void verificaNovaExistenteRedeCoporativa()
    {
        if (CkbPastaRede.Checked == true)
        {
            rdbNovoRedeCorporativaPasta.Visible = true;
            rdbExistenteRedeCorporativaPasta.Visible = true;
        }
        else
        {
            rdbNovoRedeCorporativaPasta.Visible = false;
            rdbExistenteRedeCorporativaPasta.Visible = false;
            txtEspecificarRedeCorporativa.Visible = false;
        }

        if (rdbNovoRedeCorporativaPasta.Checked == true)
        {
            txtEspecificarRedeCorporativa.Visible = false;
        }
        else if (rdbExistenteRedeCorporativaPasta.Checked == true && CkbPastaRede.Checked == true)
        {
            txtEspecificarRedeCorporativa.Visible = true;
        }
    }

    private void verificaCBK()
    {
        bool anyPanelVisible = false;

        PanelRedeCorporativa.Visible = CkbExibeRedeCorporativa.Checked;
        if (PanelRedeCorporativa.Visible)
        {
            anyPanelVisible = true;
        }

        PanelSGH.Visible = ckbExibeSGH.Checked;
        if (PanelSGH.Visible)
        {
            anyPanelVisible = true;
        }

        if (ckbExibeSGH.Checked)
        {
            PanelDadosComplementares.Visible = !RdbJaTemSGH.Checked;
            if (PanelDadosComplementares.Visible)
            {
                anyPanelVisible = true;
            }
        }   
        else
        {
            PanelDadosComplementares.Visible = false;
        }
        PanelOsManutencao.Visible = ckbExibeOSmanutencao.Checked;
        if (PanelOsManutencao.Visible)
        {
            //txtCpfOS_Manutencao.Text = txtCPF.Text;
            anyPanelVisible = true;
        }
        txtObs_Geral.Visible = anyPanelVisible;
        Label_txtObs_Geral.Visible = anyPanelVisible;
        lblCharCount.Visible = anyPanelVisible;
    }


    //private void verificaCBK()
    //{
    //    if (CkbExibeRedeCorporativa.Checked == true)
    //    {
    //        PanelRedeCorporativa.Visible = true;
    //    }
    //    if (CkbExibeRedeCorporativa.Checked == false)
    //    {
    //        PanelRedeCorporativa.Visible = false;
    //    }
    //    if (ckbExibeSGH.Checked == true)
    //    {
    //        PanelSGH.Visible = true;
    //    }       

    //    if (RdbJaTemSGH.Checked == true)
    //    {
    //        PanelDadosComplementares.Visible = false;
    //    }
    //    if (RdbNaoTemSGH.Checked == true)
    //    {
    //        PanelDadosComplementares.Visible = true;
    //    }
    //    if (ckbExibeSGH.Checked == false)
    //    {
    //        PanelSGH.Visible = false;
    //        PanelDadosComplementares.Visible = false;
    //    }
    //}

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        if (CkbExibeRedeCorporativa.Checked == false && ckbExibeSGH.Checked == false && ckbExibeOSmanutencao.Checked == false)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Você não selecionou nenhum modulo para enviar uma solicitação a informatica é obrigatório pelo menos 1 modulo selecionado');", true);

        }
        else
        {
            if (CkbExibeRedeCorporativa.Checked == true && rdAcesso.Checked == false && rdAtualizar.Checked == false && rdBloqueio.Checked == false)
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Selecione Acesso ou Atualizar ou Bloqueio');", true);
                labelAsterisco.Visible = true;
                labelAsterisco1.Visible = true;
                labelAsterisco2.Visible = true;
            }
            else
            {
                if (CkbExibeRedeCorporativa.Checked == true && (rdAtualizar.Checked == true || rdBloqueio.Checked == true) && txtLogin.Text.Length < 7)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Quando seleciona Atualizar ou Bloquear acesso a rede, pasta etc... É obrigatório informar o login de rede.');", true);
                    labelAsterisco3.Visible = true;
                }
                else
                {
                    if (CkbExibeRedeCorporativa.Checked == true && rdBloqueio.Checked == true && CkbLoginBloqueio.Checked == false && CkbPastaRede.Checked == false)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Informe o que deseja bloquear');", true);
                    }
                    else

                    {
                        if (ddlEmpresTerceiros.SelectedValue == "**SELECIONE**")
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('É obrigatório informar o nome da empresa terceira.');", true);
                            labelNomeEmpresaAviso.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            //if (CkbExibeRedeCorporativa.Checked == false && ckbExibeSGH.Checked == false)
                            //{
                            //    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Você não selecionou nenhum modulo para enviar uma solicitação a informatica é obrigatório pelo menos 1 modulo selecionado');", true);

                            //}
                            //else
                            //{
                            if (ckbExibeSGH.Checked == true && CkbSGHamb.Checked == false && CkbCenCir.Checked == false && CkbSGHInternacao.Checked == false && CkbSGHprontoSocorro.Checked == false)
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Você marcou o SGH mas não escolheu nenhum modulo, escolha pelo menos 1 ou desmarque a opção SGH');", true);

                            }
                            else
                            {
                                cadastrarDadosDoSolicitante();


                                if (LabelJaExiste.Text == "NAO")
                                {
                                    if (CkbExibeRedeCorporativa.Checked == true)
                                    {
                                        cadastrarRedeCorporativa();
                                    }
                                    if (ckbExibeSGH.Checked == true)
                                    {
                                        cadastrarSGH();
                                    }
                                    if (RdbNaoTemSGH.Checked == true)
                                    {
                                        cadastrarDadosComp();
                                    }
                                    if (ckbExibeOSmanutencao.Checked == true)
                                    {
                                        cadastrarOSmanutencao();
                                    }
                                    gravaExtrato();

                                }
                                else if (LabelJaExiste.Text == "SIM")
                                {
                                    // ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Já existe Solicitação pedente para esse Funcionario, Espere a Informatica dar baixa em todos os Itens da Solicitação que está ativa ou Ligue 8123 ou 8124 e verifique a Situação!');", true);
                                    string answer = "Já existem 5 Solicitações em aberto para esse Funcionario, espere finalizar algumas ou Ligue 8123 ou 8124 e verifique a Situação!";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                                                "alert('" + answer + "'); window.location.href='Solicitar.aspx';", true);

                                }
                                //Response.Redirect("~/Solicitar.aspx");
                            }
                            //}
                        }


                    }
                }
            }
        }
    }

    private void gravaExtrato()
    {
        int id_chamadoExtrato = Convert.ToInt32(labelIdChamado.Text);
        SolicitaAcessoDAO.GravaExtratoInertInicial(id_chamadoExtrato, "Id Nº (" + labelIdChamado.Text + ") Aberto por: " + pegaNomeLoginUsuario.Text + " em: " + dtHoraExtrato.Text + " \n");
        SolicitaAcessoDAO.GravaOBS_Solicitacao_Geral(id_chamadoExtrato, txtObs_Geral.Text);

    }

    private void cadastrarDadosComp()
    {
        DadosCompSGH d = new DadosCompSGH();
        d.id_chamado_DadosCompl = Convert.ToInt32(labelIdChamado.Text);
        d.dtNasci_dadosComp = txtDadosCompDataNascimento.Text;
        d.nomeMae_dadosComp = txtDAdosCompNomeDaMae.Text.TrimStart();
        if (txtDadosCompCRM.Text.Length < 1)
        {
            txtDadosCompCRM.Text = "0";
        }
        d.crm_dadosComp = txtDadosCompCRM.Text.TrimStart().TrimEnd().Replace(".", "");
        d.cpf_dadosComp = txtCPF.Text.TrimStart().TrimEnd();
        d.rg_dadosComp = txtRG.Text.TrimStart().TrimEnd();
        d.status_dadosComp = "S";
        SolicitaAcessoDAO.GravaDadosCompSGH(d);
        int v = Convert.ToInt32(LabelMais1.Text);
        SolicitaAcessoDAO.GravaSolicitacoes_setores_Update(Convert.ToInt32(labelIdChamado.Text), "DadosSolicitadosSGH", v);
    }

    private void cadastrarSGH()
    {
        DadosSGH d = new DadosSGH();
        d.id_chamado_SGH = Convert.ToInt32(labelIdChamado.Text);
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
        int a;
        int v;
        a = Convert.ToInt32(LabelMais1.Text);
        v = a + 1;
        LabelMais1.Text = v.ToString();
        SolicitaAcessoDAO.GravaSolicitacoes_setores_Update(Convert.ToInt32(labelIdChamado.Text), "SGH", v);

        //,[Simproc] = @Simproc
        //,[Grafica] = @Grafica
        //,[OS_manutencao] = @OS_manutencao
        //,[Sei] = @Sei

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
            if (CkbLoginBloqueio.Checked == true)
            {
                d.redeCorporativa = rdBloqueio.Text + " (" + CkbLoginBloqueio.Text + ")";
            }
            else
            {
                d.redeCorporativa = rdBloqueio.Text;
            }
        }
        if (rdAtualizar.Checked == true)
        {
            d.redeCorporativa = rdAtualizar.Text;
        }
        d.emailCorporativo = "";
        d.caixaDepartamental = "";
        d.caixaDepartamental_Descricao = "";


        d.pastaDeRede = CkbPastaRede.Checked.ToString();
        d.PastaEspecifica = txtEspecificarRedeCorporativa.Text;
        d.caixaDepartamental_Descricao_Nova = "";//arrumar
        d.pastaDeRedeNova = "";//arrumar
        d.redeCorperativaNovoDerp = "";
        if (rdbNovoRedeCorporativaPasta.Checked == true)
        {
            d.redeCorperativaNovoPasta = "Nova";
        }
        else if (rdbNovoRedeCorporativaPasta.Checked == false)
        {
            d.redeCorperativaNovoPasta = "Existente:";
        }
        d.status_redeCoorporativa = "S";
        SolicitaAcessoDAO.GravaDadosRedeCorporativa(d);
        int a;
        int v;
        a = Convert.ToInt32(LabelMais1.Text);
        v = a + 1;
        LabelMais1.Text = v.ToString();
        SolicitaAcessoDAO.GravaSolicitacoes_setores_Update(Convert.ToInt32(labelIdChamado.Text), "RedeCorporativa", v);
    }

    private void cadastrarDadosDoSolicitante()
    {
        DadosSolicitacao d = new DadosSolicitacao();
        d.NomeFuncionario = txtNomeFuncionario.Text;
        d.RF_Funcionario = "(RG)-" + txtRG.Text;
        d.login = txtLogin.Text;
        d.cargoFuncionario = txtCargo.Text;
        d.ramal1 = txtRamal.Text;
        d.ramalFuncionario = txtRamal_2.Text;
        d.lotacao = txtLotacao.Text;
        d.dtSolicitacao = DateTime.Now;
        d.NomeSolicitante_Coordenador = txtSolicitante.Text;
        d.eMail = emailCoordenador.Text;
        d.Login_Solicitante = VariaveisGlobais.login;
        d.EmpresaFuncionario = ddlEmpresTerceiros.SelectedValue;

        bool Result = SolicitaAcessoDAO.GravaDadosSolicitacao(d);
        labelIdChamado.Text = Convert.ToString(SolicitaAcessoDAO.pegaID_BancoDeDados(d.dtSolicitacao, d.RF_Funcionario));


        if (Result == false)
        {
            SolicitaAcessoDAO.GravaSolicitacoes_setores(Convert.ToInt32(labelIdChamado.Text));
            //  ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Solicitação Gravada com suecesso!');", true);
            LabelJaExiste.Text = "NAO";
            string answer = "SOLICITAÇÃO GRAVADA COM SUCESSO!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                        "alert('" + answer + "'); window.location.href='../aberto/PaginaInicial.aspx';", true);

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
        lista = SolicitaAcessoDAO.GetDadosDosCoordenadoresPaginaSolicita(VariaveisGlobais.login);
        txtRamal.Text = lista.ramal1.ToString();
        //txtRamal_2.Text = lista.ramal2.ToString();
        txtLotacao.Text = lista.setorCoordenador;
        txtSolicitante.Text = lista.NomeCoordenador;
        emailCoordenador.Text = lista.eMail;
    }

    private void cadastrarOSmanutencao()
    {
        DadosOsManutencao d = new DadosOsManutencao();
        d.id_chamado_OSmanutencao = Convert.ToInt32(labelIdChamado.Text);
        d.N_centro_custos_novo = txtCentroDeCustoOS_Manutencao_Novo.Text;
        d.N_centro_custos_antigo = txtCentroDeCustoOS_Manutencao_Antigo.Text;
        d.cpf_manutencao = txtCPF.Text;


        d.status_os_manutencao = "S";
        SolicitaAcessoDAO.GravaDadosOSmanutencao(d);
        int a;
        int v;
        a = Convert.ToInt32(LabelMais1.Text);
        v = a + 1;
        LabelMais1.Text = v.ToString();
        SolicitaAcessoDAO.GravaSolicitacoes_setores_Update(Convert.ToInt32(labelIdChamado.Text), "OS_manutencao", v);

    }

}