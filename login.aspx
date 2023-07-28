<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/login.css" rel="stylesheet" />
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script defer src="bootstrap/js/bootstrap.min.js"></script>
    <title>Registro de Visitantes</title>
</head>
<body class="text-center imgBackground">
    <form id="form1" runat="server" class="marginTable">

        <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Solicitar.aspx">
           
            <LayoutTemplate>
                <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                    <thead>
                        <tr>
                            <th>
                                <h3 class="titleLogin">Solicitar Acesso</h3>
                            </th>
                        </tr>
                    </thead>
                    <tr>
                        <td class="centerTable">
                            <table cellpadding="0">
                                <div class="centerTable">
                                    <tr class="txtLabel">
                                        <div class="form-floating">
                                            <td align="right">
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuário:  &nbsp</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="txtBox" ID="UserName" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="O Nome do Usuário é obrigatório." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </div>
                                    </tr>
                                    <tr class="txtLabel">
                                        <div class="form-floating">
                                            <td align="right">
                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha:  &nbsp &nbsp</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox CssClass="txtBox" ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="A senha é obrigatória." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </div>
                                    </tr>

                                    <%-- <tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                    </td>
                                </tr>--%>
                                    <tr>
                                        <td align="center" colspan="2" style="color: Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                </div>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Button CssClass="buttonLogin" ID="LoginButton" runat="server" CommandName="Login" Text="Entrar" ValidationGroup="Login1" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tfoot>
                        <tr>
                            <td align="center">
                                <img class="imgFooter" src="img/Logo_HSPM_Pref-01.jpg"> </img>
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </LayoutTemplate>
        </asp:Login>
    </form>
</body>
</html>
