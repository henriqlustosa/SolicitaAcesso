<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Permissao.aspx.cs" Inherits="ADM_Permissao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
           
    <link href="../vendors/iCheck/skins/flat/green.css" rel="stylesheet" />
    <link href="../css/content.css" rel="stylesheet" />
     <style type="text/css">
        #interna
        {
            margin: 0 auto;
            width: 50%; /* Valor da Largura */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- page content -->
    <div id="interna">
    <div class="x_title">
 
        <h1 class="titleContent">
            Cadastro de Permissões de Usuários</h1>
            <br />
        <div class="clearfix">
        </div>
    </div>
    <div class="x_content">
        <div class="row">
            <div class="col-md-6 col-sm-12 col-xs-12 form-group">
                <label>
                    Nome <span class="required">*</span></label>
                <asp:DropDownList ID="DropDownList1" class="form-control" runat="server"
                    AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
        <div >
                           <label> &nbsp;&nbsp;&nbsp; Permissões <span class="required">*</span></label>
        </div>
        </div>
        
        <div class="row">
            <div class="col-md-6 col-sm-12 col-xs-12 form-group">
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged"
                    RepeatLayout="Flow" CssClass="flat">
                </asp:CheckBoxList>
                 </div>
        </div>
        <div class="row">
        <div class="form-group">
            <div class="col-md-9 col-sm-9 col-xs-12">
                <asp:Button ID="btnCad" runat="server" Text="Cadastrar" class="btn btn-primary" 
                    OnClick="btnCad_Click" Height="38px" Width="104px" /></td>
            </div>
        </div>
        </div>
    </div>
    </div>
</asp:Content>

