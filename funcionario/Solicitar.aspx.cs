using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class Solicitar : System.Web.UI.Page
{
    public static class VariaveisGlobais
    {
        public static string login { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!User.Identity.IsAuthenticated)
        //{
        //    // Redireciona para a página de login se o usuário não estiver autenticado
        //    Response.Redirect("~/login.aspx");
        //    return;
        //}

        //if (!User.IsInRole("funcionario"))
        //{
        //    // Se o usuário não tem a permissão, armazene uma mensagem e redirecione
        //    Session["AccessDeniedMessage"] = "Você não pode solicitar acesso a Funcionários do HSPM, Sua permissão é para solicitar acesso a Funcionários Terceirizados.  <br /> clique no botão (Funcionário Terceiro).";
        //    Response.Redirect("../aberto/PaginaInicial.aspx"); // Redireciona para a página inicial ou uma página de acesso negado
        //}
        // 1. Verifica se o usuário está logado (existe sessão)
        if (Session["login"] == null)
        {
            Response.Redirect("~/login.aspx"); // Redireciona se não estiver logado
            return;
        }
        // 2. Verifica se o perfil é diferente de "1" (Administrador)
        List<int> perfis = Session["perfis"] as List<int>;
        if (perfis == null || (!perfis.Contains(1) && !perfis.Contains(2)))
        {
            Response.Redirect("~/aberto/SemPermissao.aspx");
        }
        string nome = Session["nomeUsuario"] as string;
   VariaveisGlobais.login = Session["login"] as string;
        if (!this.IsPostBack)
        {
            pegaNomeLoginUsuario.Text = nome.ToUpper();
          //  pegaNomeLoginUsuario.Text = User.Identity.Name.ToUpper();
            carregaDadosDoCoordenador();
            txtData.Text = DateTime.Now.ToShortDateString();
            dtHoraExtrato.Text = DateTime.Now.ToString();
            LabelMais1.Text = "0";
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

        //carregaCPFTodosCampos();
    }

    private void verificaLoginAcessoNovo()
    {
        if (rdAcesso.Checked==true)
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
        var checkboxes = new[]
        {
        new { Checkbox = CkbSGHamb, TextBox = txtSGHAmb },
        new { Checkbox = CkbCenCir, TextBox = txtSGHcentroCirurgico },
        new { Checkbox = CkbSGHInternacao, TextBox = txtSGHInternacao },
        new { Checkbox = CkbSGHprontoSocorro, TextBox = txtSGHProntoSocorro }
    };

        foreach (var item in checkboxes)
        {
            item.TextBox.Visible = item.Checkbox.Checked;
        }
    }

    //private void verificaSGHExibeCampos()
    //{
    //    if (CkbSGHamb.Checked == false)
    //    {
    //        txtSGHAmb.Visible = false;
    //    }
    //    else
    //    {
    //        txtSGHAmb.Visible = true;
    //    }
    //    if (CkbCenCir.Checked == false)
    //    {
    //        txtSGHcentroCirurgico.Visible = false;
    //    }
    //    else
    //    {
    //        txtSGHcentroCirurgico.Visible = true;
    //    }
    //    if (CkbSGHInternacao.Checked == false)
    //    {
    //        txtSGHInternacao.Visible = false;
    //    }
    //    else
    //    {
    //        txtSGHInternacao.Visible = true;
    //    }
    //    if (CkbSGHprontoSocorro.Checked == false)
    //    {
    //        txtSGHProntoSocorro.Visible = false;
    //    }
    //    else
    //    {
    //        txtSGHProntoSocorro.Visible = true;
    //    }
    //}

    private void verificaNovaExistenteRedeCoporativa()
    {
        // Verificação de Caixa Departamental
        if (CkbCaixaDepartamental.Checked == true)
        {
            rdbNovoRedeCorporativa.Visible = true;
            rdbExistenteRedeCorporativa.Visible = true;
        }
        else
        {
            rdbNovoRedeCorporativa.Visible = false;
            rdbExistenteRedeCorporativa.Visible = false;
            txtCaixaDepartamentalRedeCorporativa.Visible = false;
            txtCaixaDepartamentalRedeCorporativaNova.Visible = false;
        }

        // Verificação de Pasta de Rede
        if (CkbPastaRede.Checked == true)
        {
            rdbNovoRedeCorporativaPasta.Visible = true;
            rdbExistenteRedeCorporativaPasta.Visible = true;
        }
        else
        {
            // Se a checkbox NÃO estiver marcada, tudo relacionado à pasta deve estar invisível
            rdbNovoRedeCorporativaPasta.Visible = false;
            rdbExistenteRedeCorporativaPasta.Visible = false;
            txtEspecificarRedeCorporativaNova.Visible = false;  // Garante que esteja invisível
            txtEspecificarRedeCorporativa.Visible = false;
        }

        // Verificação de RadioButton para Caixa Departamental
        if (CkbCaixaDepartamental.Checked == true)
        {
            if (rdbNovoRedeCorporativa.Checked == true)
            {
                txtCaixaDepartamentalRedeCorporativa.Visible = false;
                txtCaixaDepartamentalRedeCorporativaNova.Visible = true;
            }
            else if (rdbExistenteRedeCorporativa.Checked == true)
            {
                txtCaixaDepartamentalRedeCorporativa.Visible = true;
                txtCaixaDepartamentalRedeCorporativaNova.Visible = false;
            }
        }

        // Verificação de RadioButton para Pasta de Rede
        if (CkbPastaRede.Checked == true)
        {
            if (rdbNovoRedeCorporativaPasta.Checked == true)
            {
                txtEspecificarRedeCorporativa.Visible = false;
                txtEspecificarRedeCorporativaNova.Visible = true;
            }
            else if (rdbExistenteRedeCorporativaPasta.Checked == true)
            {
                txtEspecificarRedeCorporativa.Visible = true;
                txtEspecificarRedeCorporativaNova.Visible = false;
            }
        }
    }


    private void verificaCBK()
    {
        var panels = new[]
     {
        new { Checkbox = CkbExibeRedeCorporativa, Panel = PanelRedeCorporativa },
        new { Checkbox = ckbExibeSGH, Panel = PanelSGH },
        new { Checkbox = ckbExibeSimproc, Panel = PanelSimproc },
        new { Checkbox = ckbExibeGrafica, Panel = PanelGrafica },
        new { Checkbox = ckbExibeOSmanutencao, Panel = PanelOsManutencao },
        new { Checkbox = ckbExibeSEI, Panel = PanelSEI },
        new { Checkbox = CkbExibeSiga_Saude, Panel = PanelSiga_Saude }
    };

        bool anyPanelVisible = false;

        foreach (var item in panels)
        {
            item.Panel.Visible = item.Checkbox.Checked;
            if (item.Checkbox.Checked)
            {
                anyPanelVisible = true;
            }
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
    //    if (ckbExibeSGH.Checked == false)
    //    {
    //        PanelSGH.Visible = false;
    //    }
    //    if (ckbExibeSimproc.Checked == true)
    //    {
    //        PanelSimproc.Visible = true;
    //    }
    //    if (ckbExibeSimproc.Checked == false)
    //    {
    //        PanelSimproc.Visible = false;
    //    }
    //    if (ckbExibeGrafica.Checked == true)
    //    {
    //        PanelGrafica.Visible = true;
    //    }
    //    if (ckbExibeGrafica.Checked == false)
    //    {
    //        PanelGrafica.Visible = false;
    //    }
    //    if (ckbExibeOSmanutencao.Checked == true)
    //    {
    //        PanelOsManutencao.Visible = true;
    //    }
    //    if (ckbExibeOSmanutencao.Checked == false)
    //    {
    //        PanelOsManutencao.Visible = false;
    //    }
    //    if (ckbExibeSEI.Checked == true)
    //    {
    //        PanelSEI.Visible = true;
    //    }
    //    if (ckbExibeSEI.Checked == false)
    //    {
    //        PanelSEI.Visible = false;
    //    }
    //    if (CkbExibeSiga_Saude.Checked == true)
    //    {
    //        PanelSiga_Saude.Visible = true;
    //    }
    //    if (CkbExibeSiga_Saude.Checked == false)
    //    {
    //        PanelSiga_Saude.Visible = false;
    //    }
    //}

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        if ((CkbPastaRede.Checked == true && rdbExistenteRedeCorporativaPasta.Checked == true || rdbNovoRedeCorporativaPasta.Checked == true) || CkbPastaRede.Checked == false)
        {
            if ((CkbCaixaDepartamental.Checked == true && rdbNovoRedeCorporativa.Checked == true || rdbExistenteRedeCorporativa.Checked == true) || CkbCaixaDepartamental.Checked == false)
            {
                if (CkbExibeRedeCorporativa.Checked == false && ckbExibeSGH.Checked == false && ckbExibeSimproc.Checked == false && ckbExibeGrafica.Checked == false && ckbExibeOSmanutencao.Checked == false && ckbExibeSEI.Checked == false && CkbExibeSiga_Saude.Checked == false)
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
                            if (CkbExibeRedeCorporativa.Checked == true && (rdBloqueio.Checked == true || rdAtualizar.Checked == true) && CkbEmail.Checked == false && CkbCaixaDepartamental.Checked == false && CkbLoginBloqueio.Checked == false && CkbPastaRede.Checked == false)
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Informe o que deseja atualizar ou bloquear');", true);
                            }
                            else
                            {
                                if (txtRF.Text.Length > 6)
                                {
                                    string rf1 = txtRF.Text.Substring(0, 7);
                                    if (txtLogin.Text.ToUpper() != pegaNomeLoginUsuario.Text.ToUpper() && rfCordenador.Text != rf1)
                                    {
                                        //if (CkbExibeRedeCorporativa.Checked == false && ckbExibeSGH.Checked == false && ckbExibeSimproc.Checked == false && ckbExibeGrafica.Checked == false && ckbExibeOSmanutencao.Checked == false && ckbExibeSEI.Checked == false && CkbExibeSiga_Saude.Checked == false)
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
                                                if (ckbExibeSimproc.Checked == true)
                                                {
                                                    cadastrarSimproc();
                                                }
                                                if (ckbExibeGrafica.Checked == true)
                                                {
                                                    cadastrarGrafica();
                                                }
                                                if (ckbExibeOSmanutencao.Checked == true)
                                                {
                                                    cadastrarOSmanutencao();
                                                }
                                                if (ckbExibeSEI.Checked == true)
                                                {
                                                    cadastrarSei();
                                                }
                                                if (CkbExibeSiga_Saude.Checked == true)
                                                {
                                                    cadastrarSiga_Saude();
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
                                    else
                                    {
                                        string answer = "ERRO! Você não pode Solicitar permissões para você, peça ao seu superior.";
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                                                    "alert('" + answer + "'); window.location.href='Solicitar.aspx';", true);
                                    }
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "mensagem", "alert('ERRO! Verifique o RF (OBS: Composto por 7 digitos)');", true);
                                }
                            }
                        }
                    }

                }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Você selecionou Caixa Departamental, marque se é nova ou existente, se for nova faça uma sugestão de nome, se o setor já tem marque existente e informe o nome da Caixa Departamental.');", true);

            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Você selecionou Pasta de rede, marque se é nova ou existente, se for nova faça uma sugestão de nome, se o setor já tem marque existente e informe o endereço completo.');", true);

        }



    }

    private void gravaExtrato()
    {
        int id_chamadoExtrato = Convert.ToInt32(labelIdChamado.Text);
        SolicitaAcessoDAO.GravaExtratoInertInicial(id_chamadoExtrato, "Id Nº (" + labelIdChamado.Text + ") Aberto por: " + pegaNomeLoginUsuario.Text + " em: " + dtHoraExtrato.Text + " \n");
        SolicitaAcessoDAO.GravaOBS_Solicitacao_Geral(id_chamadoExtrato, txtObs_Geral.Text);
        SolicitaAcessoDAO.GravaExtratoInertInicial_Funcionario(id_chamadoExtrato);

    }

    private void cadastrarSiga_Saude()
    {
        //bool valido = validaCPF(txtSigaCPF.Text);

        //if (valido==true)
        //{
        DadosSigaSaude d = new DadosSigaSaude();
        d.id_chamado_sigaSaude = Convert.ToInt32(labelIdChamado.Text);
        d.dtNascSiga = txtSigaDataNascimento.Text;
        d.nomeDaMaeSiga = txtSigaNomeDaMae.Text.TrimStart();
        if (txtSigaCRM.Text.Length < 1)
        {
            txtSigaCRM.Text = "0";
        }
        d.CRM_siga = Convert.ToInt32(txtSigaCRM.Text.TrimStart().TrimEnd().Replace(".",""));
        d.cpfSiga = txtSigaCPF.Text;
        d.RG_siga = txtSigaRG.Text;
        d.UF_Siga = txtSigaUF.Text;
        d.dtEmisaoRG_Siga = txtSigaDtEmissao.Text;
        d.orgao_RG_Siga = txtSigaOrgaoEmissor.Text;
        d.nomeDaRuaSiga = txtSigaNomeDaRua.Text;
        d.NumeroDaRuaSiga = Convert.ToInt32(txtSigaNumeroRua.Text);
        d.bairoSiga = txtSigaBairro.Text;
        d.CepSiga = txtSigaCep.Text;
        d.ModuloAcessarSiga = txtSigaModuloQueIraUsar.Text;
        d.ObsSiga = txtSigaOBS.Text.TrimStart();
        d.status_SigaSaude = "S";
        SolicitaAcessoDAO.GravaDadosSigaSaude(d);
        int a;
        int v;
        a = Convert.ToInt32(LabelMais1.Text);
        v = a + 1;
        LabelMais1.Text = v.ToString();
        SolicitaAcessoDAO.GravaSolicitacoes_setores_Update(Convert.ToInt32(labelIdChamado.Text), "SigaSaude", v);
        //}
        //else
        //{
        //    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Modulo Siga-Saude >>>> CPF INVALIDO, Verifique se digitou corretamente');", true);
        //}

        //não deu certo em partes verificar 
    }

    private void cadastrarSei()
    {
        DadosSei d = new DadosSei();
        d.id_chamado_Sei = Convert.ToInt32(labelIdChamado.Text);
        d.siglasUnidades1 = txtSei_1.Text;
        d.siglasUnidades2 = txtSei_2.Text;
        d.siglasUnidades3 = txtSei_3.Text;
        d.siglasUnidades4 = txtSei_4.Text;

        d.status_Sei = "S";
        SolicitaAcessoDAO.GravaDadosSei(d);
        int a;
        int v;
        a = Convert.ToInt32(LabelMais1.Text);
        v = a + 1;
        LabelMais1.Text = v.ToString();
        SolicitaAcessoDAO.GravaSolicitacoes_setores_Update(Convert.ToInt32(labelIdChamado.Text), "Sei", v);

    }

    private void cadastrarOSmanutencao()
    {
        DadosOsManutencao d = new DadosOsManutencao();
        d.id_chamado_OSmanutencao = Convert.ToInt32(labelIdChamado.Text);
        d.N_centro_custos_novo = txtCentroDeCustoOS_Manutencao_Novo.Text;
        d.N_centro_custos_antigo = txtCentroDeCustoOS_Manutencao_Antigo.Text;
        d.cpf_manutencao = txtCpfOS_Manutencao.Text;


        d.status_os_manutencao = "S";
        SolicitaAcessoDAO.GravaDadosOSmanutencao(d);
        int a;
        int v;
        a = Convert.ToInt32(LabelMais1.Text);
        v = a + 1;
        LabelMais1.Text = v.ToString();
        SolicitaAcessoDAO.GravaSolicitacoes_setores_Update(Convert.ToInt32(labelIdChamado.Text), "OS_manutencao", v);

    }

    private void cadastrarGrafica()
    {
        DadosGrafica d = new DadosGrafica();
        d.id_chamado_grafica = Convert.ToInt32(labelIdChamado.Text);
        d.N_centro_custo_grafica = txtNcentroDeCustoGrafica.Text;
        d.N_centro_custo_grafica_antigo = txtNcentroDeCustoAntigoGrafica.Text;
        d.cpf_grafica = txtCPFgrafica.Text;

        d.status_grafica = "S";
        //for (int i = 0; i < CkbListGraficaSetor.Items.Count; i++)
        //{
        //    if (CkbListGraficaSetor.Items[i].Selected)
        //    {

        //        d.setor_solicitado_Grafica += " ( " + CkbListGraficaSetor.Items[i].Text + " ) ";

        //    }
        //}

        SolicitaAcessoDAO.GravaDadosGrafica(d);
        int a;
        int v;
        a = Convert.ToInt32(LabelMais1.Text);
        v = a + 1;
        LabelMais1.Text = v.ToString();
        SolicitaAcessoDAO.GravaSolicitacoes_setores_Update(Convert.ToInt32(labelIdChamado.Text), "Grafica", v);

        //d.setor_solicitado_Grafica = 
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
        int a;
        int v;
        a = Convert.ToInt32(LabelMais1.Text);
        v = a + 1;
        LabelMais1.Text = v.ToString();
        SolicitaAcessoDAO.GravaSolicitacoes_setores_Update(Convert.ToInt32(labelIdChamado.Text), "Simproc", v);


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

        //    ,[Simproc] = @Simproc
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
        d.emailCorporativo = CkbEmail.Checked.ToString();
        d.caixaDepartamental = CkbCaixaDepartamental.Checked.ToString();
        d.caixaDepartamental_Descricao = txtCaixaDepartamentalRedeCorporativa.Text;
        //d.caixaDepartamental_Descricao_Nova = txtCaixaDepartamentalRedeCorporativaNova.Text;
        d.pastaDeRede = CkbPastaRede.Checked.ToString();
        d.PastaEspecifica = txtEspecificarRedeCorporativa.Text;
        d.caixaDepartamental_Descricao_Nova = txtCaixaDepartamentalRedeCorporativaNova.Text;
        d.pastaDeRedeNova = txtEspecificarRedeCorporativaNova.Text;
        if (rdbNovoRedeCorporativa.Checked == true)
        {
            d.redeCorperativaNovoDerp = "Nova";
        }
        else if (rdbNovoRedeCorporativa.Checked == false)
        {
            d.redeCorperativaNovoDerp = "Existente:";
        }

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
        d.RF_Funcionario = txtRF.Text;
        d.login = txtLogin.Text;
        d.cargoFuncionario = txtCargo.Text;
        d.ramal1 = txtRamal.Text;
        d.ramalFuncionario = txtRamal_2.Text;
        d.lotacao = txtLotacao.Text;
        d.dtSolicitacao = DateTime.Now;
        d.NomeSolicitante_Coordenador = txtSolicitante.Text;
        d.eMail = emailCoordenador.Text;
        d.Login_Solicitante = VariaveisGlobais.login;
        d.EmpresaFuncionario = "HSPM";
        bool Result = SolicitaAcessoDAO.GravaDadosSolicitacao(d);
        labelIdChamado.Text = Convert.ToString(SolicitaAcessoDAO.pegaID_BancoDeDados(d.dtSolicitacao, d.RF_Funcionario));


        if (Result == false)
        {
            SolicitaAcessoDAO.GravaSolicitacoes_setores(Convert.ToInt32(labelIdChamado.Text));
            //  ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Solicitação Gravada com suecesso!');", true);
            LabelJaExiste.Text = "NAO";
            string answer = "SOLICITAÇÃO GRAVADA COM SUCESSO!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                        "alert('" + answer + "'); window.location.href='Solicitar.aspx';", true);

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
        rfCordenador.Text = lista.RF_Coordenador.Substring(0, 7);
    }

    [WebMethod]
    public static List<object> GetClientes(string prefixo)
    {
        List<object> clientes = new List<object>();
        string connectionString = ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT TOP 15 rf, nome, setor, v FROM [SolicitaAcesso].[dbo].[FuncionariosHSPM] WHERE [nome] LIKE '%' + @Texto + '%' ORDER BY nome";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Texto", prefixo);
                conn.Open();

                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        clientes.Add(new
                        {
                            RF = sdr["rf"].ToString(),
                            Nome = sdr["nome"].ToString(),
                            Setor = sdr["setor"].ToString(),
                            V = sdr["v"].ToString()
                        });
                    }
                }               
                conn.Close();
            }
        }
        return clientes;
        //limpaNome();
    }

    //public static void limpaNome()
    //{
    //    txtNomeFuncionario.Text = "";
    //}

    

    //[WebMethod]
    //public static string[] GetClientes(string prefixo)
    //{
    //    List<string> clientes = new List<string>();
    //    string connectionString = ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ConnectionString;

    //    using (SqlConnection conn = new SqlConnection(connectionString))
    //    {
    //       string query = "SELECT TOP 15 CONCAT('RF ',rf, ' ','V-', v, ' Nome: ',nome, ' ','Setor: ', setor) as nome1 FROM [SolicitaAcesso].[dbo].[FuncionariosHSPM] WHERE [nome] LIKE '%' + @Texto + '%'order by nome";
    //      //  string query = "SELECT TOP 15 nome FROM [SolicitaAcesso].[dbo].[FuncionariosHSPM] WHERE [nome] LIKE '%' + @Texto + '%'order by nome";

    //        using (SqlCommand cmd = new SqlCommand(query, conn))
    //        {
    //            cmd.Parameters.AddWithValue("@Texto", prefixo);
    //            conn.Open();

    //            using (SqlDataReader sdr = cmd.ExecuteReader())
    //            {
    //                while (sdr.Read())
    //                {
    //                    clientes.Add(sdr["nome1"].ToString());
    //                }
    //            }
    //            conn.Close();
    //        }
    //    }

    //    return clientes.ToArray();
    //}

}
