<%@ Page Title="Solicitações Abertas" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SolicitacoesAbertas.old.aspx.cs" Inherits="adm_SolicitacoesAbertas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <link href="../js/jquery.dataTable.css" rel="stylesheet" />
         <script src="../js/jquery.js"></script>
    <script src="../js/jquery.dataTables.js"></script>
   
    <div class="container-fluid">
        <asp:Label ID="LabelExtratoChamado" runat="server" Text="" Visible="False"></asp:Label>
        <asp:Label ID="pegaNomeLoginUsuario" runat="server" Text="" Visible="False"></asp:Label>
        <h3 class="title-content">Solicitações Abertas</h3>
        <div class="row">
            <div class="div-teste">
                <%-- <div class="col-12">--%>
                <div>
               <%--     <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Size="Larger" OnClick="LinkButton1_Click">Meus Chamados em  aberto: </asp:LinkButton>--%>
                    <%--<asp:Label runat="server" Text="Meus Chamados em aberto: " ForeColor="Black" Font-Bold="True" Font-Italic="False" Font-Size="Larger"></asp:Label>--%>
                    <asp:Label runat="server" ID="labelTotalChamadosEmAberto" Font-Bold="True" Font-Size="Larger" ForeColor="black" Visible="true"></asp:Label>
                </div>
                <div>
                    <button type="button" onclick="recarregarAPagina()" class="button">Atualizar lista</button>
                </div>
                <%--</div>--%>
            </div>

        </div>
        <br />
        <asp:GridView ID="GridViewSolicitacoes" AutoGenerateColumns="False" DataKeyNames="id_Solicitacao"
            runat="server" OnRowCommand="grdSolicitacoesExibe_RowCommand" CssClass="table table-bordered"
            HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#3b7b92"
            HeaderStyle-ForeColor="#ffffff" BorderColor="#29336b">
            <Columns>
                <asp:BoundField DataField="Nome_funcionario" HeaderText="Nome" SortExpression="id_Solicitacao" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                   <asp:BoundField DataField="rf_funcionario" HeaderText="RF" SortExpression="rf_funcionario" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="login_do_funcionario" HeaderText="login" SortExpression="login_do_funcionario" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Cargo_Funcionario" HeaderText="Cargo" SortExpression="Cargo_Funcionario" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Ramal" HeaderText="Ramal" SortExpression="Ramal"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="dataSolicitacao" HeaderText="data Solicitação" SortExpression="dataSolicitacao" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="SetoresConcatenados" HeaderText="Solicitações" SortExpression="SetoresConcatenados" ItemStyle-CssClass="hidden-xs"
                    HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                </asp:BoundField>               
              
                <asp:TemplateField HeaderStyle-CssClass="sorting_disabled" HeaderText="Ação">
                    <ItemTemplate>
                        <div class="form-inline">
                            <div class="div-btngrid">
                                <asp:LinkButton ID="lbDadosPaciente" CommandName="editarCirurgia" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                    CssClass="button-grid" runat="server" HorizontalAlign="Center"> <!-- Text="Selecionar" -->
                                  Atender
                                </asp:LinkButton>
                            </div>
                    </ItemTemplate>
                    <HeaderStyle CssClass="sorting_disabled"></HeaderStyle>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
      
    </div>

    <%-- Funções em Java script--%>
         <script type="text/javascript">
         $(document).ready(function() {

             $('#<%= GridViewSolicitacoes.ClientID %>').prepend($("<thead></thead>").append($('#<%= GridViewSolicitacoes.ClientID %>').find("tbody tr:first"))).DataTable({
                 language: {
                     search: "<i class='fa fa-search' aria-hidden='true'>Pesquisar</i>",
                     processing: "Processando...",
                     lengthMenu: "Mostrando _MENU_ registros por páginas",
                     info: "Mostrando página _PAGE_ de _PAGES_",
                     infoEmpty: "Nenhum registro encontrado",
                     infoFiltered: "(filtrado de _MAX_ registros no total)"
                 }
             });

         });
         </script>
    <script>
        function recarregarAPagina() {
            window.location.reload();
        }
    </script>
   <%-- <script type="text/javascript">
        setTimeout(function () {
            window.location.reload(1);
        }, 60000); //60000 1 minutos // 120000 2 min  Junior 03/01/2022

    </script>--%>

</asp:Content>

