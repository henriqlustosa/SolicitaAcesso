using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DadosSolicitacao
/// </summary>
public class DadosSolicitacao
{    
    public string NomeFuncionario { get; set; }
    public int RF_Funcionario { get; set; }
    public string login { get; set; }
    public string cargoFuncionario { get; set; }
    public string ramal1 { get; set; }
    public string lotacao { get; set; }
    public DateTime dtSolicitacao { get; set; }
    public string NomeSolicitante_Coordenador { get; set; }
    public string eMail { get; set; }
    public string ativa_solicitacao { get; set; }
    public bool msg_JaTemSolicitacaoAberta { get; set; }
    public int id_chamado_ { get; set; }
}