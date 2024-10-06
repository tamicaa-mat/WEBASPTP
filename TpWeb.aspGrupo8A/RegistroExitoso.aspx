<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroExitoso.aspx.cs" Inherits="TpWeb.aspGrupo8A.RegistroExitoso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="site.css" rel="stylesheet" />
    <div class="container">
        <div class="row">
            <div class="col">
                <div class="containerExit">
                    <i class="bi bi-check-circle"></i>
                    <asp:Label ID="MensajeExito" CssClass="textM" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <a href="Default.aspx" class="link-primary" style="text-decoration: none">Volver</a>
            </div>
        </div>
    </div>
</asp:Content>
