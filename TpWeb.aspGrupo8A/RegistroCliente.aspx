<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroCliente.aspx.cs" Inherits="TpWeb.aspGrupo8A.RegistroCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6">
                    <label for="textDni" class="form-label">DNI</label>
                    <asp:TextBox ID="textDni" CssClass="form-control" runat="server" AutoPostBack="True" OnTextChanged="textDni_TextChanged" />
                    <asp:Label ID="lblErrorDni" runat="server" Text="Label" CssClass="text-danger" Visible="false"></asp:Label>
                </div>
                <div class="col">
                    <label for="textNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="textNombre" CssClass="form-control" placeholder="Nombre" runat="server"></asp:TextBox>
                    <asp:Label ID="lblErrorNombre" runat="server" Text="Label" CssClass="text-danger" Visible="false"></asp:Label>
                </div>
                <div class="col">
                    <label for="textApellido" class="form-label">Apellido</label>
                    <asp:TextBox ID="textApellido" CssClass="form-control" placeholder="Apellido" runat="server" />
                    <asp:Label ID="lblErrorApellido" runat="server" Text="Label" CssClass="text-danger" Visible="false"></asp:Label>
                </div>
            </div>

            <div class="col-md-6">
                <label for="textEmail" class="form-label">Email</label>
                <asp:TextBox ID="textEmail" CssClass="form-control" runat="server" placeholder="name@example.com" />
                <asp:Label ID="lblErrorEmail" runat="server" Text="Label" CssClass="text-danger" Visible="false"></asp:Label>
            </div>
            <div class="col-12">
                <label for="textDireccion" class="form-label">Direccion</label>
                <asp:TextBox CssClass="form-control" ID="textDireccion" placeholder="Calle Siempre Viva 123" runat="server" />
                <asp:Label ID="lblErrorDireccion" runat="server" Text="Label" CssClass="text-danger" Visible="false"></asp:Label>
            </div>

            <div class="col-md-6">
                <label for="textCiudad" class="form-label">Ciudad</label>
                <asp:TextBox CssClass="form-control"  ID="textCiudad" runat="server" />
                <asp:Label ID="lblErrorCiudad" runat="server" Text="Label" CssClass="text-danger" Visible="false"></asp:Label>
            </div>

            <div class="col-md-2">
                <label for="textCP" class="form-label">Codigo Postal</label>
                <asp:TextBox CssClass="form-control" ID="textCP" runat="server" />
                <asp:Label ID="lblErrorCp" runat="server" Text="Label" CssClass="text-danger" Visible="false"></asp:Label>
            </div>

            <div class="col-12">
                <div class="form-check d-flex align-items-center" >
                    <asp:CheckBox ID="chkbAcepto" CssClass="form-check-input" runat="server" />
                    <label class="form-check-label " for="chkbAcepto">
                        Acepto todo
                    </label>
                    <asp:Label ID="lblMensajeError" runat="server" CssClass="text-danger mt-1 d-block" Visible="false"></asp:Label>
                </div>
            </div>
            <div class="col-12">
                <asp:Button ID="btnParticipar" CssClass="btn btn-secondary" runat="server" Text="Aceptar" OnClick="btnParticipar_OnClick" />
            </div>
            <%--<div class="btn-volver" style="display:flex; flex-direction:row; justify-content:end;">
            <a href="SeleccionarPremio.aspx" class="btn btn-secondary">Volver</a>
            </div>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

