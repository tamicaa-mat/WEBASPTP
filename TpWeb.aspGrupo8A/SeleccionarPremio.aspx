

<%@ Page Title="Seleccionar Premio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeleccionarPremio.aspx.cs" Inherits="TpWeb.aspGrupo8A.SeleccionarPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Selecciona tu premio</h2>
 
<%--<asp:GridView runat="server" ID="dgvArticulos"> </asp:GridView>--%>
  
    <div class="container">
        <div class="row">
       
     <asp:Repeater ID="rptArticulos" runat="server">  
         <ItemTemplate>
         <div class="card column" style="width: 18rem;">
            <img src='<%# Eval("Imagenes[0].Url") %>'class="card-img-top img-fluid img" alt="...">
            <div class="card-body">
            <h5 class="card-title"><%# Eval("Nombre") %></h5>
            <p class="card-text"><%# Eval ("Descripcion") %></p>
            <a href="RegistroCliente.aspx" class="btn btn-primary">Seleccionar</a>
            </div> 
            </div>
        </ItemTemplate>
     </asp:Repeater>
        </div>
    </div>
   
</asp:Content>