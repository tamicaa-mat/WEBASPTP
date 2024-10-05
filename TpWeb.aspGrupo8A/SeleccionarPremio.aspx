

<%@ Page Title="Seleccionar Premio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SeleccionarPremio.aspx.cs" Inherits="TpWeb.aspGrupo8A.SeleccionarPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Selecciona tu premio</h2>
 
<%--<asp:GridView runat="server" ID="dgvArticulos"> </asp:GridView>--%>
  
    <div class="container">
        <div class="row">
       
     <asp:Repeater ID="rptArticulos" runat="server">  
         <ItemTemplate>
         <div class="card column" style="width: 18rem; display: flex; flex-direction: column; justify-content: space-between; margin:10px ;height: 100%; border-color:gray">
            <img src='<%# Eval("Imagenes[0].Url") %>'class="card-img-top img-fluid img" alt="Imagen del artículo">
            <div class="card-body">
            <h5 class="card-title"><%# Eval("Nombre") %></h5>
             <p class="card-text"><%# TextDescripcion(Eval("Descripcion").ToString())%>
                <a href="DetallesArticulo.aspx?id=<%#Eval("Id")%>" style="text-decoration:none"> Ver más</a>
             </p>
            
            <a href="RegistroCliente.aspx" class="btn btn-primary">Seleccionar</a>
            </div> 
            </div> 
        </ItemTemplate>
         
     </asp:Repeater>
        </div>
        <div class="btn-volver" style="display:flex; flex-direction:row; justify-content:end;">
        <a href="Default.aspx" class="btn btn-secondary">Volver</a>
        </div>
    </div>
   
</asp:Content>