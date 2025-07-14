<%@ Page Title="Atender Solicitação" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AtenderSolicitacao.old.aspx.cs" Inherits="adm_AtenderSolicitacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="pegaNomeLoginUsuario" runat="server" Text="" Visible="False"></asp:Label>
    <asp:Label ID="id_Chamado" runat="server" Text="Label" Visible="False"></asp:Label>
    <div class="row">
        <asp:CheckBox ID="CkbExibeRedeCorporativa" runat="server" AutoPostBack="True" Visible="False"></asp:CheckBox>
        <asp:CheckBox ID="ckbExibeSGH" runat="server" AutoPostBack="True" Visible="False"></asp:CheckBox>
        <asp:CheckBox ID="ckbExibeSimproc" runat="server" AutoPostBack="True" Visible="False"></asp:CheckBox>
        <asp:CheckBox ID="ckbExibeGrafica" runat="server" AutoPostBack="True" Visible="False"></asp:CheckBox>
        <asp:CheckBox ID="ckbExibeOSmanutencao" runat="server" AutoPostBack="True" Visible="False"></asp:CheckBox>
        <asp:CheckBox ID="ckbExibeSEI" runat="server" AutoPostBack="True" Visible="False"></asp:CheckBox>
    </div>
    <div class="container">
        <h4 class="text-center">Atender Solicitação </h4>
        <div class="row">
            <div class="col-4">
                Nome do funcionario:          
                 <asp:Label ID="txtNomeFuncionario" runat="server" class="form-control"></asp:Label>
            </div>
            <div class="col-2">
                RF:
                 <asp:Label ID="txtRF" runat="server" class="form-control"></asp:Label>
            </div>
            <div class="col-1.5">
                Login:
                 <asp:Label ID="txtLogin" runat="server" class="form-control"></asp:Label>
            </div>
            <div class="col-3">
                Cargo do funcionario:
                 <asp:Label ID="txtCargo" runat="server" class="form-control"></asp:Label>
            </div>
            <div class="col-1.5">
                E-mail do Coordenador:
                 <asp:Label ID="txtEmail" runat="server" class="form-control"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                Ramal:
                 <asp:Label ID="txtRamal" runat="server" class="form-control"></asp:Label>
            </div>
            <div class="col-4">
                Lotação:
                 <asp:Label ID="txtLotacao" runat="server" class="form-control"></asp:Label>
            </div>
            <div class="col-2">
                Data do Pedido:
                 <asp:Label ID="txtData" runat="server" class="form-control"></asp:Label>
            </div>
            <div class="col-4">
                Solicitante (Coordenador/Chefia):
                 <asp:Label ID="txtSolicitante" runat="server" class="form-control"></asp:Label>
            </div>
        </div>
        <br />
        <asp:Panel runat="server" ID="PanelRedeCorporativa" BorderStyle="Double" GroupingText="Rede Corporativa" Visible="False" Font-Italic="True">

            <div id="DivRedeCorporativa">
                <div class="row">
                    <div class="col-5">
                        <asp:RadioButton ID="rdAcesso" Text="Acesso&nbsp;" runat="server" GroupName="redeCorporativa1"></asp:RadioButton>
                        <asp:RadioButton ID="rdBloqueio" Text="Bloqueio&nbsp;" runat="server" GroupName="redeCorporativa1"></asp:RadioButton>
                        <asp:RadioButton ID="rdAtualizar" Text="Atualizar" runat="server" GroupName="redeCorporativa1"></asp:RadioButton>
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        <asp:CheckBox ID="CkbEmail" Text="E-mail Corporativo &nbsp;" runat="server"></asp:CheckBox>

                        <asp:CheckBox ID="CkbCaixaDepartamental" Text="Caixa Departamental" runat="server"></asp:CheckBox>
                    </div>
                    <div class="col-2.5">
                        <asp:CheckBox ID="CkbPastaRede" Text="Pasta de Rede (Especificar):" runat="server"></asp:CheckBox>
                    </div>
                    <div class="col-5">
                        <asp:TextBox ID="txtEspecificarRedeCorporativa" runat="server" class="form-control" BorderWidth="2"></asp:TextBox>
                    </div>
                </div>
                <div class="nav justify-content-center m-3">
                    <asp:Button ID="btnRedeCorporativa" runat="server" class="btn btn-outline-primary" Text="Finalizar Rede Corp."
                        Height="40px" Width="170px" OnClick="btnRedeCorporativa_Click" />
                </div>
            </div>
        </asp:Panel>
        <%--  SGH--%>
        <asp:Panel runat="server" ID="PanelSGH" BorderStyle="Double" GroupingText="SGH" Visible="False">
            <div id="DivSGH">
                <div class="row">
                    <div class="col-5">
                        <asp:Label runat="server" Text="SGH" Font-Bold="True" Font-Italic="True" ID="labelSGH" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        <asp:CheckBox ID="CkbSGHamb" Text="&nbsp; Ambulatório" runat="server"></asp:CheckBox>
                    </div>
                    <div class="col-3">
                        <asp:CheckBox ID="CkbCenCir" Text="&nbsp; Centro Cirurgico" runat="server"></asp:CheckBox>
                    </div>
                    <div class="col-3">
                        <asp:CheckBox ID="CkbSGHInternacao" Text="&nbsp; Internação" runat="server"></asp:CheckBox>
                    </div>
                    <div class="col-3">
                        <asp:CheckBox ID="CkbSGHprontoSocorro" Text="&nbsp; Pronto Socorro" runat="server"></asp:CheckBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        <asp:TextBox ID="txtSGHAmb" runat="server" class="form-control" BorderWidth="2"></asp:TextBox>
                    </div>
                    <div class="col-3">
                        <asp:TextBox ID="txtSGHcentroCirurgico" runat="server" class="form-control" BorderWidth="2"></asp:TextBox>
                    </div>
                    <div class="col-3">
                        <asp:TextBox ID="txtSGHInternacao" runat="server" class="form-control" BorderWidth="2"></asp:TextBox>
                    </div>
                    <div class="col-3">
                        <asp:TextBox ID="txtSGHProntoSocorro" runat="server" class="form-control" BorderWidth="2"></asp:TextBox>
                    </div>
                </div>
                <div class="nav justify-content-center m-3">
                    <asp:Button ID="bntSGH" runat="server" class="btn btn-outline-primary" Text="Finalizar SGH "
                        Height="40px" Width="170px" OnClick="bntSGH_Click" />
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="PanelSimproc" BorderStyle="Double" GroupingText="Simproc" Visible="False">
            <div id="DivSimproc">
                <div class="row">
                    <div class="col-2">
                        <asp:Label runat="server" ID="labelSimprocCodicoUnidade" Text="Código unidade"></asp:Label>
                        <asp:TextBox ID="txtSimprocCodigoUnidade" runat="server" class="form-control" BorderWidth="2"></asp:TextBox>
                    </div>
                    <div class="col-0.5">&nbsp;&nbsp;</div>
                    <div class="col-1.5">
                        <asp:Label runat="server" ID="labelSimprocCPF" Text="CPF"></asp:Label>
                        <asp:TextBox ID="txtSimprocCPF" runat="server" class="form-control" BorderWidth="2"></asp:TextBox>
                    </div>
                    <div class="col-0.5">&nbsp;&nbsp;</div>
                    <div class="col-1.5">
                        <asp:Label runat="server" ID="labelSimprocRG" Text="RG"></asp:Label>
                        <asp:TextBox ID="txtSimprocRG" runat="server" class="form-control" BorderWidth="2"></asp:TextBox>
                    </div>
                    <div class="col-0.5">&nbsp;&nbsp;</div>
                    <div class="col-1.5">
                        <asp:Label runat="server" ID="labelSimprocDataAdmissao" Text="Data Admissão"></asp:Label>
                        <asp:TextBox ID="txtDtAdmissao" runat="server" class="form-control" BorderWidth="2"></asp:TextBox>
                    </div>
                </div>
                <div class="nav justify-content-center m-3">
                    <asp:Button ID="btnSimproc" runat="server" class="btn btn-outline-primary" Text="Finalizar Simproc "
                        Height="40px" Width="170px" OnClick="btnSimproc_Click" />
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="PanelGrafica" BorderStyle="Double" GroupingText="Grafica" Visible="False">
            <div id="DivGrafica">
                <div class="row">
                    <div class="col-8">
                        <asp:CheckBoxList ID="CkbListGraficaSetor" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>Central&nbsp;&nbsp;</asp:ListItem>
                            <asp:ListItem>Grafica&nbsp;&nbsp;</asp:ListItem>
                            <asp:ListItem>Farmácia&nbsp;&nbsp;</asp:ListItem>
                            <asp:ListItem>SND&nbsp;&nbsp;</asp:ListItem>
                            <asp:ListItem>Manutenção&nbsp;&nbsp;</asp:ListItem>
                            <asp:ListItem>Mecanica&nbsp;&nbsp;</asp:ListItem>
                            <asp:ListItem> Estoque Laboratorio</asp:ListItem>
                        </asp:CheckBoxList>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-2">
                        <asp:Label runat="server" ID="labelNcentroCusto" Text="Nº Centro de Custo(s)"></asp:Label>
                    </div>
                    <div class="col-2">
                        <asp:Label runat="server" ID="labelGraficaCpf" Text="CPF:"></asp:Label>
                    </div>
                    <div class="col-1">
                        <asp:Label runat="server" ID="labelGraficaCota" Text="Cota:"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-2">
                    <asp:TextBox ID="txtNcentroDeCustoGrafica" runat="server" Width="160"></asp:TextBox>
                </div>
                <div class="col-2">
                    <asp:TextBox ID="txtCPFgrafica" runat="server" Width="150"></asp:TextBox>
                </div>
                <div class="col-5">
                    <asp:RadioButtonList ID="RblCota" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Diária&nbsp;&nbsp;</asp:ListItem>
                        <asp:ListItem>Semanal&nbsp;&nbsp;</asp:ListItem>
                        <asp:ListItem>Quizenal&nbsp;&nbsp;</asp:ListItem>
                        <asp:ListItem>Mensal</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="nav justify-content-center m-3">
                <asp:Button ID="btnGrafica" runat="server" class="btn btn-outline-primary" Text="Finalizar Grafica "
                    Height="40px" Width="170px" OnClick="btnGrafica_Click" />
            </div>
            <%--</div>--%>
        </asp:Panel>
        <asp:Panel runat="server" ID="PanelOsManutencao" BorderStyle="Double" GroupingText="OS-Manutencao" Visible="False">
            <div id="OsManutencao">
                <div class="row">
                    <div class="col-0.5">&nbsp;&nbsp;</div>
                    <div class="col-1.5">
                        <asp:Label runat="server" Text="&nbsp;Nº Centro de Custo(s)"></asp:Label>
                    </div>
                    <div class="col-0.5">
                        <asp:Label runat="server" Text="Novo:"></asp:Label>
                    </div>
                    <div class="col-2">
                        <asp:TextBox ID="txtCentroDeCustoOS_Manutencao" runat="server" Width="170"></asp:TextBox>
                    </div>
                    <div class="col-0.5">
                    </div>
                    <div class="col-0.5">
                        <asp:Label runat="server" Text="CPF:"></asp:Label>
                    </div>
                    <div class="col-1">
                        <asp:TextBox ID="txtCpfOS_Manutencao" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="nav justify-content-center m-3">
                    <asp:Button ID="btnOSmanutencao" runat="server" class="btn btn-outline-primary" Text="Finalizar Manutençâo "
                        Height="40px" Width="170px" OnClick="btnOSmanutencao_Click" />
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="PanelSEI" BorderStyle="Double" GroupingText="SEI" Visible="False">
            <div id="DivSei">
                <div class="row">
                    <div class="col-2">
                        Sigla da(s) Unidade(S):
                    </div>
                    <div class="col-0.5">1-</div>
                    <div class="col-1.5">
                        <asp:TextBox ID="txtSei_1" runat="server"></asp:TextBox>
                    </div>
                    &nbsp;
                <div class="col-0.5">2-</div>
                    <div class="col-1.5">
                        <asp:TextBox ID="txtSei_2" runat="server"></asp:TextBox>
                    </div>
                    &nbsp;
                <div class="col-0.5">3-</div>
                    <div class="col-1.5">
                        <asp:TextBox ID="txtSei_3" runat="server"></asp:TextBox>
                    </div>
                    &nbsp;
                <div class="col-0.5">4-</div>
                    <div class="col-1.5">
                        <asp:TextBox ID="txtSei_4" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="nav justify-content-center m-3">
                    <asp:Button ID="btnSei" runat="server" class="btn btn-outline-primary" Text="Finalizar SEI"
                        Height="40px" Width="170px" OnClick="btnSei_Click" />
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>

