using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MinhasSolicitacoes : System.Web.UI.Page
{
    public static class VariaveisGlobais
    {
        public static string login { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
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
        if (!this.IsPostBack)
        {
            VariaveisGlobais.login = Session["login"] as string;
            //LabelExtratoChamado.Text = "";
            pegaNomeLoginUsuario.Text = Session["nomeUsuario"] as string;
            verificaSeTemSolicitacao(VariaveisGlobais.login);
        }
        // Deslogar após 20 minutos
        Response.AppendHeader("Refresh",
        //Session TimeOut é em minutos e o Refresh e segundos, por isso o Session.Timeout * 60 JUNIOR>> 1 vale 20 segundos 3 vale 1 Minuto
        String.Concat((Session.Timeout * 60),
        //Página para onde o usuário será redirecionado
        ";URL=../login.aspx"));
    }

    private void verificaSeTemSolicitacao(string text)
    {
        bool existe = SolicitaAcessoDAO.boolVerificaMinhasSolicitacoesVisualizar(text);

        if (existe == true)
        {
            carregaGrid();
        }
        else
        {
            string answer = "Voce não tem nenhuma solicitação para exibir!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                        "alert('" + answer + "'); window.location.href='PaginaInicial.aspx';", true);
        }
    }

    private void carregaGrid()
    {
        //DadosSolicitacoesSetores D = new DadosSolicitacoesSetores();
        var lista = new List<DadosSolicitacoesSetores>();
        lista = SolicitaAcessoDAO.MostraMinhasSolicitacoesVisualizar(VariaveisGlobais.login);
        GridViewMinhasSolicitacoes.DataSource = lista;
        GridViewMinhasSolicitacoes.DataBind();
        LabelNomeSolicitante.Text = lista[0].lotacao;
    }
       
    protected void grdSolicitacoesExibe_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName== "VisualizarSolicitacao")
        {
            int id = Convert.ToInt32(GridViewMinhasSolicitacoes.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
            Response.Redirect("~/aberto/VisualizarSolicitacoes.aspx?IdChamado=" + id);
        }
        else if (e.CommandName == "ExcluirPermissao")
        {
            int id = Convert.ToInt32(GridViewMinhasSolicitacoes.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
            Response.Redirect("~/aberto/ExcluirPermissoes.aspx?IdChamado=" + id);
        }

        
    }
}