<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallesArticulo.aspx.cs" Inherits="TpWeb.aspGrupo8A.DetallesArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h1 id="tituloDetalles">Información del artículo</h1>
        <div class="row">
            <div class="col">
                <div id="carouselExampleAutoplaying" class="carousel slide" data-bs-ride="carousel">
                    <div class="carousel-innerstyle=" style="max-height: 500px; overflow: hidden;">
                        <asp:Repeater ID="RepeaterImagenes" runat="server">
                            <ItemTemplate>
                                <div class="carousel-item <%# (bool)Eval("Estado") ? "active" : "" %>">
                                    <img src='<%# Eval("Url") %>' class="d-block" alt="Imagen del artículo" style="max-width: 100%; height: auto; margin: 0 auto">
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>
            </div>
        </div>
        <div class="row mt-4">
            <div class="col d-flex justify-content-between align-items-center bg-light p-4" style="border-radius: 5px;">
                <h2 id="nombreArticulo" runat="server" style="margin: 0;"></h2>
                <h3 id="precioArticulo" runat="server" style="margin: 0;"></h3>
            </div>
        </div>
        <div class="col mt-2">
            <div class="p-3 bg-light" style="min-height: 100px;">
                <p id="descripcionArticulo" runat="server" style="margin: 0; word-wrap: break-word;"></p>
            </div>
        </div>
        <div class="col mt-4">
            <table class="table table-striped">
                <tbody>
                    <tr>
                        <th style="border-top: none;">Categoría</th>
                        <td style="border-top: none;"><span id="categoriaArticulo" runat="server"></span></td>
                    </tr>
                    <tr>
                        <th>Marca</th>
                        <td><span id="marcaArticulo" runat="server"></span></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

</asp:Content>
