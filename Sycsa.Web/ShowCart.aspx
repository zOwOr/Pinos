<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="ShowCart.aspx.vb" Inherits="sycsa.Web.ShowCart" %>


<asp:Content ID="Content3" ContentPlaceHolderID="Html_head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Html_sidebar" runat="server">
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="Html_Content" runat="server">


    <div class="row">
        <div class="col-lg-12 col-sm-12 col-xs-12">

            <div class="carousel-heading">
                <h4>Carrito de compras</h4>
                <div class="carousel-arrows">
                    <asp:HyperLink ID="linkContinuarComprando" CssClass="btn btn-secondary " runat="server" NavigateUrl="~/Productos.aspx?action=show&paramAll=all">
                        Continuar comprando</asp:HyperLink>
                </div>

            </div>

            <asp:GridView ID="gvListProductos" runat="server" CssClass="table table-bordered table-striped table-condensed cf orderinfo-table" AutoGenerateColumns="False"
                DataKeyNames="IdProduct" Width="100%" EmptyDataText="No hay nada en su carrito de compras." GridLines="None">
                <Columns>
                    <asp:BoundField DataField="IdProduct" Visible="false" HeaderText="Producto"></asp:BoundField>
                    <asp:TemplateField HeaderText="id" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="idcarrito" runat="server" Text='<%# Eval("IdProduct").ToString() & "," & Eval("Unidad") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="No.">
                        <HeaderStyle CssClass="text-center fw-bold" />
                        <ItemStyle CssClass="text-center align-middle" />
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="imagen">
                        <HeaderStyle CssClass="text-center fw-bold" />
                        <ItemStyle CssClass="text-center align-middle" />
                        <ItemTemplate>
                            <a href="#" data-bs-toggle="modal" data-bs-target="#productModal_<%#Eval("IdProduct")%>">
                                <button type="button" style="width: 42px; height: 42px;" class="btn btn-primary rounded-circle ">
                                    <i class="bi bi-eye"></i>
                                </button>
                            </a>
                            <div class="modal fade" id="productModal_<%#Eval("IdProduct")%>" tabindex="-1" aria-labelledby="productModalLabel" aria-hidden="true">
                                <div class="modal-dialog modal-dialog-centered modal-lg">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title" id="productModalLabel"><%# Eval("Producto")%></h5>
                                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                        </div>
                                        <div class="modal-body bg-light-subtle">
                                            <div class="container">
                                                <div class="row">
                                                    <div class="col">
                                                        <%--<img src="<%# Eval("ProductImagen") %>" class="img-fluid" alt="Imagen del producto">--%>


                                                        <h6>Detalles del producto</h6>
                                                        <p>Codigo: <strong><%#Eval("IdProduct") %></strong></p>


                                                        <!-- Add more details as needed -->
                                                    </div>
                                                    <div class="col-6 text-center">
                                                        <img src=" <%#Eval("Imagen")%>" class="img-fluid img-thumbnail rounded " alt="Producto sin imagen" style="height : 300px; width: auto;">
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                                            <!-- Add more buttons if needed -->
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Clave">
                        <HeaderStyle CssClass="text-center fw-bold" />
                        <ItemStyle CssClass="text-center align-middle" />
                        <ItemTemplate>
                            <%#Eval("IdProduct")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Producto">
                        <HeaderStyle CssClass="text-center fw-bold" />
                        <ItemStyle CssClass="text-center align-middle" />
                        <ItemTemplate>
                            <%# Eval("Producto")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Precio">
                        <HeaderStyle CssClass="text-center fw-bold" />
                        <ItemStyle CssClass="text-center align-middle" />
                        <ItemTemplate>
                            <%# IIf(Session("MM_Lista") Is Nothing, "", FormatCurrency(Eval("Precio")))%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Cantidad">
                        <HeaderStyle CssClass="text-center fw-bold" />
                        <ItemStyle CssClass="text-center align-middle" />
                        <ItemTemplate>
                            <div class="row justify-content-center" style="width: 230px; margin: auto;">
                                <div class="col-6">
                                    <asp:TextBox runat="server" type="number" min="0" ID="txtCantidad" Text='<%# Eval("Cantidad")%>' CssClass="form-control text-center"></asp:TextBox>
                                </div>
                                <div class="col-6">
                                    <asp:LinkButton runat="server" ID="LinkButton1" CommandName="Update" CssClass="btn btn-sm btn-outline-success" CommandArgument='<%# Eval("IdProduct").ToString() & "," & Eval("Unidad") %>'>
                            <i class="icons icon-ok-3"></i>
                            Actualizar
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="btnEliminar" CommandName="Delete" CssClass="btn btn-sm btn-outline-danger" CommandArgument='<%# Eval("IdProduct").ToString() & "," & Eval("Unidad") %>'>
                            <i class="icons icon-cancel-3"></i>
                            Eliminar
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Total">
                        <HeaderStyle CssClass="text-center fw-bold" />
                        <ItemStyle CssClass="text-center align-middle" />
                        <ItemTemplate>
                            <%# IIf(Session("MM_Lista") Is Nothing, "", FormatCurrency(Eval("Total")))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>


        </div>


        <div class="col-lg-12 col-md-12 col-sm-12">
            <div class="checkout-form">
                <table style="width: 100%;" class="table table-primary table-hover">
                    <tr>
                        <td style="width: 35%;"></td>
                        <td style="width: 25%;"></td>
                        <td style="width: 25%;"><strong>Sub Total</strong></td>
                        <td style="width: 15%;"><% Response.Write(IIf(Session("MM_Lista") Is Nothing, "", FormatCurrency(Html._SubTotal, 2)))%></td>
                    </tr>
                    <tr>
                        <td style="width: 35%;"></td>
                        <td style="width: 35%;"></td>
                        <td style="width: 15%;"><strong>Sub sub Total (Descuento especial 4%)</strong></td>
                        <td style="width: 15%;">
                            <% 
                                Dim subtotal As Decimal = Html._SubTotal
                                Dim descuento As Decimal = GetDescuento()
                                Dim subtotalConDescuento As Decimal = subtotal - (subtotal * descuento)
                                Response.Write(IIf(Session("MM_Lista") Is Nothing, "", FormatCurrency(subtotalConDescuento, 2)))
                            %>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td><strong>IVA</strong></td>
                        <td>
                            <% 
                                Dim iva As Decimal = Html._PorcentajeIva * (1 - descuento)
                                Response.Write(IIf(Session("MM_Lista") Is Nothing, "", FormatCurrency(iva, 2)))
                            %>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td><strong><span class="price">Total</span></strong></td>
                        <td><span class="price">
                            <% 
                                Dim total As Decimal = subtotalConDescuento + iva
                                Response.Write(IIf(Session("MM_Lista") Is Nothing, "", FormatCurrency(total, 2)))
                            %>
                        </span></td>
                    </tr>
                </table>

                <div id="divButton" runat="server" visible="true" style="padding: 5px">
                    <asp:Button ID="btnComprar" runat="server" Text="Realizar pedido" />
                </div>
            </div>
        </div>







    </div>



</asp:Content>
