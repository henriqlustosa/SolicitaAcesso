<%@ Page Title="Alterar senha" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AlterarSenha.aspx.cs" Inherits="Administrativo_Permissao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/content.css" rel="stylesheet" />
    <link href="../css/permissao.css" rel="stylesheet" />
    
    <style type="text/css">
        #interna {
            margin: 0 auto;
            width: 50%; /* Valor da Largura */
        }

        .divForm{
            margin:5% 0;
            display:flex;
            justify-content:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <h3 class="title-content">Alterar Senha de Usuário</h3>
    <div class="container-fluid">        
        <div class="divForm">
            <div class="row">                
                <%--div class="col-md-6 col-sm-12 col-xs-12 form-group">--%>
                    <label class="fw-bold">
                        <asp:ChangePassword ID="ChangePassword1" runat="server">
                            <ChangePasswordTemplate>
                                <table cellspacing="0" cellpadding="1" style="border-collapse: collapse; color:#29336b">
                                    <tr>
                                        <td>
                                            <table cellpadding="0">
                                                <tr>
                                                    <td align="center" colspan="2" ></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Senha: &nbsp;</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="CurrentPassword" runat="server" ForeColor="#29336b" TextMode="Password"></asp:TextBox>(Se tiver preenchido automaticamente apague e digite a senha atual)
                                                            <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">Nova senha: &nbsp;</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword" ErrorMessage="New Password is required." ToolTip="New Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirme a nova senha: &nbsp;</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword" ErrorMessage="Confirm New Password is required." ToolTip="Confirm New Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2">
                                                            <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="The Confirm New Password must match the New Password entry." ValidationGroup="ChangePassword1"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2" style="color: Red;">
                                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Button ID="ChangePasswordPushButton" runat="server" BackColor="#ffffff" BorderColor="#29336b" CommandName="ChangePassword" ForeColor="#29336b" Text="Alterar senha" ValidationGroup="ChangePassword1" />
                                                        </td>
                                                        <td></td>
                                                        <%--<td>
                                                            <asp:Button ID="CancelPushButton" runat="server" BackColor="#ffffff" BorderColor="#3b7b92" CausesValidation="False" CommandName="Cancel" ForeColor="#3b7b92" Text="Cancelar" />
                                                        </td>--%>
                                                    </tr>
                                                </tr>
                                                </tr>
                                            </table>
                            </ChangePasswordTemplate>
                        </asp:ChangePassword>
               <%-- </%--div>--%>
            </div>
            
        </div>
        
    </div>

    </label>

</asp:Content>

