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
                    <asp:HyperLink ID="linkContinuarComprando" CssClass="button big" runat="server" NavigateUrl="~/ListProducts.aspx?action=show&paramAll=all">
                        Continuar comprando</asp:HyperLink>
                </div>

            </div>

            <asp:GridView ID="gvListProductos" runat="server" CssClass="col-md-12 table-bordered table-striped table-condensed cf orderinfo-table" AutoGenerateColumns="False"
                DataKeyNames="IdProduct" Width="100%" EmptyDataText="No hay nada en su carrito de compras." GridLines="None">
                <Columns>
                    <asp:BoundField DataField="IdProduct" Visible="false" HeaderText="Producto"></asp:BoundField>
<%--                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>                           
                              <img src="imagen/products/sample4-thumb.jpg" alt="" width="100%" class="img-thumbnail" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="image-column"></ItemStyle>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="id" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="idcarrito" runat="server" Text='<%# Eval("IdProduct").ToString() & "," & Eval("Unidad") %>'>

                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Producto">
                        <ItemTemplate>
                            <%# Eval("Producto")%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Precio">
                        <ItemTemplate>
                            <%# IIf(Session("MM_Lista") Is Nothing, "", FormatCurrency(Eval("Precio")))%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>

                            <div class="row" style="width: 230px; margin: auto;">

                                <div class="col-lg-6">
                                    <asp:TextBox runat="server" type="number" min="0" ID="txtCantidad" Text='<%# Eval("Cantidad")%>' Style="text-align: center;" Width="100%"></asp:TextBox>
                                </div>
                                <div class="col-lg-6">
                                    <asp:LinkButton runat="server" ID="LinkButton1" CommandName="Update" CssClass="red-hover"
                                        CommandArgument='<%# Eval("IdProduct").ToString() & "," & Eval("Unidad") %>' Style="font-size: 12px;">
                                        <i class="icons icon-ok-3"></i>
                                        <label id="Label1" runat="server">Actualizar</label>
                                    </asp:LinkButton>

                                    <asp:LinkButton runat="server" ID="btnEliminar" CommandName="Delete" CssClass="red-hover"
                                        CommandArgument='<%# Eval("IdProduct").ToString() & "," & Eval("Unidad") %>' Style="font-size: 12px;">
                                        <i class="icons icon-cancel-3"></i>
                                        <label id="lblDeleteProductCart" runat="server">Eliminar</label>
                                    </asp:LinkButton>
                                </div>

                            </div>

                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total">
                        <ItemTemplate>
                            <%# IIf(Session("MM_Lista") Is Nothing, "", FormatCurrency(Eval("Total")))%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>

        <div class="col-lg-12 col-md-12 col-sm-12">
            <div class="checkout-form">

                <table style="width: 100%;" class="orderinfo-table">
                    <tr>
                        <td style="width: 35%;"></td>
                        <td style="width: 35%;"></td>
                        <td style="width: 15%;"><strong>Sub Total</strong></td>
                        <td style="width: 15%;"><% Response.Write(IIf(Session("MM_Lista") Is Nothing, "", FormatCurrency(Html._SubTotal, 2)))%></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td><strong>IVA</strong></td>
                        <td><% Response.Write(IIf(Session("MM_Lista") Is Nothing, "", FormatCurrency(Html._PorcentajeIva, 2)))%></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td><strong><span class="price">Total</span></strong></td>
                        <td><span class="price"><%  Response.Write(IIf(Session("MM_Lista") Is Nothing, "", FormatCurrency((Html._SubTotal + Html._PorcentajeIva), 2)))%></span></td>
                    </tr>
                </table>

                <div id="divButton" runat="server" visible="true" style="padding: 5px">
                    <asp:Button ID="btnComprar" runat="server" Text="Realizar pedido" />
                </div>

            </div>
        </div>

    </div>



</asp:Content>
