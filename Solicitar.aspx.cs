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

    protected void btnCadastrar_Click(object sender, EventArgs e)
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
        }
        else if (LabelJaExiste.Text == "SIM")
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Já existe Solicitação pedente para esse Funcionario, Espere a Informatica dar baixa em todos os Itens da Solicitação que está ativa ou Ligue 8123 ou 8124 e verifique a Situação!');", true);
        }

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
        SolicitaAcessoDAO.GravaSolicitacoes_setores_Update(Convert.ToInt32(labelIdChamado.Text), "Sei");

    }

    private void cadastrarOSmanutencao()
    {
        DadosOsManutencao d = new DadosOsManutencao();
        d.id_chamado_OSmanutencao = Convert.ToInt32(labelIdChamado.Text);
        d.N_centro_custos = txtCentroDeCustoOS_Manutencao.Text;
        d.cpf_manutencao = txtCpfOS_Manutencao.Text;    
       
        d.status_os_manutencao = "S";
        SolicitaAcessoDAO.GravaDadosOSmanutencao(d);
        SolicitaAcessoDAO.GravaSolicitacoes_setores_Update(Convert.ToInt32(labelIdChamado.Text), "OS_manutencao");

    }

    private void cadastrarGrafica()
    {
        DadosGrafica d = new DadosGrafica();
        d.id_chamado_grafica= Convert.ToInt32(labelIdChamado.Text);
        d.N_centro_custo_grafica = txtNcentroDeCustoGrafica.Text;
        d.cpf_grafica = txtCPFgrafica.Text;
        d.cota_grafica = RblCota.SelectedValue;
        d.status_grafica = "S";
        for (int i = 0; i < CkbListGraficaSetor.Items.Count; i++)
        {
            if (CkbListGraficaSetor.Items[i].Selected)
            {

                d.setor_solicitado_Grafica += " ( " +CkbListGraficaSetor.Items[i].Text + " ) ";

            }
        }

        SolicitaAcessoDAO.GravaDadosGrafica(d);
        SolicitaAcessoDAO.GravaSolicitacoes_setores_Update(Convert.ToInt32(labelIdChamado.Text), "Grafica");

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
        SolicitaAcessoDAO.GravaSolicitacoes_setores_Update(Convert.ToInt32(labelIdChamado.Text), "Simproc");


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
        SolicitaAcessoDAO.GravaSolicitacoes_setores_Update(Convert.ToInt32(labelIdChamado.Text), "SGH");

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
        
        SolicitaAcessoDAO.GravaSolicitacoes_setores_Update(Convert.ToInt32(labelIdChamado.Text), "RedeCorporativa");
    
  
}

    private void cadastrarDadosDoSolicitante()
    {
        DadosSolicitacao d = new DadosSolicitacao();
        d.NomeFuncionario = txtNomeFuncionario.Text;
        d.RF_Funcionario = Convert.ToInt32(txtRF.Text);
        d.login = txtLogin.Text;
        d.cargoFuncionario = txtCargo.Text;
        d.ramal1 = txtRamal.Text + " / " + txtRamal_2.Text;
        d.lotacao = txtLotacao.Text;
        d.dtSolicitacao = DateTime.Now;
        d.NomeSolicitante_Coordenador = txtSolicitante.Text;
        d.eMail = emailCoordenador.Text;

        bool Result = SolicitaAcessoDAO.GravaDadosSolicitacao(d);
        labelIdChamado.Text = Convert.ToString(SolicitaAcessoDAO.pegaID_BancoDeDados(d.dtSolicitacao, d.RF_Funcionario));

       
  

        if (Result == false)
        {
            SolicitaAcessoDAO.GravaSolicitacoes_setores(Convert.ToInt32(labelIdChamado.Text));
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
        txtRamal_2.Text = lista.ramal2.ToString();
        txtLotacao.Text = lista.setorCoordenador;
        txtSolicitante.Text = lista.NomeCoordenador;
        emailCoordenador.Text = lista.eMail;
    }
  
}
