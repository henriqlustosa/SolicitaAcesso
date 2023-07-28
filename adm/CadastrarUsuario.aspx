<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CadastrarUsuario.aspx.cs" Inherits="administrativo_CadastrarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/content.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="container">

      <h1 class="titleContent">Cadastrar Usuário</h1>
       
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
            Email="sem@email.com" 
            ContinueDestinationPageUrl="~/Administrativo/Permissao.aspx" 
            FinishDestinationPageUrl="~/Administrativo/Permissao.aspx">
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server">
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep runat="server" AllowReturn="False">
                    <ContentTemplate>
                        <table border="0">
                            <tr>
                                <td align="center" colspan="2">
                                    Complete
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Your account has been successfully created.
                                </td>
                            </tr>
                            <tr>
                            <script>
                                window.location = "Permissao.aspx"
                                        </script>
                                <td align="right" colspan="2">
                                    <asp:Button ID="ContinueButton" CssClass="btn btn-success" runat="server" CausesValidation="False"
                                        CommandName="Continue" Text="Continue" ValidationGroup="CreateUserWizard1"/>
                                        
                                        
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
    </div>
    
</asp:Content>

