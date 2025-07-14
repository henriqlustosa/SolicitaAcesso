<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VisualizarSolicitacoes.aspx.cs" Inherits="VisualizarSolicitacoes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../bootstrap5/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../bootstrap5/dist/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:label id="pegaNomeLoginUsuario" runat="server" text="" visible="False"></asp:label>
    <asp:label id="id_Chamado" runat="server" text="Label" visible="False"></asp:label>
    <div class="row">
        <asp:checkbox id="CkbExibeRedeCorporativa" runat="server" autopostback="True" visible="False"></asp:checkbox>
        <asp:checkbox id="ckbExibeSGH" runat="server" autopostback="True" visible="False"></asp:checkbox>
        <asp:checkbox id="ckbExibeSimproc" runat="server" autopostback="True" visible="False"></asp:checkbox>
        <asp:checkbox id="ckbExibeGrafica" runat="server" autopostback="True" visible="False"></asp:checkbox>
        <asp:checkbox id="ckbExibeOSmanutencao" runat="server" autopostback="True" visible="False"></asp:checkbox>
        <asp:checkbox id="ckbExibeSEI" runat="server" autopostback="True" visible="False"></asp:checkbox>
        <asp:checkbox id="ckbExibeSigaSaude" runat="server" autopostback="True" visible="False"></asp:checkbox>
        <asp:checkbox id="ckbExibeDadosComp" runat="server" autopostback="True" visible="False"></asp:checkbox>
    </div>
    <div class="container">
        <h3 class="text-center fw-bold m-2">Visualizar Solicitações </h3>
        <div class="row m-2">
            <div class="col-auto">
                <%--<div class="col-auto me-auto">--%>
                <asp:label runat="server" class="fw-bold" text="Nome do funcionário"></asp:label>
                <asp:label id="txtNomeFuncionario" runat="server" class="form-control" backcolor="#EFEFEF"></asp:label>
            </div>
            <div class="col-auto">
                <b>RF/RG</b>
                <asp:label id="txtRF" runat="server" class="form-control" backcolor="#EFEFEF"></asp:label>
            </div>
            <div class="col-auto">
                <b>Login</b>
                <asp:label id="txtLogin" runat="server" class="form-control" backcolor="#EFEFEF"></asp:label>
            </div>
            <div class="col-auto">
                <b>Cargo do funcionário</b>
                <asp:label id="txtCargo" runat="server" class="form-control" backcolor="#EFEFEF"></asp:label>
            </div>
            <div class="col-auto">
                <b>Lotação</b>
                <asp:label id="txtLotacao" runat="server" class="form-control" backcolor="#EFEFEF"></asp:label>
            </div>
            <div class="col-auto">
                <b>Data do Pedido</b>
                <asp:label id="txtData" runat="server" class="form-control" backcolor="#EFEFEF"></asp:label>
            </div>
        </div>
        <div class="row m-2">
            <div class="col-auto">
                <b>Coordenador/Chefia</b>
                <asp:label id="txtSolicitante" runat="server" class="form-control" backcolor="#EFEFEF"></asp:label>
            </div>
            <div class="col-auto">
                <b>E-mail do Coordenador</b>
                <asp:label id="txtEmail" runat="server" class="form-control" backcolor="#EFEFEF"></asp:label>
            </div>
            <div class="col-auto">
                <b>Ramal Chefia</b>
                <asp:label id="txtRamal" runat="server" class="form-control" backcolor="#EFEFEF"></asp:label>
            </div>
            <div class="col-auto">
                <b>Ramal Funcionário</b>
                <asp:label id="txtRamalFuncionario" runat="server" class="form-control" backcolor="#EFEFEF"></asp:label>
            </div>
        </div>
        <br />
        <asp:panel runat="server" id="PanelDadosPessoaisTerceiro" borderstyle="Double" groupingtext="Dados Complementares" visible="False" align="Center">
            <div id="DivDadosPessoais">
                <div class="row m-0">
                    <%--  <div class="col-auto">
                        Solicitação:
                        <asp:Label runat="server" ID="Label1" Text="Não Preenchido" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>--%>
                    <div class="col-auto">
                        <asp:Label runat="server" ID="LabelDadosCompDtNasc" Text="Data de Nascimento: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="LabelDadosCompDtNasc_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="LabelDadosCompNomeDaMae" Text="Nome da Mãe: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="LabelDadosCompNomeDaMae_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="LabelDadosCompCRM" Text="CRM:" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="LabelDadosCompCRM_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="LabelDadosCompRG" Text="RG:" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="LabelDadosCompRG_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="LabelDadosCompCPF" Text="CPF:" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="LabelDadosCompCPF_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>
                </div>
            </div>
        </asp:panel>
        <asp:panel runat="server" id="PanelRedeCorporativa" borderstyle="Double" groupingtext="Rede Corporativa" visible="False" align="Center">
            <div id="DivRedeCorporativa">
                <div class="row m-0">
                    <div class="col-auto">
                        Solicitação:
                        <asp:Label runat="server" ID="LabelRedeTipoSolicitacao" Text="Não Preenchido" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>
                    <div class="col-auto">
                        <asp:Label runat="server" ID="LabelRedeEmail" Text="( E-mail Corporativo ) &nbsp;&nbsp;" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="LabelRedeCaixaDepartamental" Text="(Caixa Departamental: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="LabelRedeCaixaDepartamental_Descricao" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="LabelRedePastaDeRede" Text="&nbsp;&nbsp;&nbsp (Pasta de Rede Solicitada:" Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="LabelRedePastaEspecifica" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>
                </div>
                <div class="row m-0">
                    <h6 class="text-right fw-bold m-2">Situação:
                        <asp:Label ID="LabelSituacaoRedeCorporativa" runat="server" Text="" Font-Bold="True"></asp:Label>
                    </h6>
                </div>             

            </div>
        </asp:panel>
        <asp:panel runat="server" id="PanelSGH" borderstyle="Double" groupingtext="SGH" visible="False" align="Center">
            <div id="DivSGH">
                <div class="row m-0">
                    <div class="col-auto">
                        <asp:Label runat="server" ID="labelAmb" Text="( Ambulatório: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelAmb_descricao" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelInternacao" Text="( Internação: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelInternacao_descricao" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelCentroCir" Text="( Centro Cirurgico: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelCentroCir_descricao" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelProntoSocorro" Text="( Pronto Socorro: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelProntoSocorro_descricao" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>
                </div>
                <div class="row m-0">
                    <h6 class="text-right fw-bold m-2">Situação:
                        <asp:Label ID="LabelSituacaoSGH" runat="server" Text="" Font-Bold="True"></asp:Label>
                    </h6>
                </div>

                
            </div>
        </asp:panel>
        <asp:panel runat="server" id="PanelSimproc" borderstyle="Double" groupingtext="Simproc" visible="False" horizontalalign="Center">
            <div id="DivSimproc">
                <div class="row m-1">
                    <div class="col-auto">
                        <asp:Label runat="server" ID="labelSimprocCod_Uni" Text="( Codigo da Unidade: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSimprocCod_Uni_Desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSimprocCpf" Text="( CPF: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSimprocCpf_Desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSimprocRG" Text="( RG: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSimprocRG_Desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSimprocDtAdmissao" Text="( Data Admissão: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSimprocDtAdmissao_Desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>
                </div>
                <div class="row m-0">
                    <h6 class="text-right fw-bold m-2">Situação:
                        <asp:Label ID="LabelSituacaoSimproc" runat="server" Text="" Font-Bold="True"></asp:Label>
                    </h6>
                </div>             
            </div>
        </asp:panel>
        <asp:panel runat="server" id="PanelGrafica" borderstyle="Double" groupingtext="Central/Gráfica" visible="False" horizontalalign="Center">
            <div id="DivGrafica">
                <div class="row m-1">
                    <div class="col-auto">
                        <asp:Label runat="server" ID="labelgraficaSolicitado" Text="Solicitado: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelGraficaSolicitada" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelGraficaNcentroCusto" Text="( Nº Centro de Custo " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelGraficaNcentroCusto_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelGraficaNcentroCusto_Antigo" Text="( Nº Centro de Custo-antigo " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelGraficaNcentroCusto_Antigo_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelGraficaCPF" Text="( CPF: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelGraficaCPF_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>
                </div>
                <div class="row m-0">
                    <h6 class="text-right fw-bold m-2">Situação:
                        <asp:Label ID="LabelSituacaoGrafica" runat="server" Text="" Font-Bold="True"></asp:Label>
                    </h6>
                 </div>
              
            </div>

        </asp:panel>
        <asp:panel runat="server" id="PanelOsManutencao" borderstyle="Double" groupingtext="OS-Manutencao" visible="False" horizontalalign="Center">
            <div id="OsManutencao">
                <div class="row m-0">
                    <div class="col-auto">
                        <asp:Label runat="server" ID="labelOsManutencaoNcentroCustoNovo" Text="( Nº centro de custos Novo: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelOsManutencaoNcentroCustoNovo_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelOsManutencaoNcentroCustoAntigo" Text="( Nº centro de custos Antigo: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelOsManutencaoNcentroCustoAntigo_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelOsManutencaoCPF" Text="( CPF: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelOsManutencaoCPF_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>
                </div>
                <div class="row m-0">
                    <h6 class="text-right fw-bold m-2">Situação:
                        <asp:Label ID="LabelSituacaoOsManutencao" runat="server" Text="" Font-Bold="True"></asp:Label>
                    </h6>
                    </div>
             
            </div>
        </asp:panel>
        <asp:panel runat="server" id="PanelSEI" borderstyle="Double" groupingtext="SEI" visible="False" horizontalalign="Center">
            <div id="DivSei">
                <div class="row m-0">
                    <div class="col-auto">
                        <asp:Label runat="server" ID="labelSeiSiglaUnidade_1" Text="( Sigla Unidade 1: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSeiSiglaUnidade_1_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSeiSiglaUnidade_2" Text="( Sigla Unidade 2: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSeiSiglaUnidade_2_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSeiSiglaUnidade_3" Text="( Sigla Unidade 3: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSeiSiglaUnidade_3_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSeiSiglaUnidade_4" Text="( Sigla Unidade 4: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSeiSiglaUnidade_4_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>
                </div>
                <div class="row m-0">
                    <h6 class="text-right fw-bold m-2">Situação:
                        <asp:Label ID="LabelSituacaoSEI" runat="server" Text="" Font-Bold="True"></asp:Label>
                    </h6>
                     </div>
               
            </div>
        </asp:panel>
        <asp:panel runat="server" id="PanelSiga_Saude" borderstyle="Double" groupingtext="Siga-Saúde" visible="False" horizontalalign="Center">
            <div id="DivSigaSaude">
                <div class="row m-1">
                    <div class="col-auto">
                        <asp:Label runat="server" ID="labelSigaSaudeDtNasc" Text="( Data Nascimento: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeDtNasc_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeNomeMae" Text="( Mome da Mãe: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeNomeMae_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>
                </div>
                <div class="row m-1">
                    <div class="col-auto">
                        <asp:Label runat="server" ID="labelSigaSaudeCRM" Text="( CRM: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeCRM_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeCPF" Text="( CPF: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeCPF_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeRG" Text="( RG: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeRG_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeUF" Text="( UF: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeUF_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeDtEmissao" Text="( Data de Emissão: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeDtEmissao_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeOrgao" Text="( Orgão: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeOrgao_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>

                    </div>
                </div>
                <div class="row m-1">
                    <div class="col-auto">
                        <asp:Label runat="server" ID="labelSigaSaudeNomeRua" Text="( Rua: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeNomeRua_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeNrua" Text="( Nº: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeNrua_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeBairro" Text="( Bairro: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeBairro_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeCEP" Text="( CEP: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeCEP_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>
                </div>
                <div class="row m-1">
                    <div class="col-auto">
                        <asp:Label runat="server" ID="labelSigaSaudeModuloAcessar" Text="( Modulo que irá acessar: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeModuloAcessar_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeOBS" Text="( Obs: " Visible="false"></asp:Label>
                        <asp:Label runat="server" ID="labelSigaSaudeOBS_desc" Text="" Font-Bold="True" Font-Italic="true"></asp:Label>
                    </div>
                </div>
                <div class="row m-0">
                    <h6 class="text-right fw-bold m-2">Situação:
                        <asp:Label ID="LabelSituacaoSigaSaude" runat="server" Text="" Font-Bold="True"></asp:Label>
                    </h6>
                   </div>               
            </div>
        </asp:panel>
          Movimentações da Solicitação:
        <asp:textbox id="txt_OBS_Funcionario" class="form-control" whidth="100%" runat="server" textmode="MultiLine" backcolor="#EFEFEF"></asp:textbox>
        <br />
        <div class="row">   <div class="col-5"></div>
            <div class="col-2">
                <asp:button id="btnVoltar" runat="server" class="button"
                    text="Voltar" Width="80px" onclick="btnVoltar_Click" />
            </div>
             <div class="col-5"></div>
        </div>
    </div>
</asp:Content>

