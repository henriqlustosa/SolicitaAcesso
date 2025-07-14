<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Solicitar.old.aspx.cs" Inherits="Solicitar" %>

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
        <h4 class="text-center">Autorização de Acesso à Rede e Sistemas HSPM </h4>
        <asp:label id="pegaNomeLoginUsuario" runat="server" text="" visible="False"></asp:label>
        <asp:label runat="server" id="labelIdChamado" text="Label" visible="False"></asp:label>
        <script type="text/javascript">
            function mostraRedeCorporativa() {

                var div = document.getElementById('DivRedeCorporativa');

                if (div.style.display == 'none') {
                    div.style.display = 'block';
                }
                else {
                    div.style.display = 'none';
                }
            }
        </script>
        <script type="text/javascript">
            function mostraSGH() {

                var div = document.getElementById('DivSGH');

                if (div.style.display == 'none') {
                    div.style.display = 'block';
                }
                else {
                    div.style.display = 'none';
                }
            }
        </script>

        <div class="row">
            <%--  <div class="col-1">
                <asp:Label ID="Label10" runat="server" class="col-form-label" Text="Nome:"></asp:Label>
            </div>--%>
            <div class="col-4">
                Nome:
                 <asp:textbox id="txtNomeFuncionario" runat="server" class="form-control"></asp:textbox>
            </div>
            <div class="col-3">
                RF:
                 <asp:textbox id="txtRF" runat="server" class="form-control"></asp:textbox>
            </div>
            <div class="col-2">
                Login:
                 <asp:textbox id="txtLogin" runat="server" class="form-control"></asp:textbox>
            </div>
            <div class="col-3">
                Cargo:
                 <asp:textbox id="txtCargo" runat="server" class="form-control"></asp:textbox>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                Ramal:
                 <asp:textbox id="txtRamal" runat="server" class="form-control"></asp:textbox>
            </div>
            <div class="col-4">
                Lotação:
                 <asp:textbox id="txtLotacao" runat="server" class="form-control"></asp:textbox>
            </div>
            <div class="col-2">
                Data do Pedido:
                 <asp:textbox id="txtData" runat="server" class="form-control"></asp:textbox>
            </div>
            <div class="col-4">
                Solicitante:
                 <asp:textbox id="txtSolicitante" runat="server" class="form-control"></asp:textbox>
            </div>
        </div>
        <br />
        <div class="nav justify-content-md-center">
            <input id="BtnRedeCorporativa" type="button" value="Solicitar Acesso a Rede Corporativa" onclick="mostraRedeCorporativa()" class="btn btn-outline-info btn-block" />
        </div> 
      <%--  <br />--%>
        <div id="DivRedeCorporativa" style='display: none;'>
            <hr />
            <%--<h4 class="text-center">
            Alta Paciente Pagina Unica</h4>--%>
            <div class="row">
                <div class="col-5">
                    <asp:checkbox id="CkbRedeCorporativa" runat="server" AutoPostBack="True"></asp:checkbox>
                    Rede Corporativa &nbsp;&nbsp;&nbsp;&nbsp;                  
                     (      
                    <asp:radiobutton id="rdAcesso" runat="server" groupname="redeCorporativa"></asp:radiobutton>
                    Acesso
                    <asp:radiobutton id="rdBloqueio" runat="server" groupname="redeCorporativa"></asp:radiobutton>
                    Bloquei
                    <asp:radiobutton id="rdAtualizar" runat="server" groupname="redeCorporativa"></asp:radiobutton>
                    Atualizar )
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-4">
                    <asp:checkbox id="CkbEmail" runat="server"></asp:checkbox>
                    E-mail Corporativo &nbsp;
                      <asp:checkbox id="CkbCaixaDepartamental" runat="server"></asp:checkbox>
                    Caixa Departamental &nbsp;                  
                </div>
                <div class="col-2.5">
                    <asp:checkbox id="CkbPastaRede" runat="server"></asp:checkbox>
                    Pasta de Rede (Especificar):
                </div>
                <div class="col-5">
                    <asp:textbox id="txtEspecificarRedeCorporativa" runat="server" class="form-control align-self-sm-start"></asp:textbox>
                </div>
            </div>
            <hr />
        </div>
        <br />
        <%--  SGH--%>
        <div class="nav justify-content-md-center">
            <input id="Button3" type="button" value="Solicitar Acesso ao SGH" onclick="mostraSGH()" class="btn btn-outline-info  btn-block" />
        </div>
        <div id="DivSGH" style='display: none;'>
            <%--<h4 class="text-center">
            Alta Paciente Pagina Unica</h4>--%>
            <br />
            <div class="row">
                <div class="col-3">
                    <asp:checkbox id="CkbSGHamb" runat="server"></asp:checkbox>
                    <asp:label runat="server" text=" Ambulatório"></asp:label>
                </div>
                <div class="col-3">
                    <asp:checkbox id="CkbSGH" runat="server"></asp:checkbox>
                    <asp:label runat="server" text=" Centro Cirurgico"></asp:label>

                </div>
                <div class="col-3">
                    <asp:checkbox id="CkbSGHInternacao" runat="server"></asp:checkbox>
                    <asp:label runat="server" text=" Internação"></asp:label>

                </div>
                <div class="col-3">
                    <asp:checkbox id="CkbSGHprontoSocorro" runat="server"></asp:checkbox>
                    <asp:label runat="server" text="Pronto Socorro"></asp:label>

                </div>
            </div>
            <div class="row">
                <div class="col-3">
                    <asp:textbox id="txtSGHAmb" runat="server" class="form-control"></asp:textbox>
                </div>
                <div class="col-3">
                    <asp:textbox id="txtSGHcentroCirurgico" runat="server" class="form-control"></asp:textbox>

                </div>
                <div class="col-3">
                    <asp:textbox id="txtInternacao" runat="server" class="form-control"></asp:textbox>
                </div>
                <div class="col-3">
                    <asp:textbox id="txtProntoSocorro" runat="server" class="form-control"></asp:textbox>
                </div>
            </div>
            <br />
        </div>
        <br />
        <!-- fazer aqui o procedimento-->

        <script type="text/javascript">
            function mostraSimproc() {

                var div = document.getElementById('DivSimproc');

                if (div.style.display == 'none') {
                    div.style.display = 'block';
                }
                else {
                    div.style.display = 'none';
                }
            }
        </script>

        <div class="nav justify-content-md-center">
            <input id="Button2" type="button" value="Solicitar Acesso Simproc" onclick="mostraSimproc()" class="btn btn-outline-info btn-block text-uppercase" />
        </div>
        <div id="DivSimproc" style='display: none;'>
            <hr />
            <div class="row">
                <div class="col-2">
                    <asp:checkbox id="CkbSimproc" runat="server"></asp:checkbox>
                    Simproc
                </div>
                <div class="col-1.5">
                    <asp:label runat="server" text="Código unidade"></asp:label>
                    <asp:textbox id="txtSimprocCodigoUnidade" runat="server" class="form-control"></asp:textbox>
                </div>
                <div class="col-0.5">&nbsp;&nbsp;</div>
                <div class="col-1.5">
                    <asp:label runat="server" text="CPF"></asp:label>
                    <asp:textbox id="txtSimprocCPF" runat="server" class="form-control"></asp:textbox>
                </div>
                <div class="col-0.5">&nbsp;&nbsp;</div>
                <div class="col-1.5">
                    <asp:label runat="server" text="RG"></asp:label>
                    <asp:textbox id="txtSimprocRG" runat="server" class="form-control"></asp:textbox>
                </div>
                <div class="col-0.5">&nbsp;&nbsp;</div>
                <div class="col-1.5">
                    <asp:label runat="server" text="Data Admissão"></asp:label>
                    <asp:textbox id="txtDtAdmissao" runat="server" class="form-control"></asp:textbox>
                </div>
            </div>
            <hr />
        </div>
        <br />

        <script type="text/javascript">
            function mostraGrafica() {

                var div = document.getElementById('DivGrafica');

                if (div.style.display == 'none') {
                    div.style.display = 'block';
                }
                else {
                    div.style.display = 'none';
                }
            }
        </script>
        <div class="nav justify-content-md-center">
            <input id="Button1" type="button" value="SOLICITAR ACESSO A GRAFICA" onclick="mostraGrafica()" class="btn btn-outline-info btn-block" />
        </div>
        <div id="DivGrafica" style='display: none;'>
            <!-- bloco cadastrar cid-->
            <%--border border-dark rounded col-12--%>
            <hr />
            <div class="row">
                <div class="col-3">
                    <asp:checkbox id="ckbSolicitaGrafica" runat="server"></asp:checkbox>
                    <asp:label runat="server" text="Solicitar Grafica"></asp:label>
                </div>
                <div class="col-2">
                    <asp:checkbox id="ckbCentral" runat="server"></asp:checkbox>
                    <asp:label runat="server" text=" Central "></asp:label>
                </div>
                <div class="col-2">
                    <asp:checkbox id="ckbGrafica" runat="server"></asp:checkbox>
                    <asp:label runat="server" text=" Grafica"></asp:label>
                </div>
                <div class="col-2">
                    <asp:checkbox id="ckbfarmacia" runat="server"></asp:checkbox>
                    <asp:label runat="server" text=" Farmácia"></asp:label>
                </div>
                <div class="col-2">
                    <asp:checkbox id="ckbSND" runat="server"></asp:checkbox>
                    <asp:label runat="server" text=" SND"></asp:label>
                </div>
            </div>
            <div class="row">
                <div class="col-3"></div>
                <div class="col-2">
                    <asp:checkbox id="ckbManutencao" runat="server"></asp:checkbox>
                    <asp:label runat="server" text=" Manutenção"></asp:label>
                </div>
                <div class="col-2">
                    <asp:checkbox id="ckbMecanica" runat="server"></asp:checkbox>
                    <asp:label runat="server" text=" Mecanica"></asp:label>
                </div>
                <div class="col-3">
                    <asp:checkbox id="ckbEstoqueLab" runat="server"></asp:checkbox>
                    <asp:label runat="server" text=" Estoque Laboratorio"></asp:label>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-2">
                    <asp:label runat="server" text="Nº Centro de Custo(s)"></asp:label>
                </div>
                <div class="col-0.5">
                    <asp:label runat="server" text="Novo:"></asp:label>
                </div>
                <div class="col-2">
                    <asp:textbox id="txtNcentroDeCustoGrafica" runat="server"></asp:textbox>
                </div>
                <div class="col-1">
                </div>
                <div class="col-0.5">
                    <asp:label runat="server" text="CPF:"></asp:label>
                </div>
                <div class="col-1">
                    <asp:textbox id="txtCPFgrafica" runat="server"></asp:textbox>
                </div>
            </div>
            <hr />
            <div class="row">

                <div class="col-1">
                    Cota:
                </div>
                <div class="col-2">
                    <asp:radiobutton id="rdbDiaria" text="&nbspDiária" runat="server" groupname="cotaGrafica"></asp:radiobutton>
                </div>
                <div class="col-2">
                    <asp:radiobutton id="rdbSemanal" text="&nbspSemanal" runat="server" groupname="cotaGrafica"></asp:radiobutton>
                </div>
                <div class="col-2">
                    <asp:radiobutton id="rdbQuinzenal" text="&nbspQuinzenal" runat="server" groupname="cotaGrafica"></asp:radiobutton>
                </div>
                <div class="col-2">
                    <asp:radiobutton id="rdbMensal" text="&nbspMensal" runat="server" groupname="cotaGrafica"></asp:radiobutton>
                </div>
            </div>
        </div>
        <br />
        <!-- Causa da Morte-->

        <script type="text/javascript">
            function mostraOsManutencao() {

                var div = document.getElementById('OsManutencao');

                if (div.style.display == 'none') {
                    div.style.display = 'block';

                }
                else {
                    div.style.display = 'none';
                }
            }
        </script>

        <div class="nav justify-content-md-center">
            <input id="Button4" type="button" value="SOLICITAR ACESSO OS-MANUTENÇÃO" onclick="mostraOsManutencao()" class="btn btn-outline-info btn-block" />
        </div>
        <div id="OsManutencao" style='display: none;'>
            <hr />
            <div class="row">
                <div class="col-2">
                    <asp:checkbox id="ckbOSmanutencao" runat="server"></asp:checkbox>
                    OS-Manutenção
                </div>
                <div class="col-2">
                    <asp:label runat="server" text="Nº Centro de Custo(s)"></asp:label>
                </div>
                <div class="col-0.5">
                    <asp:label runat="server" text="Novo:"></asp:label>
                </div>
                <div class="col-2">
                    <asp:textbox id="txtCentroDeCustoOS_Manutencao" runat="server"></asp:textbox>
                </div>
                <div class="col-1">
                </div>
                <div class="col-0.5">
                    <asp:label runat="server" text="CPF:"></asp:label>
                </div>
                <div class="col-1">
                    <asp:textbox id="txtCpfOS_Manutencao" runat="server"></asp:textbox>
                </div>
            </div>

        </div>
        <br />

        <script type="text/javascript">
            function mostraDivSei() {

                var div = document.getElementById('DivSei');

                if (div.style.display == 'none') {
                    div.style.display = 'block';
                }
                else {
                    div.style.display = 'none';
                }
            }
        </script>
        <div class="nav justify-content-md-center">
            <input id="Button5" type="button" value="SOLICITAR ACESSO SEI" onclick="mostraDivSei()" class="btn btn-outline-info btn-block" />
        </div>
        <div id="DivSei" style='display: none;'>
            <hr />
            <div class="row">
                <div class="col-0.5">
                    <asp:checkbox id="ckbSei" runat="server"></asp:checkbox>
                    SEI
                </div>
                <div class="col-2">
                    Sigla da(s) Unidade(S):
                </div>
                <div class="col-0.5">1-</div>
                <div class="col-1.5">
                    <asp:textbox id="txtSei_1" runat="server"></asp:textbox>
                </div>
                <div class="col-0.5">2-</div>
                <div class="col-1.5">
                    <asp:textbox id="txtSei_2" runat="server"></asp:textbox>
                </div>
                 <div class="col-0.5">3-</div>
                <div class="col-1.5">
                    <asp:textbox id="txtSei_3" runat="server"></asp:textbox>
                </div>
                  <div class="col-0.5">4-</div>
                <div class="col-1.5">
                    <asp:textbox id="txtSei_4" runat="server"></asp:textbox>
                </div>
            </div>
        </div>    

    <div class="nav justify-content-center m-4">
        <asp:button id="btnCadastrar" runat="server" class="btn btn-outline-primary" text="Cadastrar"
            height="40px" width="91px" OnClick="btnCadastrar_Click" />
    </div>
    </div>

</asp:Content>

