<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Terceiros.aspx.cs" Inherits="funcionario_Terceiros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <script src="../js/jquery.js"></script>
    <script src="../js/jquery.mask.js"></script>
    <script src="../js/jquery-ui.js"></script>
    <link href="../js/jquery-ui.css" rel="stylesheet" />
 
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
        <asp:Label runat="server" ID="dtHoraExtrato" Text="" Visible="false"></asp:Label>
        <h4 class="text-center">Autorização de Acesso à Rede / SGH para Terceiros </h4>
        <asp:Label ID="LabelJaExiste" runat="server" Text="" Visible="False"></asp:Label>
        <asp:Label ID="pegaNomeLoginUsuario" runat="server" Text="" Visible="False"></asp:Label>
        <asp:Label runat="server" ID="labelIdChamado" Text="Label" Visible="False"></asp:Label>
        <asp:Label ID="LabelMais1" runat="server" Text="" Visible="False"></asp:Label>

        <div class="row">
            <%--  SGH--%>
            <div class="col-3">
                Nome: <span style="color: red;"> * </span>
                 <asp:TextBox ID="txtNomeFuncionario" runat="server" class="form-control" required="required" MaxLength="99"></asp:TextBox>
            </div>
            <asp:Label ID="emailCoordenador" runat="server" Text="" Visible="False"></asp:Label>
            <div class="col-2">
                RG:<span style="color: red;"> * </span>
                 <asp:TextBox ID="txtRG" runat="server" class="form-control" required="required" MaxLength="15"></asp:TextBox>
            </div>
            <div class="col-2">
                CPF: <span style="color: red;"> * </span>
                 <asp:TextBox ID="txtCPF" runat="server" class="form-control" required="required" MaxLength="15" onblur="validarCPF(this.value, this.id);"></asp:TextBox>
            </div>
            <div class="col-2">
                        <asp:Label id="labelAsterisco3" runat="server" Text="*" visible="false" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>                     

                Login:
                 <asp:TextBox ID="txtLogin" runat="server" class="form-control" MaxLength="10" placeholder=""></asp:TextBox>
            </div>
            <div class="col-3">
                Cargo: <span style="color: red;"> * </span>
                 <asp:TextBox ID="txtCargo" runat="server" class="form-control" required="required" MaxLength="99"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                Ramal-Chefia:
                 <asp:TextBox ID="txtRamal" runat="server" class="form-control" MaxLength="19"></asp:TextBox>
            </div>
            <div class="col-2">
                Ramal-Funcionário:
                 <asp:TextBox ID="txtRamal_2" runat="server" class="form-control" MaxLength="19"></asp:TextBox>
            </div>
            <div class="col-3">
                Lotação:
                 <asp:TextBox ID="txtLotacao" runat="server" class="form-control" MaxLength="99" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-2">
                Data do Pedido:
                 <asp:TextBox ID="txtData" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-3">
                Solicitante:
                 <asp:TextBox ID="txtSolicitante" runat="server" class="form-control" MaxLength="99" ReadOnly="True"></asp:TextBox>
            </div>
            <%-- <asp:DropDownList ID="DdlHenrique" runat="server" AutoPostBack="True">
                <asp:ListItem>Selecione</asp:ListItem>
                <asp:ListItem>henrique</asp:ListItem>
                <asp:ListItem>junior</asp:ListItem>
            </asp:DropDownList>--%>
        </div>
        <br />
        <div class="row m-0">
            <div class="col-1.5">
                <asp:CheckBox ID="CkbExibeRedeCorporativa" runat="server" AutoPostBack="True" class="form-control" Text="&nbsp;Rede Corporativa &nbsp; " Width="200px" BorderWidth="2"></asp:CheckBox>
            </div>
            <div class="col-1.5">
                <asp:CheckBox ID="ckbExibeSGH" runat="server" AutoPostBack="True" Text="&nbsp;SGH &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" Width="200px" class="form-control" BorderWidth="2"></asp:CheckBox>
            </div>
            <div class="col-1.5">                 
                <asp:CheckBox ID="ckbExibeOSmanutencao" runat="server" AutoPostBack="True" class="form-control" Text="&nbsp;OS-Manutenção &nbsp;&nbsp;" Width="182px" BorderWidth="2"></asp:CheckBox>                            
            </div>
            <div class="col-2"></div> 
            <div class="col-1.5">
                <asp:Label runat="server" ID="labelNomeEmpresaAviso" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Selecione a empresa:"></asp:Label>
            </div>
            <div class="col-1.5">
                <asp:DropDownList ID="ddlEmpresTerceiros" runat="server" DataSourceID="SqlDataSource1" DataTextField="descricao_empresaTerceira" DataValueField="descricao_empresaTerceira" class="form-control"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SolicitaAcessoConnectionString %>" SelectCommand="SELECT [descricao_empresaTerceira] FROM [EmpresaTerceira]"></asp:SqlDataSource>
            </div>
            <%--      <div class="col-3">
                <asp:checkbox id="CkbExibeDadosComplementaresSGH" runat="server" autopostback="True" class="form-control" text="&nbsp;Dados complementares/SGH" width="260px" borderwidth="2"></asp:checkbox>

            </div>--%>
        </div>
        <br />
        <asp:Panel runat="server" ID="PanelRedeCorporativa" BorderStyle="Double" Visible="False" Font-Italic="True">
            <h4 class="text-center">Rede Corporativa</h4>
            <div id="DivRedeCorporativa">
                <div class="row m-0">
                    <div class="col-10">
                        <asp:Label id="labelAsterisco" runat="server" Text="*" visible="false" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                        <asp:RadioButton ID="rdAcesso" Text="Acesso (Solicitar login de rede) &nbsp &nbsp" runat="server" GroupName="redeCorporativa1" AutoPostBack="True"></asp:RadioButton>
                        <asp:Label id="labelAsterisco1" runat="server" Text="*" visible="false" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>                       
                        <asp:RadioButton ID="rdAtualizar" Text="Atualizar (já possui login de rede) &nbsp &nbsp" runat="server" GroupName="redeCorporativa1" AutoPostBack="True"></asp:RadioButton>
                        <asp:Label id="labelAsterisco2" runat="server" Text="*" visible="false" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>                      
                        <asp:RadioButton ID="rdBloqueio" Text="Bloqueio" runat="server" GroupName="redeCorporativa1" AutoPostBack="True"></asp:RadioButton>
                    </div>
                </div>

                <div class="row m-2">
                    <div class="col-3">
                        <asp:CheckBox ID="CkbPastaRede" Text="Pasta de Rede:" runat="server" AutoPostBack="True"></asp:CheckBox>
                    </div>
                    <div class="col-2">
                        <asp:RadioButton ID="rdbNovoRedeCorporativaPasta" Text="Nova" runat="server" GroupName="redeCorporativaNovoPasta" AutoPostBack="True" Checked="True"></asp:RadioButton>
                        <asp:RadioButton ID="rdbExistenteRedeCorporativaPasta" Text="Existente" runat="server" GroupName="redeCorporativaNovoPasta" AutoPostBack="True"></asp:RadioButton>
                    </div>
                    <div class="col-5">
                        <asp:TextBox ID="txtEspecificarRedeCorporativa" runat="server" class="form-control" BorderWidth="2" placeholder="**escreva aqui o nome completo da pasta de rede**" required="required" MaxLength="250"></asp:TextBox>
                    </div>
                </div>
                   <div class="row m-2">
                       <div class="col-2">
                        <asp:CheckBox ID="CkbLoginBloqueio" Text="Login de rede" runat="server" Visible="false"></asp:CheckBox>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <%--  SGH--%>
        <asp:Panel runat="server" ID="PanelSGH" BorderStyle="Double" Visible="False">
            <h4 class="text-center">SGH</h4>
            <div id="DivSGH">
                <%-- <div class="col-5">
                        <asp:Label runat="server" Text="SGH" Font-Bold="True" Font-Italic="True" ID="labelSGH" Visible="False"></asp:Label>
                    </div>--%>
                <div class="row m-2">
                    <div class="col-2.5">
                        <asp:RadioButton ID="RdbNaoTemSGH" Text="&nbsp;Não tem Cadastro no SGH" runat="server" GroupName="DadosComp" Checked="True" AutoPostBack="True"></asp:RadioButton>

                    </div>
                    <div class="col-3">
                        <asp:RadioButton ID="RdbJaTemSGH" Text="&nbsp;Já tem Cadastro no SGH" runat="server" GroupName="DadosComp" AutoPostBack="True"></asp:RadioButton>

                    </div>
                </div>


                <div class="row m-1">
                    <div class="col-6">
                        <asp:CheckBox ID="CkbSGHamb" Text="&nbsp; Ambulatório" runat="server" AutoPostBack="True"></asp:CheckBox>
                        <asp:TextBox ID="txtSGHAmb" runat="server" class="form-control" BorderWidth="2" placeholder="** Ex: Medico, ADM, (consultas, marcar, estornar, Visualizar)**" required="required" MaxLength="99"></asp:TextBox>
                    </div>
                    <div class="col-6">
                        <asp:CheckBox ID="CkbCenCir" Text="&nbsp; Centro Cirúrgico" runat="server" AutoPostBack="True"></asp:CheckBox>
                        <asp:TextBox ID="txtSGHcentroCirurgico" runat="server" class="form-control" BorderWidth="2" placeholder="**Ex: Medico, ADM, Visualizar Cirurgias do dia**" required="required" MaxLength="99"></asp:TextBox>
                    </div>
                </div>
                <div class="row m-1">
                    <div class="col-6">
                        <asp:CheckBox ID="CkbSGHInternacao" Text="&nbsp; Internação" runat="server" AutoPostBack="True"></asp:CheckBox>
                        <asp:TextBox ID="txtSGHInternacao" runat="server" class="form-control" BorderWidth="2" placeholder="** Ex: Internar, Movimentar paciente, estorno de alta etc...**" required="required" MaxLength="99"></asp:TextBox>
                    </div>
                    <div class="col-6">
                        <asp:CheckBox ID="CkbSGHprontoSocorro" Text="&nbsp; Pronto Socorro" runat="server" AutoPostBack="True"></asp:CheckBox>
                        <asp:TextBox ID="txtSGHProntoSocorro" runat="server" class="form-control" BorderWidth="2" placeholder="**Ex: Medico, ADM **" required="required" MaxLength="99"></asp:TextBox>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="PanelDadosComplementares" BorderStyle="Double" Visible="False">
            <h4 class="text-center">Dados Complementares SGH</h4>
            <div id="DivDadosComplementares">
                <div class="row m-1">
                    <div class="col-2">
                        Data de Nascimento: 
                        <asp:TextBox ID="txtDadosCompDataNascimento" runat="server" class="form-control" Width="100%" required="required"></asp:TextBox>
                    </div>
                    <div class="col-4">
                        Nome da Mãe: 
                        <asp:TextBox ID="txtDAdosCompNomeDaMae" runat="server" class="form-control" Width="100%" required="required" MaxLength="100"></asp:TextBox>
                    </div>
                    <div class="col-2">
                        CRM/COREN:  
                        <asp:TextBox ID="txtDadosCompCRM" runat="server" class="form-control" Width="100%" MaxLength="10"></asp:TextBox>
                    </div>
                    <%--  <div class="col-2">
                        CPF:
                        <asp:TextBox ID="txtDadosCompCPF" runat="server" class="form-control" Width="100%" required="required"></asp:TextBox>
                    </div>
                    <%--    &nbsp;--%>

                    <%-- <div class="col-2">
                        RG:
                        <asp:TextBox ID="txtDadosCompRG" runat="server" class="form-control" Width="90%" required="required" MaxLength="20"></asp:TextBox>
                     </div> --%>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="PanelOsManutencao" BorderStyle="Double" Visible="False">
            <h4 class="text-center">OS-Manutenção</h4>
            <div id="OsManutencao">
                <div class="row m-1">
                    <div class="col-3">
                        Nº Centro de Custo(s) Novo:
                        <asp:TextBox ID="txtCentroDeCustoOS_Manutencao_Novo" runat="server" class="form-control" Width="200" MaxLength="50" required="required"></asp:TextBox>
                    </div>
                    <div class="col-3">
                        Nº Centro de Custo(s) Antigo:
                        <asp:TextBox ID="txtCentroDeCustoOS_Manutencao_Antigo" runat="server" class="form-control" Width="200" MaxLength="50"></asp:TextBox>
                    </div>
                 <%--   <div class="col-2">
                        CPF:
                        <asp:TextBox ID="txtCpfOS_Manutencao" runat="server" class="form-control" Width="200" required="required" onblur="validarCPF(this.value, this.id);"></asp:TextBox>
                    </div>--%>
                </div>
            </div>
        </asp:Panel>

         <div class="row m-1">
            <div class="col-9">
                <asp:Label ID="Label_txtObs_Geral" runat="server" Text="Observação geral: (não é obrigatório)" Visible="false"></asp:Label>
            </div>
            <div class="col-3">
                <asp:Label ID="lblCharCount" runat="server" Text="500 caracteres restantes" Visible="false"></asp:Label>
            </div>
        </div>
        <div class="row m-1">
            <asp:TextBox ID="txtObs_Geral" runat="server" class="form-control" Width="100%" Visible="false" TextMode="MultiLine" onkeyup="updateCharCount(this)" onkeydown="limitText(this, event)" BorderWidth="2"></asp:TextBox>
        </div>
    </div>

    <div class="nav justify-content-center m-4">
        <asp:Button ID="btnCadastrar" runat="server" class="btn btn-outline-primary" Text="Finalizar Solicitação"
            Height="40px" Width="160px" OnClick="btnCadastrar_Click" />
    </div>

    <script src="js/jquery.mask.js"></script>
    <script type="text/javascript">      
        $('#<%=txtDadosCompDataNascimento.ClientID %>').mask("99/99/9999");
        $('#<%=txtCPF.ClientID %>').mask("999.999.999-99");
        <%-- $('#<%=txtCpfOS_Manutencao.ClientID %>').mask("999.999.999-99");--%>
    </script>


    <script type="text/javascript"> 
        function validarCPF(cpf, clienteID) {
            cpf = cpf.replace(/[^\d]+/g, '');

            if (cpf.length !== 11 || /^(?:\d)\1+$/.test(cpf)) {
                alert("CPF inválido!");
                document.getElementById(clienteID).value = "";
                return false;
            }

            var numeros = cpf.split('').map(Number);
            var soma = 0;

            for (var i = 0; i < 9; i++) {
                soma += numeros[i] * (10 - i);
            }

            var resto = (soma * 10) % 11;
            if (resto === 10 || resto === 11) {
                resto = 0;
            }

            if (resto !== numeros[9]) {
                alert("CPF inválido!");
                document.getElementById(clienteID).value = "";
                return false;
            }

            soma = 0;
            for (var i = 0; i < 10; i++) {
                soma += numeros[i] * (11 - i);
            }

            resto = (soma * 10) % 11;
            if (resto === 10 || resto === 11) {
                resto = 0;
            }

            if (resto !== numeros[10]) {
                alert("CPF inválido!");
                document.getElementById(clienteID).value = "";
                return false;
            }

            return true;
        }
    </script>

    <script type="text/javascript">
    function updateCharCount(textbox) {
        var maxLength = 500;
        var currentLength = textbox.value.length;
        var remaining = maxLength - currentLength;
        document.getElementById('<%= lblCharCount.ClientID %>').innerText = remaining + " caracteres restantes";
    }

    function limitText(textbox, e) {
        var maxLength = 500;
        if (textbox.value.length >= maxLength) {
            var allowedKeys = ["Backspace", "Delete", "ArrowLeft", "ArrowRight", "ArrowUp", "ArrowDown", "Enter"];
            if (!allowedKeys.includes(e.key)) {
                e.preventDefault();
            }
        }
    }

    window.onload = function() {
        var textbox = document.getElementById('<%= txtObs_Geral.ClientID %>');
        updateCharCount(textbox);
    };
</script>
        <script type="text/javascript">
    window.onload = function() {
        var usuario = '<%= Session["login"] != null ? Session["login"].ToString() : "" %>';

        if (usuario === "") {
            alert("Sessão expirada. Você será redirecionado para o login.");
            window.location.href = "../login.aspx";
        }
    }
</script>
</asp:Content>

