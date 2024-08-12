<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="home.aspx.vb" Inherits="sycsa.Web.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Html_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Html_Content" runat="server">
    <section class="col-lg-12 col-md-12 col-sm-12">
        <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
            <ol class="carousel-indicators">
                <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
            </ol>
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img class="d-block w-100" src="img/slide20.jpg" alt="First slide" Width="870px" Height="397px" />
                    <div class="carousel-caption d-none d-md-block">
                        <h2 class="text-light font-weight-bold"><%Response.Write(Html._Layout_img1_titulo) %></h2>
                        <h4 class="text-light"><%Response.Write(Html._Layout_img1_descripcion) %></h4>
                    </div>
                </div>
                <div class="carousel-item">
                    <img class="d-block w-100" src="img/slide10.jpg" alt="Second slide" Width="870px" Height="397px" />
                    <div class="carousel-caption d-none d-md-block">
                        <h2 class="text-light font-weight-bold"><%Response.Write(Html._Layout_img2_titulo) %></h2>
                        <h4 class="text-light"><%Response.Write(Html._Layout_img2_descripcion) %></h4>
                    </div>
                </div>
                <div class="carousel-item">
                    <img class="d-block w-100" src="img/slide30.jpg" alt="Third slide" Width="870px" Height="397px" />
                    <div class="carousel-caption d-none d-md-block">
                        <h2 class="text-light font-weight-bold"><%Response.Write(Html._Layout_img3_titulo) %></h2>
                        <h4 class="text-light"><%Response.Write(Html._Layout_img3_descripcion) %></h4>
                    </div>
                </div>
            </div>
            <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
        <%--<section class="carousel slide">
            <div class="tp-banner-container">
                <div class="tp-banner">
                    <ul>
                        <!-- SLIDE  -->
                        <li data-transition="fade" data-slotamount="7" data-masterspeed="1500">
                            <!-- MAIN IMAGE -->
                            <img src="img/slide1.jpg" alt="slidebg1" data-bgfit="cover" data-bgposition="left top" data-bgrepeat="no-repeat">
                            <!-- LAYERS -->
                            <div class="tp-caption skewfromrightshort fadeout"
                                data-x="40"
                                data-y="60"
                                data-speed="500"
                                data-start="1200"
                                data-easing="Power4.easeOut">
                                <h2><strong>Lorem Ipsum Dolor</strong></h2>
                            </div>
                            <div class="tp-caption skewfromrightshort fadeout"
                                data-x="40"
                                data-y="140"
                                data-speed="500"
                                data-start="1200"
                                data-easing="Power4.easeOut">
                                <h3>All the power in your hands!</h3>
                            </div>
                            <div class="tp-caption skewfromrightshort fadeout"
                                data-x="40"
                                data-y="250"
                                data-speed="500"
                                data-start="1200"
                                data-easing="Power4.easeOut">
                                <span>From <span class="price">$960.00</span></span>
                            </div>
                            <div class="tp-caption skewfromrightshort fadeout"
                                data-x="40"
                                data-y="300"
                                data-speed="500"
                                data-start="1200"
                                data-easing="Power4.easeOut">
                                <a class="button big red" href="#">Buy Now</a>
                            </div>
                        </li>
                        <!-- SLIDE  -->
                        <li data-transition="zoomout" data-slotamount="7" data-masterspeed="1000">
                            <!-- MAIN IMAGE -->
                            <img src="img/slide3.jpg" alt="darkblurbg" data-bgfit="cover" data-bgposition="left top" data-bgrepeat="no-repeat">
                            <!-- LAYERS -->
                            <div class="tp-caption skewfromrightshort fadeout"
                                data-x="40"
                                data-y="60"
                                data-speed="500"
                                data-start="1200"
                                data-easing="Power4.easeOut">
                                <h2><strong>The New Studio<br>
                                    Original Headphones</strong></h2>
                            </div>
                            <div class="tp-caption skewfromrightshort fadeout"
                                data-x="40"
                                data-y="190"
                                data-speed="500"
                                data-start="1200"
                                data-easing="Power4.easeOut">
                                <h3>Lorem ipsum dolor</h3>
                            </div>
                            <div class="tp-caption skewfromrightshort fadeout"
                                data-x="40"
                                data-y="300"
                                data-speed="500"
                                data-start="1200"
                                data-easing="Power4.easeOut">
                                <span>Only <span class="price">$399.00</span></span>
                            </div>
                            <div class="tp-caption skewfromrightshort fadeout"
                                data-x="40"
                                data-y="347"
                                data-speed="500"
                                data-start="1200"
                                data-easing="Power4.easeOut">
                                <a class="button big red" href="#">Shop Now</a>
                            </div>
                        </li>
                        <!-- SLIDE  -->
                        <li data-transition="zoomout" data-slotamount="7" data-masterspeed="1000">
                            <!-- MAIN IMAGE -->
                            <img src="img/slide2.jpg" alt="darkblurbg" data-bgfit="cover" data-bgposition="left top" data-bgrepeat="no-repeat">
                            <!-- LAYERS -->
                            <div class="tp-caption skewfromrightshort fadeout"
                                data-x="40"
                                data-y="60"
                                data-speed="500"
                                data-start="1200"
                                data-easing="Power4.easeOut">
                                <h2>The New <strong>Laptop</strong></h2>
                            </div>
                            <div class="tp-caption skewfromrightshort fadeout"
                                data-x="40"
                                data-y="140"
                                data-speed="500"
                                data-start="1200"
                                data-easing="Power4.easeOut">
                                <h3>All the power in your hands!</h3>
                            </div>
                            <div class="tp-caption skewfromrightshort fadeout"
                                data-x="40"
                                data-y="250"
                                data-speed="500"
                                data-start="1200"
                                data-easing="Power4.easeOut">
                                <span>From <span class="price">$990.00</span></span>
                            </div>
                            <div class="tp-caption skewfromrightshort fadeout"
                                data-x="40"
                                data-y="300"
                                data-speed="500"
                                data-start="1200"
                                data-easing="Power4.easeOut">
                                <a class="button big red" href="#">Buy Now</a>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </section>--%>
        <div class="album py-5 bg-light">
            <div class="carousel-heading">
                <h2>Ultimos productos comprados</h2>
            </div>
            <div class="no-more-tables">
                <asp:GridView ID="gvListProductos" runat="server" CssClass="table table-bordered table-striped table-condensed cf" AutoGenerateColumns="False"
                    DataKeyNames="IdProduct" Width="100%" EmptyDataText="Inicia secion para ver tus ultimos productos comprados" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="IdProduct" Visible="false"></asp:BoundField>
                        <%--                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>                           
                              <img src="imagen/products/sample4-thumb.jpg" alt="" width="100%" class="img-thumbnail" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="image-column"></ItemStyle>
                    </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Producto">
                            <ItemTemplate>
                                <%# Eval("Producto")%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unidad">
                            <ItemTemplate>
                                <%# Eval("unidad")%>
                                <%--<%# IIf(Session("MM_Lista") Is Nothing, "", FormatCurrency(Eval("Precio")))%>--%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cantidad">
                            <ItemTemplate>

                                <div class="row" style="width: 230px; margin: auto;">

                                    <div class="col-lg-6">
                                        <asp:TextBox runat="server" type="number" min="0" ID="txtCantidad" placeholder="0.00" Style="text-align: center;" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-6">
                                        <asp:LinkButton runat="server" ID="LinkButton1" CommandName="Update" CssClass="red-hover"
                                            CommandArgument='<%# Eval("IdProduct").ToString() & "," & Eval("Unidad") %>' Style="font-size: 12px;">
                                            <i class="icons icon-ok-3"></i>
                                            <label id="Label1" runat="server">Agregar al carrito</label>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </section>
</asp:Content>

