<%@ Page Title="Cadastrar Coordenador" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CadastrarCoordenador.aspx.cs" Inherits="adm_CadastrarCoordenador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">
        <h5 class="title-content">Cadastrar Coordenador </h5>

        <div class="row">

            <div class="col-4 fw-bold">
                Nome do Coordenador: <%--placeholder="Digite o número do CAC"--%>
                <asp:TextBox ID="txtNomeCoordenador" runat="server" class="form-control" required MaxLength="60"></asp:TextBox>
            </div>
            <div class="col-2 fw-bold">
                RF:
              <asp:TextBox ID="txtRF" runat="server" class="form-control" required ForeColor="Black" MaxLength="12"></asp:TextBox>

            </div>
            <div class="col-2">
                E-mail:
                <asp:TextBox ID="txtEmail" runat="server" class="form-control" required MaxLength="50" ></asp:TextBox>

            </div>
            <div class="col-1">
                &nbsp;
                <asp:Label ID="Label1" runat="server" Text="@hspm.sp.gov.br"></asp:Label>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-1">
                Ramal-1:
                <asp:TextBox ID="txtRamal1" runat="server" class="form-control" required MaxLength="4"></asp:TextBox>
            </div>        
            <div class="col-1">
                Ramal-2:
                <asp:TextBox ID="txtRamal2" runat="server" class="form-control" required MaxLength="4"></asp:TextBox>
            </div>
            <div class="col-6">
                Setor:
                <asp:TextBox ID="txtSetor" runat="server" class="form-control" required MaxLength="100"></asp:TextBox>
            </div>
            <div class="col-2">
                Selecione o Login:
                <asp:DropDownList ID="ddlLogin" runat="server" class="form-control" DataSourceID="SqlDataSource1" DataTextField="UserName" DataValueField="UserName"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SolicitaAcessoConnectionString %>" SelectCommand="SELECT [UserName] FROM [vw_aspnet_Users]"></asp:SqlDataSource>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-1"></div>
            <div class="col-2 fw-bold">

                <%--<asp:DropDownList runat="server" class="form-control" ID="ddlTitulo" DataSourceID="SqlDataSource2" DataTextField="NomeTipoChamado" DataValueField="NomeTipoChamado"></asp:DropDownList>--%>
                <%--<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:chamado_suporteConnectionString %>" SelectCommand="SELECT [NomeTipoChamado] FROM [TipoChamado] ORDER BY [NomeTipoChamado]"></asp:SqlDataSource>--%>
            </div>
            <div class="col-1"></div>
        </div>
    <%--</div>--%>
    <br />
    <div class="row ">
        <div class="col-5"></div>
        <div class="div-btn justify-content-md-evenly">
            <div>
                <asp:Button ID="btnCadastrar" runat="server" class="button" Text="Cadastrar" OnClick="btnCadastrar_Click" />
            </div>

        </div>
    </div>
        
        <hr />
        <div>
            <asp:GridView ID="gdvCadastroCoordenadores" AutoGenerateColumns="False" DataKeyNames="id"
                runat="server" BorderStyle="Solid" OnRowCommand="gdvCadastroCoordenadoresHSPM_RowCommand" CssClass="table table-bordered">
                <Columns>
                    <asp:BoundField DataField="NomeCoordenador" HeaderText="Nome" SortExpression="NomeCoordenador"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                    <asp:BoundField DataField="RF_Coordenador" HeaderText="RF" SortExpression="RF_Coordenador"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                    <asp:BoundField DataField="eMail" HeaderText="E-Mail" SortExpression="eMail"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                    <asp:BoundField DataField="ramal1" HeaderText="Ramal" SortExpression="ramal1"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                     <asp:BoundField DataField="ramal2" HeaderText="Ramal 2" SortExpression="ramal2"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                    <asp:BoundField DataField="setorCoordenador" HeaderText="Setor" SortExpression="setorCoordenador"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                    <asp:BoundField DataField="loginCoordenador" HeaderText="Login" SortExpression="loginCoordenador"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs"></asp:BoundField>
                              
              <%--      <asp:TemplateField HeaderStyle-CssClass="sorting_disabled" HeaderText="Baixa Ausencia">
                        <ItemTemplate>
                            <div class="form-inline">
                                <asp:LinkButton ID="LinkButton1" CommandName="BaixaAusente" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                    class="btn btn-warning" Style='color: black;' runat="server"> <!-- Text="Selecionar" -->
                                  Baixa Ausente
                                </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle CssClass="sorting_disabled"></HeaderStyle>
                    </asp:TemplateField>--%>
                      <asp:TemplateField HeaderStyle-CssClass="sorting_disabled" HeaderText="Excluir">
                        <ItemTemplate>
                            <div class="form-inline">
                                <asp:LinkButton ID="lbExcluir" CommandName="Excluir" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                    class="btn btn-danger" runat="server"> <!-- Text="Selecionar" -->
                                 Excluir
                                </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle CssClass="sorting_disabled"></HeaderStyle>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>

        </div>



    </div>

</asp:Content>

