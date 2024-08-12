<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="ShowProduct.aspx.vb" Inherits="sycsa.Web.ShowProduct" %>

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
     <aside class="sidebar">
        <!-- Categories -->
        <div class="sidebar-header">
            <h3>Categorias</h3>
        </div>
    </aside>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Html_Content" runat="server">
    <section class="col-lg-10 col-md-10 col-sm-10">
        <div>
            <div id="product-single" class="product-single">
                <div class="row">
                    <!-- Product Images Carousel -->
                    <div class="col-lg-5 col-md-5 col-sm-5 product-single-image">
                        <div id="product-slider">
                            <ul class="slides">
                                <li>
                                    <asp:Image ID="ImagenDefaultProduct" runat="server" AlternateText="" CssClass="cloud-zoom" />
                                    <asp:HyperLink ID="LInkFullScreen_Button" runat="server" CssClass="fullscreen-button">
                                         <div class="product-fullscreen">
                                           <%-- <i class="icons icon-resize-full-1"></i>--%>
                                        </div>
                                    </asp:HyperLink>
                                </li>
                            </ul>
                        </div>
                        <div id="htmlDivCarousel" runat="server">
                            <div id="product-carousel">
                                <ul id="PanelImagen" runat="server" class="slides">
                                </ul>
                                <div class="product-arrows">
                                    <div class="left-arrow">
                                        <i class="icons icon-left-dir"></i>
                                    </div>
                                    <div class="right-arrow">
                                        <i class="icons icon-right-dir"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-7 col-md-7 col-sm-7 product-single-info">

                        <h2 id="txtProductName" runat="server"></h2>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="txtLabelMark" runat="server" Text="Manufacturer" meta:resourcekey="txtLabelMark"></asp:Label></td>
                                <td>
                                    <asp:HyperLink ID="LinkMark" runat="server" NavigateUrl=""></asp:HyperLink></td>
                            </tr>
                            <tr id="HmtlUnitStock" runat="server">
                                <td>
                                    <asp:Label ID="txtLabelAvailability" runat="server" Text="Availability" meta:resourcekey="txtLabelAvailability"></asp:Label></td>
                                <td><span class="green">in stock</span>
                                    <asp:Label ID="txtAvailability" runat="server" Text="0"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="txtLabelCodeProduct" runat="server" Text="Product code" meta:resourcekey="txtLabelCodeProduct"></asp:Label></td>
                                <td>
                                    <asp:Label ID="txtCodeProduct" runat="server" Text="---"></asp:Label></td>
                            </tr>
                        </table>



                        <span id="Htmlprice" runat="server" class="price">
                            <asp:Label ID="txtPrice" runat="server" Text="0"></asp:Label></span>

                        <div id="txtshortDescriptionProduct" runat="server" style="font-style: normal; text-align: justify; font-size: 12px; padding-right: 10px; padding-top: 6px;">
                        </div>
                        <div id="tab1Description" runat="server">
                        </div>

                        <table class="product-actions-single">
                            <tr>
                                <td>
                                    <asp:Label ID="txtLabelQuantity" runat="server" Text="Quantity" meta:resourcekey="txtLabelQuantity"></asp:Label></td>
                                <td class="grid-view product">
                                    <input type="number" id="cantidad_<%=_ProductID%>_<%=_Unidad%>" placeholder="0.00" min="0" onchange="AddCant(this);" style="text-align: center; width: 64px; height: auto;" />
                                    <%-- <input id="txTQuantity" type="text"runat="server" value="1">--%>
                                    <%--  <span class="arrow-up"><i class="icons icon-up-dir"></i></span>
                                        <span class="arrow-down"><i class="icons icon-down-dir"></i></span>--%>
                                    <div onclick="return AddCart(' <%=_ProductID%>,<%=_Unidad%>');" class="tooltip-cart">
                                        <span class="add-to-cart">
                                            <span class="action-wrapper">
                                                <i class="icons icon-basket-2"></i>
                                                <span id="txtLabelButtonCart" runat="server" class="action-name" style="font-size: 11px;"></span>
                                            </span>
                                        </span>
                                    </div>
                                </td>
                            </tr>
                        </table>




                    </div>

                </div>
            </div>

            <!-- Product Tabs -->
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12">

                    <div class="tabs">
                        <div class="tab-heading">
                            <asp:HyperLink ID="LinkTabs1" runat="server" NavigateUrl="#tab1Description" CssClass="button big" Text="Descripción" meta:resourcekey="LinkTabs1"></asp:HyperLink>
                        </div>
                        <div class="page-content tab-content">
                            <%--                            <div id="tab1Description" runat="server">
                            </div>--%>
                        </div>
                    </div>

                </div>
            </div>
            <!-- New Collection -->
            <div class="products-row row">

                <!-- Carousel Heading -->
                <div class="col-lg-12 col-md-12 col-sm-12">

                    <div class="carousel-heading">
                        <h4 id="txtLabelRelatedProducts" runat="server" meta:resourcekey="LinkTabs1">Related Products</h4>
                        <div class="carousel-arrows">
                            <i class="icons icon-left-dir"></i>
                            <i class="icons icon-right-dir"></i>
                        </div>
                    </div>

                </div>
                <!-- /Carousel Heading -->
                <!-- Carousel -->
                <div class="carousel owl-carousel-wrap col-lg-12 col-md-12 col-sm-12">
                    <div id="HtmlCarousel" runat="server" class="owl-carousel" data-max-items="3">
                    </div>
                </div>

            </div>

        </div>
    </section>

</asp:Content>


