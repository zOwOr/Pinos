<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="Productos.aspx.vb" Inherits="sycsa.Web.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Html_head" runat="server">
    <script>
        function AddCart(e) {
            eventTarget = "addCart"
            cantidad = $('#cantidad_' + e.split(",")[0].trim() + "_" + e.split(",")[1].trim()).val();
            cantidad = cantidad > 0 ? cantidad : 1
            __doPostBack(eventTarget, e.trim() + "," + cantidad);
        }
    </script>
    <script>
        function AddCant(e) {
            var a = e.value
            $("#" + e.id).val(a)
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Html_sidebar" runat="server">
     <aside class="sidebar col-lg-2 col-md-2 col-sm-2"">
        <!-- Categories -->
        <div class="sidebar-header">
            <h3>Categorias</h3>
        </div>
    </aside>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Html_Content" runat="server">
    <section class="col-lg-10 col-md-10 col-sm-10">
        <div id="no-more-tables">
            <table class="table table-bordered table-striped table-hover table-condensed">
                <thead class="thead-dark">
                    <tr>
                        <th>Codigo</th>
                        <th>Producto</th>
                        <th class="numeric">Categoria</th>
                        <th class="numeric">Subcategoria</th>
                        <th class="numeric">Marca</th>
                        <th class="numeric">Unidad</th>
                        <th class="numeric">Precio</th>
                        <th class="numeric">Comprar</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:ListView ID="ListProducts" runat="server" ConvertEmptyStringToNull="true"
                        GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1" EnableTheming="false">

                        <GroupTemplate>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder1" EnableTheming="False"></asp:PlaceHolder>
                        </GroupTemplate>

                        <LayoutTemplate>
                            <asp:PlaceHolder ID="groupPlaceHolder1" runat="server"></asp:PlaceHolder>
                        </LayoutTemplate>

                        <ItemTemplate>
                            <tr>
                                <td data-title="Codigo" class="numeric">
                                    <%# Eval("ProductName")%>
                                </td>
                                <td data-title="Producto">
                                    <span><%# Eval("shortDescription")%></span>
                                    <span class="descripciontb"><a href="ShowProduct.aspx?pk=<%#Eval("ProductID")%>&pu=<%# Eval("Unidad")%>" class="product-hover"></a></span>
                                </td>
                                <td data-title="Categoria" class="numeric">
                                    <%# Eval("Categoria")%>
                                </td>
                                <td data-title="Subcategoria" class="numeric">
                                    <%# Eval("Subcategoria")%>
                                </td>
                                <td data-title="Marca" class="numeric">
                                    <%# Eval("Marca")%>
                                </td>
                                <td data-title="Unidad" class="numeric">
                                    <%# Eval("Unidad")%>
                                </td>
                                <td data-title="Precio" class="numeric">
                                    <span class="price"><%# IIf(Session("MM_Lista") Is Nothing, "", FormatCurrency(Eval("UnitPrice"), 2))%></span>
                                </td>
                                <td data-title="Cantidad" style="width: 116px;">
                                    <div class="input-group">
                                        <input type="text" id="cantidad_<%#Trim(Eval("ProductID"))%>_<%#Trim(Eval("Unidad"))%>" placeholder="0.00" min="0" style="text-align: center; width: 65px;" />
                                        <span class="input-group-btn">
                                            <button class="btn btn-default"></button>
                                        </span>
<%--                                        <div class="btn" onclick="return AddCart(' <%#Trim(Eval("ProductID"))%>,<%#Trim(Eval("Unidad"))%>');" style="width: 40px;">
                                            <span class="add-to-cart">
                                                <span class="action-wrapper">
                                                    <i class="icons icon-basket-2"></i>
                                                    <span class="action-name" id="txtBotonCarAdd" runat="server" meta:resourcekey="txtBotonCarAdd"></span>
                                                </span>
                                            </span>
                                        </div>--%>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            No productos para mostrar
                        </EmptyDataTemplate>
                    </asp:ListView>
                </tbody>
            </table>
        </div>
    </section>
</asp:Content>