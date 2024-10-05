<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TpWeb.aspGrupo8A._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>

      
    <div class="container">
        <div class="row">
            <div class="col-md-6 offset-md-3">
                <h2>Canjea tu Código</h2>

                <!-- Etiqueta para la caja de texto -->
                <asp:Label ID="lblCodigoVoucher" runat="server" Text="Ingresa tu código de voucher:" CssClass="form-label"></asp:Label>
                
                <!-- Caja de texto para ingresar código  pruebasss-->
                <asp:TextBox ID="txtCodigoVoucher" runat="server" CssClass="form-control" Placeholder="Código de voucher"></asp:TextBox>
                
                <!-- Botón para enviar el código -->
                <asp:Button ID="btnCanjear" runat="server" Text="Canjear" CssClass="btn btn-primary mt-3" OnClick="btnCanjear_Click" />

                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>


            </div>
        </div>
    </div>


    </main>

</asp:Content>
