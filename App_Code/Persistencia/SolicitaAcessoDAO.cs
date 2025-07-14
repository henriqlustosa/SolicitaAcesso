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

    public static int pegaID_BancoDeDados(DateTime dt, string rf)
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
	where CONVERT(date,dataSolicitacao,103) ='" + dt + "' and rf ='" + rf + "'";
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

    //public static void GravaDadosCoordenador(DadosCoordenador Dados) // Junior 17/06/2025
    //{
    //    using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
    //    {
    //        try
    //        {
    //            string strQuery = @"INSERT INTO [dbo].[Coordenador_Dados]
    //       ([nome_Coordenador]
    //       ,[rf_Coordenador]
    //       ,[login_Coordenador]
    //       ,[e_mail_Coordenador]
    //       ,[ramal_Coordenador]          
    //       ,[setor_Coordenador])"
    // + " VALUES (@nome_Coordenador,@rf_Coordenador,@login_Coordenador,@e_mail_Coordenador,@ramal_Coordenador,@setor_Coordenador)";

    //            SqlCommand commd = new SqlCommand(strQuery, com);
    //            commd.Parameters.Add("@nome_Coordenador", SqlDbType.VarChar).Value = Dados.NomeCoordenador;
    //            commd.Parameters.Add("@rf_Coordenador", SqlDbType.VarChar).Value = Dados.RF_Coordenador;
    //            commd.Parameters.Add("@login_Coordenador", SqlDbType.VarChar).Value = Dados.loginCoordenador;
    //            commd.Parameters.Add("@e_mail_Coordenador", SqlDbType.VarChar).Value = Dados.eMail;
    //            commd.Parameters.Add("@ramal_Coordenador", SqlDbType.VarChar).Value = Dados.ramal1;
    //            //commd.Parameters.Add("@ramal_2_Coordenador", SqlDbType.VarChar).Value = Dados.ramal2;
    //            commd.Parameters.Add("@setor_Coordenador", SqlDbType.VarChar).Value = Dados.setorCoordenador;
    //            commd.CommandText = strQuery;
    //            com.Open();
    //            commd.ExecuteNonQuery();
    //            com.Close();
    //        }
    //        catch (Exception ex)
    //        {
    //            string erro = ex.Message;
    //        }



    //    }
    //}

    //public static List<DadosCoordenador> GetListaCoordenadoresCadastrados() // junior 17/05/2025
    //{
    //    var lista = new List<DadosCoordenador>();
    //    using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
    //    {
    //        SqlCommand cmm = com.CreateCommand();

    //        string sqlConsulta = @"SELECT * FROM [SolicitaAcesso].[dbo].[Coordenador_Dados] order by nome_Coordenador";
    //        cmm.CommandText = sqlConsulta;
    //        try
    //        {
    //            com.Open();
    //            SqlDataReader dr1 = cmm.ExecuteReader();
    //            while (dr1.Read())
    //            {
    //                DadosCoordenador d = new DadosCoordenador();
    //                d.id = dr1.GetInt32(0);
    //                d.NomeCoordenador = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
    //                d.RF_Coordenador = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
    //                d.loginCoordenador = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
    //                d.eMail = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
    //                d.ramal1 = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
    //                //d.ramal2 = dr1.IsDBNull(6) ? "" : dr1.GetString(6);
    //                d.setorCoordenador = dr1.IsDBNull(6) ? "" : dr1.GetString(6);
    //                lista.Add(d);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string error = ex.Message;
    //        }
    //        return lista;
    //    }
    //}

    //public static void ExcluiCadastroCoordenador(int id) // junior 17/06/2025
    //{
    //    using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))

    //    {
    //        string strquerySelect;
    //        strquerySelect = @"DELETE FROM [dbo].[Coordenador_Dados] WHERE id=" + id + "";
    //        SqlCommand commd = new SqlCommand(strquerySelect, com);
    //        com.Open();
    //        SqlDataReader dr = commd.ExecuteReader();
    //        com.Close();
    //    }
    //}

    public static DadosCoordenador GetDadosDosCoordenadoresPaginaSolicita(string login)
    {
        DadosCoordenador d = new DadosCoordenador();
        //var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();

            string sqlConsulta = @"SELECT [Id], [NomeCompleto], [ramal_Coordenador], [setor_Coordenador], [Email], [rf_Coordenador]
    FROM [SolicitaAcesso].[dbo].[Usuarios] where LoginRede='" + login + "'";
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
                    //d.ramal2 = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.setorCoordenador = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.eMail = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    d.RF_Coordenador = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
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
            bool existeSolicitacao;
            string rfFuncionario = GetRfSolicitante(Dados.Login_Solicitante);

            int qtoDeSolicitacao = (GetSolicitacao(Dados.RF_Funcionario));
            if (qtoDeSolicitacao >= 5)
            {
                existeSolicitacao = true;
            }
            else
            {
                existeSolicitacao = false;
            }

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
           ,[email_coordenador]
           ,[ramalFuncionario]
           ,[rfSolicitante]
           ,[empresa])"
         + " VALUES (@nome_funcionario,@rf,@login,@cargo,@ramal,@lotacao,@dataSolicitacao,@solicitante,@ativa_Solicitacao,@email_coordenador,@ramalFuncionario,@rfSolicitante,@empresa)";

                    SqlCommand commd = new SqlCommand(strQuery, com);
                    commd.Parameters.Add("@nome_funcionario", SqlDbType.VarChar).Value = Dados.NomeFuncionario;
                    commd.Parameters.Add("@rf", SqlDbType.VarChar).Value = Dados.RF_Funcionario;
                    commd.Parameters.Add("@login", SqlDbType.VarChar).Value = Dados.login;
                    commd.Parameters.Add("@cargo", SqlDbType.VarChar).Value = Dados.cargoFuncionario;
                    commd.Parameters.Add("@ramal", SqlDbType.VarChar).Value = Dados.ramal1;
                    commd.Parameters.Add("@lotacao", SqlDbType.VarChar).Value = Dados.lotacao;
                    commd.Parameters.Add("@dataSolicitacao", SqlDbType.DateTime).Value = Dados.dtSolicitacao;
                    commd.Parameters.Add("@solicitante", SqlDbType.VarChar).Value = Dados.NomeSolicitante_Coordenador;
                    commd.Parameters.Add("@ativa_Solicitacao", SqlDbType.VarChar).Value = "S";
                    commd.Parameters.Add("@email_coordenador", SqlDbType.VarChar).Value = Dados.eMail;
                    commd.Parameters.Add("@ramalFuncionario", SqlDbType.VarChar).Value = Dados.ramalFuncionario;
                    commd.Parameters.Add("@rfSolicitante", SqlDbType.VarChar).Value = rfFuncionario;
                    commd.Parameters.Add("@empresa", SqlDbType.VarChar).Value = Dados.EmpresaFuncionario;
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

    private static string GetRfSolicitante(string login_Solicitante)
    {
        string rfSolicitante = "0";
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))

        {
            string strquerySelect;
            strquerySelect = @"SELECT [rf_Coordenador] FROM [SolicitaAcesso].[dbo].[Usuarios]
  where LoginRede='" + login_Solicitante + "'";

            SqlCommand commd = new SqlCommand(strquerySelect, com);
            com.Open();
            SqlDataReader dr = commd.ExecuteReader();

            if (dr.Read())
            {
                rfSolicitante = dr.GetString(0);
            }
            com.Close();
        }
        return rfSolicitante;
    }
    private static string GetRfSolicitanteSetor(string login_Solicitante)
    {
        string setorCoordenador = "0";
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))

        {
            string strquerySelect;
            strquerySelect = @"SELECT  [setor_Coordenador] FROM [SolicitaAcesso].[dbo].[Usuarios]
where LoginRede='" + login_Solicitante + "'"; //Retorna o setor do Coordenador "setor_Coordenador"

            SqlCommand commd = new SqlCommand(strquerySelect, com);
            com.Open();
            SqlDataReader dr = commd.ExecuteReader();

            if (dr.Read())

            {
                setorCoordenador = dr.GetString(0);
            }
            com.Close();
        }
        return setorCoordenador;
    }

    private static int GetSolicitacao(string rF_Funcionario)
    {
        int TotalChamados = 0;
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))

        {
            string strquerySelect;
            strquerySelect = @"SELECT COUNT(rf) FROM [SolicitaAcesso].[dbo].[Solicitante_Dados]
  where rf='" + rF_Funcionario + "' and ativa_Solicitacao ='S'";

            SqlCommand commd = new SqlCommand(strquerySelect, com);
            com.Open();
            SqlDataReader dr = commd.ExecuteReader();
            while (dr.Read())
            {
                TotalChamados = dr.GetInt32(0);
            }

            com.Close();
        }
        return TotalChamados;
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
           ,[caixaDepartamental_descricao]
           ,[pastaRede]
           ,[pastaEspecifica]
           ,[status_RedeCorporativa]
           ,[redeCorperativaNovoDerp]
           ,[redeCorperativaNovoPasta]
           ,[caixaDepartamental_Nova_descricao]
           ,[pastaRedeNova])"
     + " VALUES (@id_chamado_rede_corporativa,@redeCorperativa,@emailCorporativo,@caixaDepartamental,@caixaDepartamental_descricao,@pastaRede,@pastaEspecifica,@status_RedeCorporativa,@redeCorperativaNovoDerp,@redeCorperativaNovoPasta,@caixaDepartamental_Nova_descricao,@pastaRedeNova)";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@id_chamado_rede_corporativa", SqlDbType.Int).Value = Dados.id_chamado_rede_corporativa;
                commd.Parameters.Add("@redeCorperativa", SqlDbType.VarChar).Value = Dados.redeCorporativa;
                commd.Parameters.Add("@emailCorporativo", SqlDbType.VarChar).Value = Dados.emailCorporativo;
                commd.Parameters.Add("@caixaDepartamental", SqlDbType.VarChar).Value = Dados.caixaDepartamental;
                commd.Parameters.Add("@caixaDepartamental_descricao", SqlDbType.VarChar).Value = Dados.caixaDepartamental_Descricao;
                commd.Parameters.Add("@pastaRede", SqlDbType.VarChar).Value = Dados.pastaDeRede;
                commd.Parameters.Add("@pastaEspecifica", SqlDbType.VarChar).Value = Dados.PastaEspecifica;
                commd.Parameters.Add("@status_RedeCorporativa", SqlDbType.VarChar).Value = Dados.status_redeCoorporativa;
                commd.Parameters.Add("@redeCorperativaNovoDerp", SqlDbType.VarChar).Value = Dados.redeCorperativaNovoDerp;
                commd.Parameters.Add("@redeCorperativaNovoPasta", SqlDbType.VarChar).Value = Dados.redeCorperativaNovoPasta;
                commd.Parameters.Add("@caixaDepartamental_Nova_descricao", SqlDbType.VarChar).Value = Dados.caixaDepartamental_Descricao_Nova;
                commd.Parameters.Add("@pastaRedeNova", SqlDbType.VarChar).Value = Dados.pastaDeRedeNova;
                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();


                //             string strQuery2 = @"UPDATE [dbo].[Setores_Solicitados]
                //SET [RedeCorporativa]='S' WHERE Id_Solicitacoes_setores=" + Dados.id_chamado_rede_corporativa + "";

                //             SqlCommand commd2 = new SqlCommand(strQuery2, com);
                //             commd2.CommandText = strQuery2;
                //             com.Open();
                //             commd2.ExecuteNonQuery();
                //             com.Close();

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
           ,[N_centro_custo_grafica]
           ,[N_centro_custo_grafica_antigo]
           ,[cpf_grafica]          
           ,[status_grafica])    
             VALUES (@id_chamado_grafica,@N_centro_custo_grafica,@N_centro_custo_grafica_antigo,@cpf_grafica,@status_grafica)";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@id_chamado_grafica", SqlDbType.Int).Value = Dados.id_chamado_grafica;
                commd.Parameters.Add("@N_centro_custo_grafica", SqlDbType.VarChar).Value = Dados.N_centro_custo_grafica;
                commd.Parameters.Add("@N_centro_custo_grafica_antigo", SqlDbType.VarChar).Value = Dados.N_centro_custo_grafica_antigo;
                commd.Parameters.Add("@cpf_grafica", SqlDbType.VarChar).Value = Dados.cpf_grafica;
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
           ,[N_centro_custos_Novo]
           ,[N_centro_custos_Antigo]
           ,[cpf_manutencao]
           ,[status_os_manutencao])
           VALUES (@id_chamado_manutencao,@N_centro_custos_Novo,@N_centro_custos_Antigo,@cpf_manutencao,@status_os_manutencao)";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@id_chamado_manutencao", SqlDbType.Int).Value = Dados.id_chamado_OSmanutencao;
                commd.Parameters.Add("@N_centro_custos_Novo", SqlDbType.VarChar).Value = Dados.N_centro_custos_novo;
                commd.Parameters.Add("@N_centro_custos_Antigo", SqlDbType.VarChar).Value = Dados.N_centro_custos_antigo;
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

    public static void GravaDadosSigaSaude(DadosSigaSaude Dados)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"INSERT INTO [dbo].[SigaSaude]
           ([id_chamado_siga_saude]
           ,[dtNascSiga]
           ,[nomeDaMaeSiga]
           ,[CRM_siga]
           ,[cpfSiga]
           ,[RG_siga]
           ,[UF_Siga]
           ,[dtEmisaoRG_Siga]
           ,[orgao_RG_Siga]
           ,[nomeDaRuaSiga]
           ,[NumeroDaRuaSiga]
           ,[bairoSiga]
           ,[CepSiga]
           ,[ModuloAcessarSiga]
           ,[ObsSiga]
           ,[status_SigaSaude])
           VALUES (@id_chamado_siga_saude,@dtNascSiga,@nomeDaMaeSiga,@CRM_siga,@cpfSiga,@RG_siga,@UF_Siga,@dtEmisaoRG_Siga
            ,@orgao_RG_Siga,@nomeDaRuaSiga,@NumeroDaRuaSiga,@bairoSiga,@CepSiga,@ModuloAcessarSiga,@ObsSiga,@status_SigaSaude)";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@id_chamado_siga_saude", SqlDbType.Int).Value = Dados.id_chamado_sigaSaude;
                commd.Parameters.Add("@dtNascSiga", SqlDbType.VarChar).Value = Dados.dtNascSiga;
                commd.Parameters.Add("@nomeDaMaeSiga", SqlDbType.VarChar).Value = Dados.nomeDaMaeSiga;
                commd.Parameters.Add("@CRM_siga", SqlDbType.Int).Value = Dados.CRM_siga;
                commd.Parameters.Add("@cpfSiga", SqlDbType.VarChar).Value = Dados.cpfSiga;
                commd.Parameters.Add("@RG_siga", SqlDbType.VarChar).Value = Dados.RG_siga;
                commd.Parameters.Add("@UF_Siga", SqlDbType.VarChar).Value = Dados.UF_Siga;
                commd.Parameters.Add("@dtEmisaoRG_Siga", SqlDbType.VarChar).Value = Dados.dtEmisaoRG_Siga;
                commd.Parameters.Add("@orgao_RG_Siga", SqlDbType.VarChar).Value = Dados.orgao_RG_Siga;
                commd.Parameters.Add("@nomeDaRuaSiga", SqlDbType.VarChar).Value = Dados.nomeDaRuaSiga;
                commd.Parameters.Add("@NumeroDaRuaSiga", SqlDbType.Int).Value = Dados.NumeroDaRuaSiga;
                commd.Parameters.Add("@bairoSiga", SqlDbType.VarChar).Value = Dados.bairoSiga;
                commd.Parameters.Add("@CepSiga", SqlDbType.VarChar).Value = Dados.CepSiga;
                commd.Parameters.Add("@ModuloAcessarSiga", SqlDbType.VarChar).Value = Dados.ModuloAcessarSiga;
                commd.Parameters.Add("@ObsSiga", SqlDbType.VarChar).Value = Dados.ObsSiga;
                commd.Parameters.Add("@status_SigaSaude", SqlDbType.VarChar).Value = Dados.status_SigaSaude;

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

    public static void GravaDadosCompSGH(DadosCompSGH Dados)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"INSERT INTO [dbo].[DadosCompSGH]
           ([Id_Chamado_dadosComp],[dtNasci_dadosComp],[nomeMae_dadosComp],[crm_dadosComp],[cpf_dadosComp],[rg_dadosComp])
           VALUES (@Id_Chamado_dadosComp,@dtNasci_dadosComp,@nomeMae_dadosComp,@crm_dadosComp,@cpf_dadosComp,@rg_dadosComp)";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@Id_Chamado_dadosComp", SqlDbType.Int).Value = Dados.id_chamado_DadosCompl;
                commd.Parameters.Add("@dtNasci_dadosComp", SqlDbType.VarChar).Value = Dados.dtNasci_dadosComp;
                commd.Parameters.Add("@nomeMae_dadosComp", SqlDbType.VarChar).Value = Dados.nomeMae_dadosComp;
                commd.Parameters.Add("@crm_dadosComp", SqlDbType.VarChar).Value = Dados.crm_dadosComp;
                commd.Parameters.Add("@cpf_dadosComp", SqlDbType.VarChar).Value = Dados.cpf_dadosComp;
                commd.Parameters.Add("@rg_dadosComp", SqlDbType.VarChar).Value = Dados.rg_dadosComp;

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

    public static void GravaSolicitacoes_setores(int Id_chamado)
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

    public static void GravaSolicitacoes_setores_Update(int Id_chamado, string nomeCampo, int Mais1Menos1)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"UPDATE [dbo].[Setores_Solicitados]
   SET [" + nomeCampo + "]='S', [TotalSetoresAbriChamado]=" + Mais1Menos1 + "  WHERE Id_Solicitacoes_setores=" + Id_chamado + "";

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

    public static void GravaExtratoInertInicial(int Id_chamado_Extrato, string ExtratoInicial)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"INSERT INTO [dbo].[Extrato_SolicitaAcesso] ([id_chamado_Extrato] ,[extrato_solicitaAcesso])
                                     VALUES (@id_chamado_Extrato,@extrato_solicitaAcesso)";
                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@id_chamado_Extrato", SqlDbType.Int).Value = Id_chamado_Extrato;
                commd.Parameters.Add("@extrato_solicitaAcesso", SqlDbType.VarChar).Value = ExtratoInicial;
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

    public static void GravaExtratoInertInicial_Funcionario(int Id_chamado_Extrato)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"INSERT INTO [dbo].[Extrato_P_func] ([id_N_solicitacao])
     VALUES (@id_N_solicitacao)";
                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@id_N_solicitacao", SqlDbType.Int).Value = Id_chamado_Extrato;
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
    public static void GravaOBS_Solicitacao_Geral(int Id_chamado_OBS, string Obs_Geral)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"INSERT INTO [dbo].[OBS_Solicitacao]
           ([id_N_solicitacao_obs],[Obs_solicitacao])
     VALUES (@id_N_solicitacao_obs,@Obs_solicitacao)";
                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@id_N_solicitacao_obs", SqlDbType.Int).Value = Id_chamado_OBS;
                commd.Parameters.Add("@Obs_solicitacao", SqlDbType.VarChar).Value = Obs_Geral;
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
 //   public static List<DadosSolicitacoesSetores> MostraMinhasSolicitacoes(string Login_Solicitante)
 //   {
 //       string rfFuncionario = GetRfSolicitante(Login_Solicitante);
 //       var lista = new List<DadosSolicitacoesSetores>();
 //       using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))

 //       {
 //           try
 //           {
 //               string strQuery = @"SELECT [nome_Coordenador],[nome_funcionario],[rf],[login],[dataSolicitacao],[Id_Solicitacoes_setores],
 //    [RedeCorporativa],[SGH],[Simproc],[Grafica],[OS_manutencao],[Sei],[SigaSaude]
 //FROM [SolicitaAcesso].[dbo].[Vw_MinhasSolicitacoes]  where rf_Coordenador='" + rfFuncionario + "'";
 //               com.Open();
 //               SqlCommand commd = new SqlCommand(strQuery, com);
 //               SqlDataReader dr = commd.ExecuteReader();
 //               while (dr.Read())
 //               {
 //                   DadosSolicitacoesSetores l = new DadosSolicitacoesSetores();

 //                   l.NomeSolicitante = dr.IsDBNull(0) ? null : dr.GetString(0);
 //                   l.Nome_funcionario = dr.IsDBNull(1) ? null : dr.GetString(1);
 //                   l.rf_funcionario = dr.IsDBNull(2) ? null : dr.GetString(2);
 //                   l.login_do_funcionario = dr.IsDBNull(3) ? null : dr.GetString(3);
 //                   DateTime dt = dr.GetDateTime(4);
 //                   l.dataSolicitacao = dt.ToShortDateString();
 //                   l.id_Solicitacao = dr.GetInt32(5);
 //                   l.RedeCorporativa = dr.IsDBNull(6) ? null : dr.GetString(6);
 //                   l.SGH = dr.IsDBNull(7) ? null : dr.GetString(7);
 //                   l.Simproc = dr.IsDBNull(8) ? null : dr.GetString(8);
 //                   l.Grafica = dr.IsDBNull(9) ? null : dr.GetString(9);
 //                   l.OS_manutencao = dr.IsDBNull(10) ? null : dr.GetString(10);
 //                   l.Sei = dr.IsDBNull(11) ? null : dr.GetString(11);

 //                   if (l.RedeCorporativa == "S")
 //                   {
 //                       l.SetoresConcatenados = "( Rede corporativa ) ";
 //                   }
 //                   if (l.SGH == "S")
 //                   {
 //                       l.SetoresConcatenados += "( SGH ) ";
 //                   }
 //                   if (l.Simproc == "S")
 //                   {
 //                       l.SetoresConcatenados += "( Simproc ) ";
 //                   }
 //                   if (l.Grafica == "S")
 //                   {
 //                       l.SetoresConcatenados += "( Grafica ) ";
 //                   }
 //                   if (l.OS_manutencao == "S")
 //                   {
 //                       l.SetoresConcatenados += "( OS manutenção ) ";
 //                   }
 //                   if (l.Sei == "S")
 //                   {
 //                       l.SetoresConcatenados += "( Sei ) ";
 //                   }
 //                   lista.Add(l);
 //               }
 //               com.Close();
 //           }
 //           catch (Exception ex)
 //           {
 //               string erro = ex.Message;
 //               throw;
 //           }
 //           return lista;
 //       }
 //   }
    public static List<DadosSolicitacoesSetores> MostraSolicitacoesNaTelaStatus()
    {

        var lista = new List<DadosSolicitacoesSetores>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))

        {
            try
            {
                string strQuery = @"SELECT [id_chamado],[nome_funcionario],[rf],[login],[cargo],[ramal],[dataSolicitacao]
      ,[RedeCorporativa],[SGH],[Simproc],[Grafica],[OS_manutencao],[Sei],[SigaSaude]  FROM [SolicitaAcesso].[dbo].[Vw_MostraSetoresSolicitados] where ativa_Solicitacao='S'";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                while (dr.Read())
                {
                    DadosSolicitacoesSetores l = new DadosSolicitacoesSetores();
                    l.id_Solicitacao = dr.GetInt32(0);
                    l.Nome_funcionario = dr.IsDBNull(1) ? null : dr.GetString(1);
                    l.rf_funcionario = dr.IsDBNull(2) ? null : dr.GetString(2);
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
  FROM [SolicitaAcesso].[dbo].[Solicitante_Dados] where id_chamado=" + idChamado + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.id_chamado_ = dr1.GetInt32(0);
                    d.NomeFuncionario = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.RF_Funcionario = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    d.login = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.cargoFuncionario = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    d.ramal1 = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    d.lotacao = dr1.IsDBNull(6) ? "" : dr1.GetString(6);
                    d.dtSolicitacao = dr1.GetDateTime(7);
                    d.NomeSolicitante_Coordenador = dr1.IsDBNull(8) ? "" : dr1.GetString(8);
                    d.eMail = dr1.IsDBNull(10) ? "" : dr1.GetString(10);
                    d.ramalFuncionario = dr1.IsDBNull(11) ? "" : dr1.GetString(11);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return d;
        }
    }

    public static List<DadosSolicitacoesSetores> MostraMinhasSolicitacoesVisualizar(string Login_Solicitante)
    {
        string rfFuncionario = GetRfSolicitanteSetor(Login_Solicitante);
        var lista = new List<DadosSolicitacoesSetores>();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"SELECT [NomeCompleto],[nome_funcionario],[rf],[login],[dataSolicitacao],[Id_Solicitacoes_setores],
     [RedeCorporativa],[SGH],[Simproc],[Grafica],[OS_manutencao],[Sei],[SigaSaude],[lotacao]
 FROM [SolicitaAcesso].[dbo].[Vw_MinhasSolicitacoes]  where lotacao ='" + rfFuncionario + "' or LoginRede='" + Login_Solicitante + "'";
                //               string strQuery = @"SELECT [nome_Coordenador],[nome_funcionario],[rf],[login],[dataSolicitacao],[Id_Solicitacoes_setores],
                //    [RedeCorporativa],[SGH],[Simproc],[Grafica],[OS_manutencao],[Sei],[SigaSaude]
                //FROM [SolicitaAcesso].[dbo].[Vw_MinhasSolicitacoes]  where rf_Coordenador='" + rfFuncionario + "'";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                while (dr.Read())
                {
                    DadosSolicitacoesSetores l = new DadosSolicitacoesSetores();
                    l.NomeSolicitante = dr.IsDBNull(0) ? null : dr.GetString(0);
                    l.Nome_funcionario = dr.IsDBNull(1) ? null : dr.GetString(1);
                    l.rf_funcionario = dr.IsDBNull(2) ? null : dr.GetString(2);
                    l.login_do_funcionario = dr.IsDBNull(3) ? null : dr.GetString(3);
                    DateTime dt = dr.GetDateTime(4);
                    l.dataSolicitacao = dt.ToShortDateString();
                    l.id_Solicitacao = dr.GetInt32(5);
                    l.RedeCorporativa = dr.IsDBNull(6) ? null : dr.GetString(6);
                    l.SGH = dr.IsDBNull(7) ? null : dr.GetString(7);
                    l.Simproc = dr.IsDBNull(8) ? null : dr.GetString(8);
                    l.Grafica = dr.IsDBNull(9) ? null : dr.GetString(9);
                    l.OS_manutencao = dr.IsDBNull(10) ? null : dr.GetString(10);
                    l.Sei = dr.IsDBNull(11) ? null : dr.GetString(11);
                    l.Siga_Saude = dr.IsDBNull(12) ? null : dr.GetString(12);

                    if (l.RedeCorporativa == "S" || l.RedeCorporativa == "C" || l.RedeCorporativa == "E" || l.RedeCorporativa == "R" || l.RedeCorporativa == "X")
                    {
                        l.SetoresConcatenados = "( Rede corporativa ) ";
                    }
                    if (l.SGH == "S" || l.SGH == "C" || l.SGH == "E" || l.SGH == "R" || l.SGH == "X")
                    {
                        l.SetoresConcatenados += "( SGH ) ";
                    }
                    if (l.Simproc == "S" || l.Simproc == "C" || l.Simproc == "E" || l.Simproc == "R" || l.Simproc == "X")
                    {
                        l.SetoresConcatenados += "( Simproc ) ";
                    }
                    if (l.Grafica == "S" || l.Grafica == "C" || l.Grafica == "E" || l.Grafica == "R" || l.Grafica == "X")
                    {
                        l.SetoresConcatenados += "( Grafica ) ";
                    }
                    if (l.OS_manutencao == "S" || l.OS_manutencao == "C" || l.OS_manutencao == "E" || l.OS_manutencao == "R" || l.OS_manutencao == "X")
                    {
                        l.SetoresConcatenados += "( OS manutenção ) ";
                    }
                    if (l.Sei == "S" || l.Sei == "C" || l.Sei == "E" || l.Sei == "R" || l.Sei == "X")
                    {
                        l.SetoresConcatenados += "( Sei ) ";
                    }
                    if (l.Siga_Saude == "S" || l.Siga_Saude == "C" || l.Siga_Saude == "E" || l.Siga_Saude == "R" || l.Siga_Saude == "X")
                    {
                        l.SetoresConcatenados += "( Siga-Saúde ) ";
                    }
                    l.lotacao = dr.IsDBNull(13) ? null : dr.GetString(13);
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
    public static bool boolVerificaMinhasSolicitacoesVisualizar(string Login_Solicitante)
    {
        string rfFuncionario = GetRfSolicitanteSetor(Login_Solicitante);
        bool existe = false;
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"SELECT [NomeCompleto],[nome_funcionario],[rf],[login],[dataSolicitacao],[Id_Solicitacoes_setores],
     [RedeCorporativa],[SGH],[Simproc],[Grafica],[OS_manutencao],[Sei],[SigaSaude]
 FROM [SolicitaAcesso].[dbo].[Vw_MinhasSolicitacoes]  where setor_Coordenador='" + rfFuncionario + "'";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                existe = dr.Read();
                com.Close();

            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                throw;
            }
        }
        return existe;
    }
    public static DadosSetoresSolicitados_S GetSetoresCom_S(int idChamado)
    {
        DadosSetoresSolicitados_S d = new DadosSetoresSolicitados_S();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();
            string sqlConsulta = @"SELECT [RedeCorporativa],[SGH],[Simproc],[Grafica],[OS_manutencao],[Sei],[SigaSaude],[DadosSolicitadosSGH]
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
                    d.Siga_Saude = dr1.IsDBNull(6) ? "" : dr1.GetString(6);
                    d.DadosSolicitadosSGH = dr1.IsDBNull(7) ? "" : dr1.GetString(7);// criar esse campo no banco
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return d;
        }
    }

    public static void Atualiza_Login_Cadastrado(string UserId)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"UPDATE [dbo].[aspnet_Users]
   SET [atribuido] ='S'
 WHERE UserId ='" + UserId + "'";

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


    public static void Atualiza_Solicitacoes_setores_Update(int Id_chamado, string nomeCampo, string statusS)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"UPDATE [dbo].[Setores_Solicitados]
   SET [" + nomeCampo + "]='" + statusS + "' WHERE Id_Solicitacoes_setores=" + Id_chamado + "";

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

    public static void Atualiza_Solicitante_dados_status(int Id_chamado)
    {

        bool result = VerificaSetoresComStatusSolitacaoEmAberto(Id_chamado);

        if (result == false)
        {
            using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
            {
                try
                {
                    string strQuery = @"UPDATE [dbo].[Solicitante_Dados]
   SET ativa_Solicitacao ='C' WHERE id_chamado=" + Id_chamado + "";

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
    }

    public static bool VerificaSetoresComStatusSolitacaoEmAberto(int idChamado)
    {
        bool existe;
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))

        {
            try
            {
                string strQuery = @"SELECT [id_chamado],[nome_funcionario],[rf],[login],[cargo],[ramal],[dataSolicitacao]
      ,[RedeCorporativa],[SGH],[Simproc],[Grafica],[OS_manutencao],[Sei],[SigaSaude]  FROM [SolicitaAcesso].[dbo].[Vw_MostraSetoresSolicitados] where id_chamado=" + idChamado + " and ativa_Solicitacao='S' " +
     "and (RedeCorporativa='S' or SGH='S' or Simproc='S' or Grafica='S' or OS_manutencao='S' or Sei='S' )";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                existe = dr.Read();
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                throw;
            }
        }
        return existe;
    }

    public static string VerificaStatusDaSolicitacao(int idChamado, string Campo)
    {
        string statusSolicitacao = "";
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))

        {
            try
            {
                string strQuery = @"SELECT " + Campo + " FROM [SolicitaAcesso].[dbo].[Vw_MostraSetoresSolicitados]" +
                    " where id_chamado=" + idChamado + " ";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();

                if (dr.Read())
                {
                    statusSolicitacao = dr.IsDBNull(0) ? "" : dr.GetString(0);
                }
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                throw;
            }
        }
        return statusSolicitacao;
    }

    public static DadosRedeCoorporativa GetDadosRedeCorporativaSolicitacao(int id)
    {
        DadosRedeCoorporativa d = new DadosRedeCoorporativa();
        //var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();

            string sqlConsulta = @"SELECT [redeCorperativa] ,[emailCorporativo] ,[caixaDepartamental],[caixaDepartamental_descricao]
            ,[pastaRede] ,[pastaEspecifica],[status_RedeCorporativa],[caixaDepartamental_Nova_descricao]
  FROM [SolicitaAcesso].[dbo].[RedeCorporativa] where id_chamado_rede_corporativa=" + id + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.redeCorporativa = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    d.emailCorporativo = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.caixaDepartamental = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    d.caixaDepartamental_Descricao = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.pastaDeRede = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    d.PastaEspecifica = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    //d.status_redeCoorporativa = dr1.IsDBNull(6) ? "" : dr1.GetString(6); 
                    d.caixaDepartamental_DescricaoNova = dr1.IsDBNull(7) ? "" : dr1.GetString(7);
                    d.status_redeCoorporativa = VerificaStatusDaSolicitacao(id, "RedeCorporativa");
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return d;
    }

    public static DadosSGH GetDadosSGH(int id)
    {
        DadosSGH d = new DadosSGH();
        //var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();
            string sqlConsulta = @"SELECT [Amb],[Amb_Desc],[CenCir],[CenCir_Desc],[Internacao],[Internacao_Desc],[Ps],[Ps_Desc]     
  FROM [SolicitaAcesso].[dbo].[Sgh] where id_chamado_sgh=" + id + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.Amb = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    d.Amb_Desc = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.CenCir = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    d.CenCir_Desc = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.Internacao = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    d.Internacao_Desc = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    d.PS = dr1.IsDBNull(6) ? "" : dr1.GetString(6);
                    d.PS_Desc = dr1.IsDBNull(7) ? "" : dr1.GetString(7);
                    d.status_SGH = VerificaStatusDaSolicitacao(id, "SGH");
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return d;
    }

    public static DadosSimproc GetDadosSimproc(int id)
    {
        DadosSimproc d = new DadosSimproc();
        //var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();
            string sqlConsulta = @"SELECT [cod_Unidade],[cpf_simproc],[rg_simproc],[dataAdmissao]   
  FROM [SolicitaAcesso].[dbo].[Simproc] where id_chamdo_simproc=" + id + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.CodigoUnidade_Simproc = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    d.cpf_simproc = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.rg_simproc = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    d.dataAdmissao = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.status_Simproc = VerificaStatusDaSolicitacao(id, "Simproc");
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return d;
    }

    public static DadosGrafica GetDadosGrafica(int id)
    {
        DadosGrafica d = new DadosGrafica();
        //var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();
            string sqlConsulta = @"SELECT [N_centro_custo_grafica],[N_centro_custo_grafica_antigo],[cpf_grafica]   
  FROM [SolicitaAcesso].[dbo].[Grafica] where id_chamado_grafica=" + id + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.N_centro_custo_grafica = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    d.N_centro_custo_grafica_antigo = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.cpf_grafica = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    d.status_grafica = VerificaStatusDaSolicitacao(id, "Grafica");
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return d;
    }

    public static DadosOsManutencao GetDadosOsManutencao(int id)
    {
        DadosOsManutencao d = new DadosOsManutencao();
        //var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();
            string sqlConsulta = @"SELECT [N_centro_custos_Novo],[N_centro_custos_Antigo],[cpf_manutencao] FROM [SolicitaAcesso].[dbo].[OsManutencao] where id_chamado_manutencao=" + id + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.N_centro_custos_novo = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    d.N_centro_custos_antigo = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.cpf_manutencao = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    d.status_os_manutencao = VerificaStatusDaSolicitacao(id, "OS_manutencao");
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return d;
    }

    public static DadosSei GetDadosSEI(int id)
    {
        DadosSei d = new DadosSei();
        //var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();
            string sqlConsulta = @"SELECT [siglasUnidades1],[siglasUnidades2],[siglasUnidades3],[siglasUnidades4] FROM [SolicitaAcesso].[dbo].[Sei] 
             where id_chamado_Sei=" + id + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.siglasUnidades1 = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    d.siglasUnidades2 = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.siglasUnidades3 = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    d.siglasUnidades4 = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.status_Sei = VerificaStatusDaSolicitacao(id, "Sei");
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return d;
    }

    public static DadosSigaSaude GetDadosSigaSaude(int id)
    {
        DadosSigaSaude d = new DadosSigaSaude();
        //var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();
            string sqlConsulta = @"SELECT [dtNascSiga],[nomeDaMaeSiga],[CRM_siga],[cpfSiga],[RG_siga],[UF_Siga],[dtEmisaoRG_Siga]
      ,[orgao_RG_Siga],[nomeDaRuaSiga],[NumeroDaRuaSiga],[bairoSiga],[CepSiga],[ModuloAcessarSiga],[ObsSiga]     
  FROM [SolicitaAcesso].[dbo].[SigaSaude] 
             where id_chamado_siga_saude=" + id + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.dtNascSiga = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    d.nomeDaMaeSiga = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.CRM_siga = dr1.GetInt32(2);
                    d.cpfSiga = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.RG_siga = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    d.UF_Siga = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    d.dtEmisaoRG_Siga = dr1.IsDBNull(6) ? "" : dr1.GetString(6);
                    d.orgao_RG_Siga = dr1.IsDBNull(7) ? "" : dr1.GetString(7);
                    d.nomeDaRuaSiga = dr1.IsDBNull(8) ? "" : dr1.GetString(8);
                    d.NumeroDaRuaSiga = dr1.GetInt32(9);
                    d.bairoSiga = dr1.IsDBNull(10) ? "" : dr1.GetString(10);
                    d.CepSiga = dr1.IsDBNull(11) ? "" : dr1.GetString(11);
                    d.ModuloAcessarSiga = dr1.IsDBNull(12) ? "" : dr1.GetString(12);
                    d.ObsSiga = dr1.IsDBNull(13) ? "" : dr1.GetString(13);
                    d.status_SigaSaude = VerificaStatusDaSolicitacao(id, "SigaSaude");
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return d;
    }

    public static DadosCompSGH GetDadosSGH_Comp(int id)
    {
        DadosCompSGH d = new DadosCompSGH();
        //var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();
            string sqlConsulta = @"SELECT [dtNasci_dadosComp]
      ,[nomeMae_dadosComp],[crm_dadosComp],[cpf_dadosComp],[rg_dadosComp]
  FROM [SolicitaAcesso].[dbo].[DadosCompSGH] 
             where Id_Chamado_dadosComp=" + id + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    d.dtNasci_dadosComp = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    d.nomeMae_dadosComp = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    d.crm_dadosComp = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    d.cpf_dadosComp = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    d.rg_dadosComp = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    d.status_dadosComp = VerificaStatusDaSolicitacao(id, "DadosSolicitadosSGH");
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

        }
        return d;
    }

    public static string VerificaNomeDoLogin(string login)
    {
        string nomeUsuario = "";
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))

        {
            try
            {
                string strQuery = @"SELECT [NomeCompleto]     
                                      FROM [SolicitaAcesso].[dbo].[Usuarios]
                                              where LoginRede= '" + login + "'";
                com.Open();
                SqlCommand commd = new SqlCommand(strQuery, com);
                SqlDataReader dr = commd.ExecuteReader();
                if (dr.Read())
                {
                    nomeUsuario = dr.IsDBNull(0) ? "" : dr.GetString(0);
                }
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                throw;
            }
        }
        return nomeUsuario;
    }
    public static void GravaOBSpermissaoExcluir(int Id_chamado, string obs)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            bool existe = false;
            string OBSHistorico = "";
            string strQuery = "";
            try
            {
                SqlCommand comm = com.CreateCommand();
                //string strQuery = @"select MAX(id_chamado) FROM [SolicitaAcesso].[dbo].[Solicitante_Dados]";
                string strQuery1 = @"SELECT *  FROM [SolicitaAcesso].[dbo].[Excluir_Permissao_OBS]  where id_solicitacao_OBS_Excluir=" + Id_chamado + "";
                comm.CommandText = strQuery1;
                com.Open();
                SqlDataReader dr2 = comm.ExecuteReader();

                while (dr2.Read())
                {
                    OBSHistorico = dr2.GetString(1);
                    existe = true;
                }
                com.Close();

                OBSHistorico += ">>>" + obs;

                if (existe == true)
                {
                    strQuery = @"UPDATE [dbo].[Excluir_Permissao_OBS]
   SET [OBS_Excluir] ='" + OBSHistorico + "' WHERE id_solicitacao_OBS_Excluir ='" + Id_chamado + "'";
                    SqlCommand commd = new SqlCommand(strQuery, com);
                    commd.CommandText = strQuery;
                    com.Open();
                    commd.ExecuteNonQuery();
                    com.Close();
                }
                else if (existe == false)
                {
                    strQuery = @"INSERT INTO  [dbo].[Excluir_Permissao_OBS] ([id_solicitacao_OBS_Excluir],[OBS_Excluir])
                                     VALUES (@id_solicitacao_OBS_Excluir,@OBS_Excluir)";
                    SqlCommand commd = new SqlCommand(strQuery, com);
                    commd.Parameters.Add("@id_solicitacao_OBS_Excluir", SqlDbType.Int).Value = Id_chamado;
                    commd.Parameters.Add("@OBS_Excluir", SqlDbType.VarChar).Value = obs;
                    commd.CommandText = strQuery;
                    com.Open();
                    commd.ExecuteNonQuery();
                    com.Close();
                }

            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
        }
    }

    public static String GetDadosExtratoAcesso(int id)
    {
        string extratoAcesso = "";
        //var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();
            string sqlConsulta = @"SELECT [extrato_solicitaAcesso]  FROM [SolicitaAcesso].[dbo].[Extrato_SolicitaAcesso] 
             where id_chamado_Extrato=" + id + "";
            cmm.CommandText = sqlConsulta;
            try
            {
                com.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    extratoAcesso = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return extratoAcesso;
    }



}