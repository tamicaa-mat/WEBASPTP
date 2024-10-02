<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroCliente.aspx.cs" Inherits="TpWeb.aspGrupo8A.RegistroCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <form class="row g-3">

    <div class="row">
  <div class="col">
      <label for="inputNombre" class="form-label" >Nombre</label>
    <input type="text" class="form-control" placeholder="First name" aria-label="First name"id="inmputNombre">
  </div>
  <div class="col">
        <label for="inputApellido" class="form-label">Apellido</label>
    <input type="text" class="form-control" placeholder="Last name" aria-label="Last name"id="inputApellido">
  </div>
</div>



   
  <div class="col-md-6">
    <label for="inputEmail" class="form-label">Email</label>
    <input type="email" class="form-control" id="inputEmail">
  </div>
  <div class="col-md-6">
    <label for="inputDNI" class="form-label" >DNI</label>
    <input type="text" class="form-control" id="inputDNI">
  </div>
  <div class="col-12">
    <label for="inputDireccion" class="form-label">Direccion</label>
    <input type="text" class="form-control" id="inputDireccion" placeholder="Calle Siempre Viva 123">
  </div>

  <div class="col-md-6">
    <label for="inputCiudad" class="form-label">Ciudad</label>
    <input type="text" class="form-control" id="inputCiudad">
  </div>
  
  <div class="col-md-2">
    <label for="inputCP" class="form-label">Codigo Postal</label>
    <input type="text" class="form-control" id="inputCP">
  </div>
  <div class="col-12">
    <div class="form-check">
      <input class="form-check-input" type="checkbox" id="gridCheck">
      <label class="form-check-label" for="gridCheck">
        Acepto todo
      </label>
    </div>
  </div>
  <div class="col-12">
    <button type="submit" class="btn btn-primary" id="btnAceptar" >Aceptar</button>
  </div>
</form>









</asp:Content>

