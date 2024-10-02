<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeleccionarPremio.aspx.cs" Inherits="TpWeb.aspGrupo8A.SeleccionarPremio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Selecciona tu premio</h2>
    <asp:GridView ID="gvPremios" runat="server" AutoGenerateColumns="False" OnRowCommand="gvPremios_RowCommand">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre del Premio" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:ButtonField Text="Seleccionar" ButtonType="Button" CommandName="Seleccionar" />
        </Columns>
    </asp:GridView>
</asp:Content>--%>

<%@ Page Title="Seleccionar Premio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeleccionarPremio.aspx.cs" Inherits="TpWeb.aspGrupo8A.SeleccionarPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Selecciona tu premio</h2>
<%-- <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="gvPremios_RowCommand">--%>
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre del Premio" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
            <asp:ButtonField Text="Seleccionar" ButtonType="Button" CommandName="Seleccionar" />
        </Columns>
    </asp:GridView>
</asp:Content>