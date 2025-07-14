using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class importadosFuncionariosHSPM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ImportarFuncionarios();
    }



    public void ImportarFuncionarios()
    {
        // Caminho do arquivo Excel
        string caminhoArquivoExcel = @"C:\Users\h013027\Desktop\lista de funcionarios HSPM.xlsx";

        // String de conexão para o SQL Server
        string conexaoSqlServer = "Data Source=hspmins18;database=SolicitaAcesso;Persist Security Info=True;user id=hspmApp;password=SoundG@rden=1";

        // String de conexão para arquivos Excel (para .xlsx)
        string conexaoExcel = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + caminhoArquivoExcel + ";Extended Properties='Excel 12.0 Xml;HDR=YES;'";

        using (OleDbConnection conexaoOleDb = new OleDbConnection(conexaoExcel))
        {
            conexaoOleDb.Open();

            // Supondo que os dados estão na primeira aba do Excel chamada "Sheet1$"
            string consulta = "SELECT * FROM [Sheet1$]";
            OleDbCommand comandoOleDb = new OleDbCommand(consulta, conexaoOleDb);

            using (OleDbDataReader reader = comandoOleDb.ExecuteReader())
            {
                using (SqlConnection conexaoSql = new SqlConnection(conexaoSqlServer))
                {
                    conexaoSql.Open();

                    while (reader.Read())
                    {
                        string sql = "INSERT INTO FuncionariosHSPM (rf, v, nome, setor) VALUES (@rf, @v, @nome, @setor)";
                        using (SqlCommand comandoSql = new SqlCommand(sql, conexaoSql))
                        {
                            comandoSql.Parameters.AddWithValue("@rf", reader["rf"]);
                            comandoSql.Parameters.AddWithValue("@v", reader["v"]);
                            comandoSql.Parameters.AddWithValue("@nome", reader["nome"]);
                            comandoSql.Parameters.AddWithValue("@setor", reader["setor"]);

                            comandoSql.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }

}