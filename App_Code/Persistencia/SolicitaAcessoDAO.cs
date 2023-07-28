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
                    d.ramal1 = dr1.GetInt32(5);
                    d.ramal2 = dr1.GetInt32(6);
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
        var lista = new DadosCoordenador();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SolicitaAcessoConnectionString"].ToString()))
        {
            SqlCommand cmm = com.CreateCommand();

            string sqlConsulta = @"SELECT [id],[nome_Coordenador],[ramal_Coordenador],[setor_Coordenador] 
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
                    d.ramal1 = dr1.GetInt32(2);
                    d.setorCoordenador = dr1.IsDBNull(3) ? "" : dr1.GetString(3);

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
           ,[email_funcionario]
           ,[ativa_Solicitacao])"
         + " VALUES (@nome_funcionario,@rf,@login,@cargo,@ramal,@lotacao,@dataSolicitacao,@solicitante,@email_funcionario,@ativa_Solicitacao)";

                    SqlCommand commd = new SqlCommand(strQuery, com);
                    commd.Parameters.Add("@nome_funcionario", SqlDbType.VarChar).Value = Dados.NomeFuncionario;
                    commd.Parameters.Add("@rf", SqlDbType.Int).Value = Dados.RF_Funcionario;
                    commd.Parameters.Add("@login", SqlDbType.VarChar).Value = Dados.login;
                    commd.Parameters.Add("@cargo", SqlDbType.VarChar).Value = Dados.cargoFuncionario;
                    commd.Parameters.Add("@ramal", SqlDbType.Int).Value = Dados.ramal1;
                    commd.Parameters.Add("@lotacao", SqlDbType.VarChar).Value = Dados.lotacao;
                    commd.Parameters.Add("@dataSolicitacao", SqlDbType.DateTime).Value = Dados.dtSolicitacao;
                    commd.Parameters.Add("@solicitante", SqlDbType.VarChar).Value = Dados.NomeSolicitante_Coordenador;
                    commd.Parameters.Add("@email_funcionario", SqlDbType.VarChar).Value = Dados.eMail = "Não Informado";
                    commd.Parameters.Add("@ativa_Solicitacao", SqlDbType.VarChar).Value = Dados.eMail = "S";

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
}