<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Solicitar.aspx.cs" Inherits="Solicitar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <script src="js/jquery.js"></script>
    <script src="js/jquery.mask.js"></script>
    <script src="js/jquery-ui.js"></script>
    <link href="js/jquery-ui.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        window.document.onkeydown = CheckEnter;
        function CheckEnter() {
            if (event.keyCode == 13)
                return false;
            return true;
        }
    </script>
    <div class="container">
        <h4 class="text-center">Solicitação de Acesso à Rede e Sistemas HSPM </h4>
                <asp:Label ID="LabelJaExiste" runat="server" Text="" Visible="False"></asp:Label>
        <asp:Label ID="pegaNomeLoginUsuario" runat="server" Text="" Visible="False"></asp:Label>
        <asp:Label runat="server" ID="labelIdChamado" Text="Label" Visible="False"></asp:Label>
        <div class="row">
            <%--  SGH--%>
            <div class="col-4">
                Nome:
                 <asp:TextBox ID="txtNomeFuncionario" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-3">
                RF:
                 <asp:TextBox ID="txtRF" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-2">
                Login:
                 <asp:TextBox ID="txtLogin" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-3">
                Cargo:
                 <asp:TextBox ID="txtCargo" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                Ramal:
                 <asp:TextBox ID="txtRamal" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-4">
                Lotação:
                 <asp:TextBox ID="txtLotacao" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-2">
                Data do Pedido:
                 <asp:TextBox ID="txtData" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-4">
                Solicitante:
                 <asp:TextBox ID="txtSolicitante" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-2">
                <asp:CheckBox ID="CkbRedeCorporativa" runat="server" AutoPostBack="True" class="form-control" Text="&nbsp;Rede Corporativa &nbsp; " Width="180px" BorderWidth="2"></asp:CheckBox>
            </div>
            <div class="col-2">
                <asp:CheckBox ID="ckbSGHexibe" runat="server" AutoPostBack="True" Text="&nbsp;SGH &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Width="180px" class="form-control" BorderWidth="2"></asp:CheckBox>
            </div>
            <div class="col-2">
                <asp:CheckBox ID="ckbExibeSimproc" runat="server" AutoPostBack="True" class="form-control" Text="&nbsp;Simproc &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Width="180px" BorderWidth="2"></asp:CheckBox>
            </div>

            <div class="col-2">
                <asp:CheckBox ID="ckbExibeGrafica" runat="server" AutoPostBack="True" class="form-control" Text="&nbsp;Grafica &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Width="180px" BorderWidth="2"></asp:CheckBox>

            </div>
            <div class="col-2">
                <asp:CheckBox ID="ckbOSmanutencao" runat="server" AutoPostBack="True" class="form-control" Text="&nbsp;OS-Manutenção &nbsp;&nbsp;" Width="180px" BorderWidth="2"></asp:CheckBox>

            </div>
            <div class="col-2">
                <asp:CheckBox ID="ckbSEI" runat="server" AutoPostBack="True" class="form-control" Text="&nbsp;SEI &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Width="160px" BorderWidth="2"></asp:CheckBox>

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
            </div>
        </asp:Panel>
        
        <asp:Panel runat="server" ID="PanelGrafica" BorderStyle="Double" GroupingText="Grafica" Visible="False">
            <div id="DivGrafica">
                <div class="row">                 
                    <div class="col-1">
                        <asp:CheckBox ID="ckbCentral" Text=" Central" runat="server"></asp:CheckBox>
                    </div>
                    <div class="col-1">
                        <asp:CheckBox ID="ckbGrafica" Text=" Grafica" runat="server"></asp:CheckBox>
                    </div>
                    <div class="col-1.5">
                        <asp:CheckBox ID="ckbfarmacia" Text="Farmácia" runat="server"></asp:CheckBox>
                    </div>
                    <div class="col-1">
                        <asp:CheckBox ID="ckbSND" Text=" SND" runat="server"></asp:CheckBox>
                    </div>              
                    
                    <div class="col-1.5">
                        <asp:CheckBox ID="ckbManutencao" Text=" Manutenção" runat="server" Width="120"></asp:CheckBox>
                    </div>
                    <div class="col-1.5">
                        <asp:CheckBox ID="ckbMecanica" Text=" Mecanica" runat="server" Width="110"></asp:CheckBox>

                    </div>
                    <div class="col-2">
                        <asp:CheckBox ID="ckbEstoqueLab" Text=" Estoque Laboratorio" runat="server"></asp:CheckBox>

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
                    <%--<div class="col-0.5">
                        <asp:Label runat="server" ID="labelnovoGrafica" Text="Novo:"></asp:Label>
                    </div>--%>
                <div class="row">
                    <div class="col-2">
                        <asp:TextBox ID="txtNcentroDeCustoGrafica" runat="server" Width="160"></asp:TextBox>
                    </div>
                   <%-- <div class="col-1">
                    </div>--%>
                  <%--  <div class="col-0.5">
                        <asp:Label runat="server" ID="labelGraficaCpf" Text="CPF:"></asp:Label>
                    </div>--%>
                    <div class="col-2">
                        <asp:TextBox ID="txtCPFgrafica" runat="server" Width="150"></asp:TextBox>
                    </div>
                <%--</div>--%>
            <%--    <hr />
                <div class="row">--%>

                  <%--  <div class="col-1">
                        <asp:Label runat="server" ID="labelGraficaCota" Text="Cota:"></asp:Label>
                    </div>--%>
                    <div class="col-1">
                        <asp:RadioButton ID="rdbDiaria" Text="&nbspDiária" runat="server" GroupName="cotaGrafica" Width="150"></asp:RadioButton>
                    </div>
                    <div class="col-1.5">
                        <asp:RadioButton ID="rdbSemanal" Text="&nbspSemanal" runat="server" GroupName="cotaGrafica" Width="100"></asp:RadioButton>
                    </div>
                    <div class="col-1.5">
                        <asp:RadioButton ID="rdbQuinzenal" Text="&nbspQuinzenal" runat="server" GroupName="cotaGrafica" Width="100"></asp:RadioButton>
                    </div>
                    <div class="col-1.5">
                        <asp:RadioButton ID="rdbMensal" Text="&nbspMensal" runat="server" GroupName="cotaGrafica"></asp:RadioButton>
                    </div>
                </div>
            </div>
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
        </div>
            </asp:Panel>

        <div class="nav justify-content-center m-4">
            <asp:Button ID="btnCadastrar" runat="server" class="btn btn-outline-primary" Text="Cadastrar"
                Height="40px" Width="91px" OnClick="btnCadastrar_Click" />
        </div>
    </div>

</asp:Content>

