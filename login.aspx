<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>
<html>
<head>
    <title>Autoriza Acesso</title>
    
    
    <link href="css/login.css?v=4" rel="stylesheet" />
    <style>
.modal-overlay {
    display: none;
    position: fixed;
    z-index: 9999;
    left: 0;
    top: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.6);
}

.modal-content {
    background-color: #fff;
    padding: 30px;
    border-radius: 8px;
    width: 90%;
    max-width: 500px;
    margin: 10% auto;
    box-shadow: 0 0 10px rgba(0,0,0,0.25);
    text-align: left;
    font-family: Arial, sans-serif;
}

.modal-content h2 {
    margin-top: 0;
}

.modal-content button {
    margin-top: 20px;
    padding: 8px 16px;
    background-color: #007bff;
    color: #fff;
    border: none;
    border-radius: 4px;
    cursor: pointer;
}

.modal-content button:hover {
    background-color: #0056b3;
}
</style>

  <%--  <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>--%>
    <script src="js/jquery-3.6.0.min.js"></script>
<%--<script>
    $(document).ready(function () {
        // Verifica se já foi exibido na sessão
        if (!sessionStorage.getItem("modalAvisoExibido")) {
            $('#modalAviso').fadeIn();
            sessionStorage.setItem("modalAvisoExibido", "true");
        }

        $('#btnFecharModal').click(function () {
            $('#modalAviso').fadeOut();
        });
    });
</script>--%>
    <script>
    $(document).ready(function () {
        // Verifica se o modal já foi exibido neste navegador
        if (!localStorage.getItem("modalAvisoExibido")) {
            $('#modalAviso').fadeIn();
            localStorage.setItem("modalAvisoExibido", "true");
        }

        $('#btnFecharModal').click(function () {
            $('#modalAviso').fadeOut();
        });
    });
</script>

</head>
<body>
    <div class="login__titulo">Autoriza Acesso</div>
    <form id="form1" runat="server" style="width: 65%">
        <div class="login__container">
            <div class="login__imagem">
                <img src="img/LoginAutorizaAcesso.svg" />
            </div>
            <div class="login__box ">
                <div class="login__box-informacao">
                    <div class="lista-locais">
                       <%-- <h2 class="login__box-informacao-titulo">Salas para reserva</h2>
                        <ul class="list">
                            <li class="list__item">Anfiteatro</li>
                            <li class="list__item">9º andar - Sala de Grupos</li>
                            <li class="list__item">3º andar - Sala de Reuniões</li>
                        </ul>--%>
                        <p class="login__box-informacao-texto">* Usar o mesmo login e senha de rede.</p>
                    </div>
                </div>
                <div class="login__box-autentica">
                    <h2>Login*</h2>
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuário:"></asp:Label>
                    <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblSenha" runat="server" Text="Senha:"></asp:Label>
                    <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox><br />
                    <br />
                    <div class="login__box-botao">
                        <asp:Button ID="btnLogin" runat="server" Text="Entrar" OnClick="btnLogin_Click" /><br />
                    </div>

                    <asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label>
                    <div class="login__logo">
                        <%--<img class="logo__hspm" src="../img/hspmLogoColor.jpg" />
                        <img class="logo__PMSP" src="../img/logoPrefSP.png" />--%>
                        <img class="logo" src="img/logoHspmPrefeituraColor.jpg" />
                    </div>
                </div>
            </div>
        </div>
    </form>
    <footer>
        <p>Desenvolvido por DITEC (Divisão de Tecnologia da Informação) - hspminformatica@hspm.sp.gov.br</p>
    </footer>
   <%-- </form>--%>
</body>
    <!-- Modal de Aviso -->
<div id="modalAviso" class="modal-overlay">
    <div class="modal-content">
        <h2>Aviso de Acesso</h2>
        <p>
            Utilizar as credenciais de rede (usuário e senha que você utiliza para acessar o computador).<br /><br />
            <strong>Exemplo:</strong><br />
            Se você acessa o computador com:<br />
            Usuário: <code>H123567</code><br />
            Senha: <code>Ab12345678</code><br />
            Utilizará essas mesmas credenciais para acessar o sistema.<br /><br />
            Em caso de dúvidas ou dificuldades de acesso:<br />
            Ramal <strong>8123 / 8124 / 8169 / 3310 / 8125</strong>
        </p>
        <button id="btnFecharModal">Fechar</button>
    </div>
</div>

</html>

