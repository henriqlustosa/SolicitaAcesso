using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DadosSolicitacoesSetores
/// </summary>
public class DadosSolicitacoesSetores
{
    public int id_Solicitacao { get; set; }
    public string Nome_funcionario { get; set; }
    public string rf_funcionario { get; set; }
    public string login_do_funcionario { get; set; }
    public string Cargo_Funcionario { get; set; }
    public string Ramal { get; set; }
    //  public string lotacao { get; set; }

    public string dataSolicitacao { get; set; }
    public string RedeCorporativa { get; set; }
    public string SGH { get; set; }
    public string Simproc { get; set; }
    public string Grafica { get; set; }
    public string OS_manutencao { get; set; }
    public string Sei { get; set; }
    public string Siga_Saude { get; set; }

    public string SetoresConcatenados { get; set; }

    public string NomeSolicitante { get; set; }
    public string lotacao { get; set; }


}