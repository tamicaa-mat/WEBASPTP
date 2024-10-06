<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TpWeb.aspGrupo8A._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <a href="PromoVoucher.aspx">
        <div class="promo">
            <div class="textPromo">
                <h2>Aprovechá</h2>
                <p>canjea tu voucher</p>
            </div>
        </div>
    </a>

    <div class="container">
    <div class="row">
        <asp:Repeater ID="rptArticulos" runat="server">
            <ItemTemplate>
                <div class="col-md-4 d-flex align-items-stretch">
                    <div class="card" style="width: 18rem; display: flex; flex-direction: column; justify-content: space-between; margin: 10px; border-color: #e9e9e9">
                        <div style="height: 300px; display: flex; align-items: center;">
                            <img src='<%# Eval("Imagenes[0].Url") %>' class="card-img-top img-fluid" alt="Imagen del artículo" style="max-height: 100%; max-width: 100%; object-fit: contain;">
                        </div>
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                            <p style="margin: 0;">Precio: $<%# Eval("Precio") %></p>
                            <asp:LinkButton Text="Ver más" runat="server" OnClick="verMas_OnClick" CssClass="btn btn-secondary mt-2" CommandArgument='<%# Eval("Id").ToString() %>' />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>

</asp:Content>
