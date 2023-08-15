using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SolicitaAcessoDAO
/// </summary>
/// 
public class SolicitaAcessoDAO
{

    public static int pegaID_BancoDeDados(DateTime dt, int rf)
    {
        // string a = DateTime.Now.ToString();
        //// string xx = String.Join("", System.Text.RegularExpressions.Regex.Split(a, @"[^\d]"));
        // Int64 idChamadoDtHrs = Convert.ToInt64(String.Join("", System.Text.RegularExpressions.Regex.Split(a, @"[^\d]")));
        int idChamadoDtHrs = 0;
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                SqlCommand comm = com.CreateCommand();
                //string strQuery = @"select MAX(id_chamado) FROM [SolicitaAcesso].[dbo].[Solicitante_Dados]";
                string strQuery = @"select id_chamado   FROM [SolicitaAcesso].[dbo].[Solicitante_Dados]
	where CONVERT(date,dataSolicitacao,103) ='" + dt + "' and rf =" + rf + "";
                comm.CommandText = strQuery;
                com.Open();
                SqlDataReader dr1 = comm.ExecuteReader();
                while (dr1.Read())
                {
                    idChamadoDtHrs = dr1.GetInt32(0);
                }
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
            return idChamadoDtHrs;
        }

    }

    public static void GravaDadosCoordenador(DadosCoordenador Dados)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"INSERT INTO [dbo].[Coordenador_Dados]
           ([nome_Coordenador]
           ,[rf_Coordenador]
           ,[login_Coordenador]
           ,[e_mail_Coordenador]
           ,[ramal_Coordenador]
           ,[ramal_2_Coordenador]
           ,[setor_Coordenador])"
     + " VALUES (@nome_Coordenador,@rf_Coordenador,@login_Coordenador,@e_mail_Coordenador,@ramal_Coordenador,@ramal_2_Coordenador,@setor_Coordenador)";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@nome_Coordenador", SqlDbType.VarChar).Value = Dados.NomeCoordenador;
                commd.Parameters.Add("@rf_Coordenador", SqlDbType.Int).Value = Dados.RF_Coordenador;
                commd.Parameters.Add("@login_Coordenador", SqlDbType.VarChar).Value = Dados.loginCoordenador;
                commd.Parameters.Add("@e_mail_Coordenador", SqlDbType.VarChar).Value = Dados.eMail;
                commd.Parameters.Add("@ramal_Coordenador", SqlDbType.VarChar).Value = Dados.ramal1;
                commd.Parameters.Add("@ramal_2_Coordenador", SqlDbType.VarChar).Value = Dados.ramal2;
                commd.Parameters.Add("@setor_Coordenador", SqlDbType.VarChar).Value = Dados.setorCoordenador;
                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
        }
    }

    public static List<DadosCoordenador> GetListaCoordenadoresCadastrados()
    {
        var lista = new List<DadosCoordenador>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();

            string sqlConsulta = @"SELECT * FROM [SolicitaAcesso].[dbo].[Coordenador_Dados] order by nome_Coordenador";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    DadosCoordenador d = new DadosCoordenador();
                    d.id = dr1.GetInt32(0);
                    d.NomeCoordenador = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.RF_Coordenador = dr1.GetInt32(2);
                    d.loginCoordenador = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.eMail = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    d.ramal1 = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    d.ramal2 = dr1.IsDBNull(6) ? "" : dr1.GetString(6);
                    d.setorCoordenador = dr1.IsDBNull(7) ? "" : dr1.GetString(7);
                    lista.Add(d);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return lista;
        }
    }

    public static void ExcluiCadastroCoordenador(int id)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))

        {
            string strquerySelect;
            strquerySelect = @"DELETE FROM [dbo].[Coordenador_Dados] WHERE id=" + id + "";
            SqlCommand commd = new SqlCommand(strquerySelect, com);
            com.Open();
            SqlDataReader dr = commd.ExecuteReader();
            com.Close();
        }
    }

    public static DadosCoordenador GetDadosDosCoordenadoresPaginaSolicita(string login)
    {
        DadosCoordenador d = new DadosCoordenador();
        //var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();

            string sqlConsulta = @"SELECT [id],[nome_Coordenador],[ramal_Coordenador],[ramal_2_Coordenador],[setor_Coordenador],[e_mail_Coordenador] 
     FROM [SolicitaAcesso].[dbo].[Coordenador_Dados] where login_Coordenador='" + login + "'";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.id = dr1.GetInt32(0);
                    d.NomeCoordenador = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.ramal1 = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    d.ramal2 = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.setorCoordenador = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    d.eMail= dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return d;
    }

    public static bool GravaDadosSolicitacao(DadosSolicitacao Dados)
    {        
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            bool existeSolicitacao = GetSolicitacao(Dados.RF_Funcionario);
            Dados.msg_JaTemSolicitacaoAberta = existeSolicitacao;

            if (existeSolicitacao == false)
            {
                try
                {
                    string strQuery = @"INSERT INTO [dbo].[Solicitante_Dados]
           ([nome_funcionario]
           ,[rf]
           ,[login]
           ,[cargo]
           ,[ramal]
           ,[lotacao]
           ,[dataSolicitacao]
           ,[solicitante]           
           ,[ativa_Solicitacao]
           ,[email_coordenador])"
         + " VALUES (@nome_funcionario,@rf,@login,@cargo,@ramal,@lotacao,@dataSolicitacao,@solicitante,@ativa_Solicitacao,@email_coordenador)";

                    SqlCommand commd = new SqlCommand(strQuery, com);
                    commd.Parameters.Add("@nome_funcionario", SqlDbType.VarChar).Value = Dados.NomeFuncionario;
                    commd.Parameters.Add("@rf", SqlDbType.Int).Value = Dados.RF_Funcionario;
                    commd.Parameters.Add("@login", SqlDbType.VarChar).Value = Dados.login;
                    commd.Parameters.Add("@cargo", SqlDbType.VarChar).Value = Dados.cargoFuncionario;
                    commd.Parameters.Add("@ramal", SqlDbType.VarChar).Value = Dados.ramal1;
                    commd.Parameters.Add("@lotacao", SqlDbType.VarChar).Value = Dados.lotacao;
                    commd.Parameters.Add("@dataSolicitacao", SqlDbType.DateTime).Value = Dados.dtSolicitacao;
                    commd.Parameters.Add("@solicitante", SqlDbType.VarChar).Value = Dados.NomeSolicitante_Coordenador;
                    commd.Parameters.Add("@ativa_Solicitacao", SqlDbType.VarChar).Value = Dados.eMail = "S";
                    commd.Parameters.Add("@email_coordenador", SqlDbType.VarChar).Value = Dados.eMail = Dados.eMail;
                    
                    commd.CommandText = strQuery;
                    com.Open();
                    commd.ExecuteNonQuery();
                    com.Close();
                }
                catch (Exception ex)
                {
                    string erro = ex.Message;
                }                        
                return Dados.msg_JaTemSolicitacaoAberta;
            }
            else
            {
                return Dados.msg_JaTemSolicitacaoAberta;
            }            
        }
    }

    private static bool GetSolicitacao(int rF_Funcionario)
    {
        bool valido;
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))

        {
            string strquerySelect;
            strquerySelect = @"SELECT * FROM [SolicitaAcesso].[dbo].[Solicitante_Dados]
  where rf=" + rF_Funcionario + " and ativa_Solicitacao ='S'";

            SqlCommand commd = new SqlCommand(strquerySelect, com);
            com.Open();
            SqlDataReader dr = commd.ExecuteReader();

            valido = dr.Read();
            com.Close();
        }

        return valido;
    }

    public static void GravaDadosRedeCorporativa(DadosRedeCoorporativa Dados)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"INSERT INTO [dbo].[RedeCorporativa]
           ([id_chamado_rede_corporativa]
           ,[redeCorperativa]
           ,[emailCorporativo]
           ,[caixaDepartamental]
           ,[pastaRede]
           ,[pastaEspecifica]
           ,[status_RedeCorporativa])"
     + " VALUES (@id_chamado_rede_corporativa,@redeCorperativa,@emailCorporativo,@caixaDepartamental,@pastaRede,@pastaEspecifica,@status_RedeCorporativa)";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@id_chamado_rede_corporativa", SqlDbType.Int).Value = Dados.id_chamado_rede_corporativa;
                commd.Parameters.Add("@redeCorperativa", SqlDbType.VarChar).Value = Dados.redeCorporativa;
                commd.Parameters.Add("@emailCorporativo", SqlDbType.VarChar).Value = Dados.emailCorporativo;
                commd.Parameters.Add("@caixaDepartamental", SqlDbType.VarChar).Value = Dados.caixaDepartamental;
                commd.Parameters.Add("@pastaRede", SqlDbType.VarChar).Value = Dados.pastaDeRede;
                commd.Parameters.Add("@pastaEspecifica", SqlDbType.VarChar).Value = Dados.PastaEspecifica;
                commd.Parameters.Add("@status_RedeCorporativa", SqlDbType.VarChar).Value = Dados.status_redeCoorporativa;
                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
        }
    }

    public static void GravaDadosSGH(DadosSGH Dados)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"INSERT INTO [dbo].[Sgh]
           ([id_chamado_sgh]
           ,[Amb]
           ,[Amb_Desc]
           ,[CenCir]
           ,[CenCir_Desc]
           ,[Internacao]
           ,[Internacao_Desc]
           ,[Ps]
           ,[Ps_Desc]
           ,[status_Sgh])"
     + " VALUES (@id_chamado_sgh,@Amb,@Amb_Desc,@CenCir,@CenCir_Desc,@Internacao,@Internacao_Desc,@Ps,@Ps_Desc,@status_Sgh)";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@id_chamado_sgh", SqlDbType.Int).Value = Dados.id_chamado_SGH;
                commd.Parameters.Add("@Amb", SqlDbType.VarChar).Value = Dados.Amb;
                commd.Parameters.Add("@Amb_Desc", SqlDbType.VarChar).Value = Dados.Amb_Desc;
                commd.Parameters.Add("@CenCir", SqlDbType.VarChar).Value = Dados.CenCir;
                commd.Parameters.Add("@CenCir_Desc", SqlDbType.VarChar).Value = Dados.CenCir_Desc;
                commd.Parameters.Add("@Internacao", SqlDbType.VarChar).Value = Dados.Internacao;
                commd.Parameters.Add("@Internacao_Desc", SqlDbType.VarChar).Value = Dados.Internacao_Desc;
                commd.Parameters.Add("@Ps", SqlDbType.VarChar).Value = Dados.PS;
                commd.Parameters.Add("@Ps_Desc", SqlDbType.VarChar).Value = Dados.PS_Desc;
                commd.Parameters.Add("@status_Sgh", SqlDbType.VarChar).Value = Dados.status_SGH;
                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
        }
    }

    public static void GravaDadosSImproc(DadosSimproc Dados)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"INSERT INTO [dbo].[Simproc]
           ([id_chamdo_simproc]
           ,[cod_Unidade]
           ,[cpf_simproc]
           ,[rg_simproc]
           ,[dataAdmissao]
           ,[status_Simproc])"
     + " VALUES (@id_chamdo_simproc,@cod_Unidade,@cpf_simproc,@rg_simproc,@dataAdmissao,@status_Simproc)";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@id_chamdo_simproc", SqlDbType.Int).Value = Dados.id_chamado_Simproc;
                commd.Parameters.Add("@cod_Unidade", SqlDbType.VarChar).Value = Dados.CodigoUnidade_Simproc;
                commd.Parameters.Add("@cpf_simproc", SqlDbType.VarChar).Value = Dados.cpf_simproc;
                commd.Parameters.Add("@rg_simproc", SqlDbType.VarChar).Value = Dados.rg_simproc;
                commd.Parameters.Add("@dataAdmissao", SqlDbType.VarChar).Value = Dados.dataAdmissao;
                commd.Parameters.Add("@status_Simproc", SqlDbType.VarChar).Value = Dados.status_Simproc;
               
                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
        }
    }

    public static void GravaDadosGrafica(DadosGrafica Dados)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"INSERT INTO [dbo].[Grafica]
           ([id_chamado_grafica]           
           ,[setor_solicitado_Grafica]
           ,[N_centro_custo_grafica]
           ,[cpf_grafica]
           ,[cota_grafica]
           ,[status_grafica])    
             VALUES (@id_chamado_grafica,@setor_solicitado_Grafica,@N_centro_custo_grafica,@cpf_grafica,@cota_grafica,@status_grafica)";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@id_chamado_grafica", SqlDbType.Int).Value = Dados.id_chamado_grafica;
                commd.Parameters.Add("@setor_solicitado_Grafica", SqlDbType.VarChar).Value = Dados.setor_solicitado_Grafica;
                commd.Parameters.Add("@N_centro_custo_grafica", SqlDbType.VarChar).Value = Dados.N_centro_custo_grafica;
                commd.Parameters.Add("@cpf_grafica", SqlDbType.VarChar).Value = Dados.cpf_grafica;
                commd.Parameters.Add("@cota_grafica", SqlDbType.VarChar).Value = Dados.cota_grafica;
                commd.Parameters.Add("@status_grafica", SqlDbType.VarChar).Value = Dados.status_grafica;

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
        }
    }

    public static void GravaDadosOSmanutencao(DadosOsManutencao Dados)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"INSERT INTO [dbo].[OsManutencao]
           ([id_chamado_manutencao]       
           ,[N_centro_custos]
           ,[cpf_manutencao]
           ,[status_os_manutencao])
           VALUES (@id_chamado_manutencao,@N_centro_custos,@cpf_manutencao,@status_os_manutencao)";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@id_chamado_manutencao", SqlDbType.Int).Value = Dados.id_chamado_OSmanutencao;
                commd.Parameters.Add("@N_centro_custos", SqlDbType.VarChar).Value = Dados.N_centro_custos;
                commd.Parameters.Add("@cpf_manutencao", SqlDbType.VarChar).Value = Dados.cpf_manutencao;
                commd.Parameters.Add("@status_os_manutencao", SqlDbType.VarChar).Value = Dados.status_os_manutencao;               

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
        }
    }

    public static void GravaDadosSei(DadosSei Dados)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"INSERT INTO [dbo].[Sei]
           ([id_chamado_Sei]
           ,[siglasUnidades1]
           ,[siglasUnidades2]
           ,[siglasUnidades3]
           ,[siglasUnidades4]
           ,[status_Sei])
           VALUES (@id_chamado_Sei,@siglasUnidades1,@siglasUnidades2,@siglasUnidades3,@siglasUnidades4,@status_Sei)";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@id_chamado_Sei", SqlDbType.Int).Value = Dados.id_chamado_Sei;
                commd.Parameters.Add("@siglasUnidades1", SqlDbType.VarChar).Value = Dados.siglasUnidades1;
                commd.Parameters.Add("@siglasUnidades2", SqlDbType.VarChar).Value = Dados.siglasUnidades2;
                commd.Parameters.Add("@siglasUnidades3", SqlDbType.VarChar).Value = Dados.siglasUnidades3;
                commd.Parameters.Add("@siglasUnidades4", SqlDbType.VarChar).Value = Dados.siglasUnidades4;
                commd.Parameters.Add("@status_Sei", SqlDbType.VarChar).Value = Dados.status_Sei;


                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
        }
    }

    public static void GravaSolicitacoes_setores( int Id_chamado)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"INSERT INTO [dbo].[Setores_Solicitados]
           ([Id_Solicitacoes_setores]) VALUES (@Id_Solicitacoes_setores)";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@Id_Solicitacoes_setores", SqlDbType.Int).Value = Id_chamado;
                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
        }
    }

    public static void GravaSolicitacoes_setores_Update(int Id_chamado, string nomeCampo)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"UPDATE [dbo].[Setores_Solicitados]
   SET [" + nomeCampo + "]='S' WHERE Id_Solicitacoes_setores=" + Id_chamado + "";

                SqlCommand commd = new SqlCommand(strQuery, com);                               
                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
        }
    }

    public static List<DadosSolicitacoesSetores> MostraSolicitacoesNaTelaStatus()
    {

        var lista = new List<DadosSolicitacoesSetores>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))

        {
            try
            {
                string strQuery = @"SELECT [id_chamado],[nome_funcionario],[rf],[login],[cargo],[ramal],[dataSolicitacao]
      ,[RedeCorporativa],[SGH],[Simproc],[Grafica],[OS_manutencao],[Sei]  FROM [SolicitaAcesso].[dbo].[Vw_MostraSetoresSolicitados]";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                while (dr.Read())
                {
                    DadosSolicitacoesSetores l = new DadosSolicitacoesSetores();

                    l.id_Solicitacao = dr.GetInt32(0);
                    l.Nome_funcionario = dr.IsDBNull(1) ? null : dr.GetString(1);
                    l.rf_funcionario = dr.GetInt32(2);
                    l.login_do_funcionario = dr.IsDBNull(3) ? null : dr.GetString(3);
                    l.Cargo_Funcionario = dr.IsDBNull(4) ? null : dr.GetString(4);
                    l.Ramal = dr.IsDBNull(5) ? null : dr.GetString(5);
                    DateTime dt = dr.GetDateTime(6);
                    l.dataSolicitacao = dt.ToShortDateString();
                    l.RedeCorporativa = dr.IsDBNull(7) ? null : dr.GetString(7);
                    l.SGH = dr.IsDBNull(8) ? null : dr.GetString(8);
                    l.Simproc = dr.IsDBNull(9) ? null : dr.GetString(9);
                    l.Grafica = dr.IsDBNull(10) ? null : dr.GetString(10);
                    l.OS_manutencao = dr.IsDBNull(11) ? null : dr.GetString(11);
                    l.Sei = dr.IsDBNull(12) ? null : dr.GetString(12);
                    
                    if (l.RedeCorporativa == "S")
                    {
                        l.SetoresConcatenados = "( Rede corporativa ) ";
                    }
                    if (l.SGH == "S")
                    {
                        l.SetoresConcatenados += "( SGH ) ";
                    }
                    if (l.Simproc == "S")
                    {
                        l.SetoresConcatenados += "( Simproc ) ";
                    }
                    if (l.Grafica == "S")
                    {
                        l.SetoresConcatenados += "( Grafica ) ";
                    }
                    if (l.OS_manutencao == "S")
                    {
                        l.SetoresConcatenados += "( OS manutenção ) ";
                    }
                    if (l.Sei == "S")
                    {
                        l.SetoresConcatenados += "( Sei ) ";
                    }


                    lista.Add(l);
                }
                com.Close();

            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                throw;
            }
            return lista;

        }


    }

    public static DadosSolicitacao GetDadosDaSolitacaoParaAtender(int idChamado)
    {        
        DadosSolicitacao d = new DadosSolicitacao();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();
            string sqlConsulta = @"SELECT *
  FROM [SolicitaAcesso].[dbo].[Solicitante_Dados] where id_chamado="+ idChamado + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    
                    d.id_chamado_ = dr1.GetInt32(0);
                    d.NomeFuncionario = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.RF_Funcionario = dr1.GetInt32(2);
                    d.login = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.cargoFuncionario = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    d.ramal1 = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    d.lotacao = dr1.IsDBNull(6) ? "" : dr1.GetString(6);
                    d.dtSolicitacao = dr1.GetDateTime(7);
                    d.NomeSolicitante_Coordenador = dr1.IsDBNull(8) ? "" : dr1.GetString(8);                   
                    d.eMail = dr1.IsDBNull(10) ? "" : dr1.GetString(10);                
                   
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return d;
        }
    }

    //
    public static DadosSetoresSolicitados_S GetSetoresCom_S(int idChamado)
    {
        DadosSetoresSolicitados_S d = new DadosSetoresSolicitados_S();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();
            string sqlConsulta = @"SELECT [RedeCorporativa],[SGH],[Simproc],[Grafica],[OS_manutencao],[Sei]
  FROM [SolicitaAcesso].[dbo].[Vw_MostraSetoresSolicitados] where id_chamado=" + idChamado + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.RedeCorporativa = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    d.SGH = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.Simproc = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    d.Grafica = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.OS_manutencao = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    d.Sei = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return d;
        }
    }
}