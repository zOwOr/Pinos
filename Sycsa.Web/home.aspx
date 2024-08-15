<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="home.aspx.vb" Inherits="sycsa.Web.home" %>




<asp:Content ID="Content1" ContentPlaceHolderID="Html_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Html_Content" runat="server">
    <div class="container-fluid">


        <asp:HyperLink ID="hlProduct" CssClass="btn btn-warning" runat="server" NavigateUrl='<%# WebmailUrl %>' Target="_blank">
            WEBMAIL <i class="bi bi-envelope-at-fill"></i>
        </asp:HyperLink>




        <div id="carouselExampleCaptions" class="carousel slide carousel-fade m-5" data-bs-ride="carousel" data-bs-interval="4000">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2" aria-label="Slide 3"></button>
            </div>
            <div class="carousel-inner rounded-5 shadow-lg p-3 mb-5 bg-light bg-gradient">
                <div class="carousel-item active">
                    <img class="d-block w-100" src='/local/imagenes/slide1.jpg' alt="First slide" width="870px" height="397px">
                    <h2 class="text-light font-weight-bold"><%Response.Write(Html._Layout_img1_titulo) %></h2>
                    <h4 class="text-light"><%Response.Write(Html._Layout_img1_descripcion) %></h4>
                </div>

                <div class="carousel-item">
                    <img class="d-block w-100" src='/local/imagenes/slide2.jpg' alt="Second slide" width="870px" height="397px" />
                    <div class="carousel-caption d-none d-md-block">
                        <h2 class="text-light font-weight-bold"><%Response.Write(Html._Layout_img2_titulo) %></h2>
                        <h4 class="text-light"><%Response.Write(Html._Layout_img2_descripcion) %></h4>
                    </div>
                </div>
                <div class="carousel-item">
                    <img class="d-block w-100" src='/local/imagenes/slide3.png' alt="Third slide" width="870px" height="397px" />
                    <div class="carousel-caption d-none d-md-block">
                        <h2 class="text-light font-weight-bold"><%Response.Write(Html._Layout_img3_titulo) %></h2>
                        <h4 class="text-light"><%Response.Write(Html._Layout_img3_descripcion) %></h4>
                    </div>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
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



    <div class="card">
        <div class="card-header">
            <h2>Ultimos productos comprados</h2>
        </div>
        <div class="card-body">
            <div class="d-flex justify-content-center">
                <button type="button" class="btn btn-warning text-center" onclick="addAllToCart()">
                    <i class="bi bi-cart-plus-fill"></i>Agregar seleccionados al carrito
                </button>
            </div>

            <div class="table-responsive" style="height: 400px; overflow-y: auto;">

                <asp:GridView ID="gvListProductos" runat="server" CssClass="table table-bordered table-striped table-condensed cf" AutoGenerateColumns="False"
                    DataKeyNames="IdProduct" Width="100%" EmptyDataText="Inicia sesión para ver tus últimos productos comprados" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="IdProduct" Visible="false"></asp:BoundField>
                        <asp:TemplateField HeaderText="Imagen">
                            <HeaderStyle CssClass="text-center fw-bold" />
                            <ItemStyle CssClass="text-center align-middle" />
                            <ItemTemplate>
                                <img src='<%# Eval("ProductImagen") %>' alt="Producto sin imagen" class="img-thumbnail" style="width: 100px; height: auto;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Producto">
                            <HeaderStyle CssClass="text-center fw-bold" />
                            <ItemStyle CssClass="text-center align-middle" />
                            <ItemTemplate>
                                <%# Eval("Producto")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Unidad">
                            <HeaderStyle CssClass="text-center fw-bold" />
                            <ItemStyle CssClass="text-center align-middle" />
                            <ItemTemplate>
                                <%# Eval("unidad")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cantidad">
                            <HeaderStyle CssClass="text-center fw-bold" />
                            <ItemStyle CssClass="text-center align-middle" />
                            <ItemTemplate>
                                <div class="row justify-content-center">
                                    <div class="col-12">
                                        <input type="number" id="cantidad_<%#Trim(Eval("IdProduct"))%>_<%#Trim(Eval("Unidad"))%>"
                                            placeholder="0.00" class="col-6" min="0" style="text-align: center; width: 65px;" oninput="saveQuantities()" />
                                    </div>
                                    <%--                                    <div class="col-6">


                                         <button type="button" class="btn btn-sm btn-orange btn-warning rounded-circle col-6" onclick="return AddCart(' <%#Trim(Eval("IdProduct"))%>,<%#Trim(Eval("Unidad"))%>');" style="--size: 42px; width: var(--size); height: var(--size)">
                                            <i class="bi bi-cart4"></i>
                                        </button> 
                                    </div>--%>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>


            </div>
        </div>
    </div>



    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Html_sidebar" runat="server">

    <script>
        // Función para agregar un producto individual al carrito
        function AddCart(e) {
            eventTarget = "addCart";
            let cantidad = $('#cantidad_' + e.split(",")[0].trim() + "_" + e.split(",")[1].trim()).val();
            cantidad = cantidad > 0 ? cantidad : 1;
            __doPostBack(eventTarget, e.trim() + "," + cantidad);
        }

        // Función para actualizar la cantidad
        function AddCant(e) {
            var a = e.value;
            $("#" + e.id).val(a);
        }

        // Función para cargar las cantidades almacenadas en localStorage
        function loadQuantities() {
            $("input[id^='cantidad_']").each(function () {
                let ids = this.id.split('_');
                let key = ids[1] + '_' + ids[2];
                let storedQuantity = localStorage.getItem(key);
                if (storedQuantity) {
                    $(this).val(storedQuantity);
                }
            });
        }

        // Función para guardar las cantidades en localStorage
        function saveQuantities() {
            $("input[id^='cantidad_']").each(function () {
                let cantidad = parseFloat($(this).val());
                let ids = this.id.split('_');
                let key = ids[1] + '_' + ids[2];
                if (cantidad >= 1) {
                    localStorage.setItem(key, cantidad);
                } else {
                    localStorage.removeItem(key);
                }
            });
        }

        // Función para agregar todos los productos al carrito
        function addAllToCart() {
            saveQuantities();
            let items = [];
            for (let i = 0; i < localStorage.length; i++) {
                let key = localStorage.key(i);
                let value = localStorage.getItem(key);
                let ids = key.split('_');
                let productID = ids[0];
                let unidad = ids[1];
                items.push(productID + ',' + unidad + ',' + value);
            }

            if (items.length > 0) {
                // Guardar estado de DataTables
                let search = $('.dataTables_filter input').val();
                let order = $('#myTable').DataTable().order();
                localStorage.setItem('dtSearch', search);
                localStorage.setItem('dtOrder', JSON.stringify(order));

                __doPostBack("addAllToCart", items.join('|'));
            }
        }
    </script>
</asp:Content>
