﻿<%@ Page Title="Articulos en detalle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetallesArticulo.aspx.cs" Inherits="TpWeb.aspGrupo8A.DetallesArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h1 id="tituloDetalles">INFORMACIÓN DEL ARTÍCULO</h1>
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

        <h3>TAMBIÉN PODRÍAN INTERESARTE</h3>
        <div style="max-height: 500px; overflow: hidden;">
            <div style="overflow: hidden;">
                <asp:Repeater ID="RepeaterLista" runat="server">
                    <ItemTemplate>
                        <div class="articuloList d-flex align-items-center p-2" style="border-bottom: 1px solid #ddd;">
                            <img src='<%# Eval("Imagenes[0].Url") %>' class="imagenArticulo me-3" alt="Imagen del artículo" style="width: 80px; height: 80px; object-fit: cover; border-radius: 5px;">
                            <div>
                                <h4 style="margin: 0;"><%# Eval("Nombre") %></h4>
                                <p style="margin: 0;">Precio: $<%# Eval("Precio") %></p>
                                <asp:Button ID="BtnVer" runat="server" Text="Ver" CommandArgument='<%# Eval("Id").ToString() %>' OnClick="BtnVer_OnClick" CssClass="btn btn-sm btn-secondary mt-2" />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <%--<div class="btn-volver p-2" style="display: flex; flex-direction: row; justify-content: end;">
            <a href="SeleccionarPremio.aspx" class="btn btn-secondary">Volver</a>
        </div>--%>
    </div>

</asp:Content>
