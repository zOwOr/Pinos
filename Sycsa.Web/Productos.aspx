<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="Productos.aspx.vb" Inherits="sycsa.Web.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Html_head" runat="server">
    <!-- Incluye jQuery y jQuery UI -->
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/sweetalert2@11/dist/sweetalert2.min.css">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>

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

        // Función para filtrar la tabla según la entrada del usuario
        function filterTable() {
            let input = document.getElementById('searchInput');
            let filter = input.value.toLowerCase();
            let table = document.getElementById('myTable');
            let rows = table.getElementsByTagName('tr');

            for (let i = 1; i < rows.length; i++) {
                let cells = rows[i].getElementsByTagName('td');
                let match = false;

                for (let j = 1; j < cells.length; j++) {
                    let cell = cells[j];
                    if (cell) {
                        let text = cell.textContent || cell.innerText;
                        if (text.toLowerCase().indexOf(filter) > -1) {
                            match = true;
                            break;
                        }
                    }
                }

                rows[i].style.display = match ? '' : 'none';
            }
        }

        // Función para buscar productos con autocompletado
        $(function () {
            $("#<%= SearchBox.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%= ResolveUrl("~/GetSuggestions.aspx") %>', // URL del servicio que devuelve las sugerencias
                        dataType: 'json',
                        data: {
                            term: request.term
                        },
                        success: function (data) {
                            response(data);
                        }
                    });
                },
                select: function (event, ui) {
                    searchProducts();
                }
            });
        });

        function searchProducts() {
            var searchTerm = document.getElementById('<%= SearchBox.ClientID %>').value;
            var pageUrl = '<%= ResolveUrl("~/Productos.aspx") %>' + '?searchTerm=' + encodeURIComponent(searchTerm);
            window.location.href = pageUrl;
        }


        function generateShareLink(productID) {
            // Construir el enlace al modal específico del producto
            const baseUrl = window.location.href.split('?')[0]; // Obtiene la URL base sin parámetros
            const link = `${baseUrl}?modal=productModal_${productID}`;

            // Establecer el enlace en el campo de texto
            const inputField = document.getElementById(`shareLink_${productID}`);
            inputField.value = link;

            // Seleccionar el texto del campo de texto
            inputField.select();
            inputField.setSelectionRange(0, 99999); // Para dispositivos móviles

        }


        function CopyLink(productID) {
            // Copiar el enlace al portapapeles

            const baseUrl = window.location.href.split('?')[0]; // Obtiene la URL base sin parámetros
            const link = `${baseUrl}?modal=productModal_${productID}`;

            // Establecer el enlace en el campo de texto
            const inputField = document.getElementById(`shareLink_${productID}`);
            inputField.value = link;

            // Seleccionar el texto del campo de texto
            inputField.select();
            inputField.setSelectionRange(0, 99999); // Para dispositivos móviles

            navigator.clipboard.writeText(link)
                .then(() => {
                    const Toast = Swal.mixin({
                        toast: true,
                        position: "top-end",
                        showConfirmButton: false,
                        timer: 3000,
                        timerProgressBar: true,
                        didOpen: (toast) => {
                            toast.onmouseenter = Swal.stopTimer;
                            toast.onmouseleave = Swal.resumeTimer;
                        }
                    });
                    Toast.fire({
                        icon: "success",
                        title: 'Enlace copiado al portapapeles: '
                    });

                })
                .catch(err => {


                    const Toast = Swal.mixin({
                        toast: true,
                        position: "top-end",
                        showConfirmButton: false,
                        timer: 3000,
                        timerProgressBar: true,
                        didOpen: (toast) => {
                            toast.onmouseenter = Swal.stopTimer;
                            toast.onmouseleave = Swal.resumeTimer;
                        }
                    });
                    Toast.fire({
                        icon: "error",
                        title: 'No se pudo copiar el enlace al portapapeles.'
                    });


                });
        }


    </script>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Html_sidebar" runat="server">
    <!-- Categories -->
    <div class="sidebar-header">
        <h3 class="text-center">Productos</h3>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Html_Content" runat="server">
    <div id="spinner" class="justify-content-center" style="display: flex; flex-direction: column; align-items: center;">
        <div class="spinner-grow text-warning" style="width: 9rem; height: 9rem;" role="status">
            <span class="visually-hidden"></span>
        </div>
        <br />
        <h2 class="text-body-secondary fst-italic">Cargando productos ...</h2>
    </div>

    <div class="container mt-4">
        <div class="row gx-3">
            <div class="col-md-6">
                <label for="searchField" class="form-label">Buscar en:</label>

                <asp:DropDownList ID="ddlFamilia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFamilia_SelectedIndexChanged" CssClass="form-select">
                </asp:DropDownList>
            </div>
            <div class="col-md-6">
                <label for="SearchBox" class="form-label">&nbsp;</label>
                <asp:DropDownList ID="ddlSubfamilia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubfamilia_SelectedIndexChanged" CssClass="form-select">
                </asp:DropDownList>
            </div>

        </div>
    </div>



    <div class="card my-5  rounded-5 shadow-lg">
        <div class="card-header text-center">
            <div class="row m-4">
                <div class="col-md-4 mb-3">
                    <asp:DropDownList ID="searchField" runat="server" CssClass="form-select">
                        <asp:ListItem Value="all" Selected>Buscar en Todas las Columnas</asp:ListItem>
                        <asp:ListItem Value="clave">Clave</asp:ListItem>
                        <asp:ListItem Value="descripcion">Producto</asp:ListItem>
                        <asp:ListItem Value="codigo_pv">Código Pv</asp:ListItem>
                        <asp:ListItem Value="codigo_fac">Código Fac</asp:ListItem>
                        <asp:ListItem Value="familia">Familia</asp:ListItem>
                        <asp:ListItem Value="sub_fam">Subfamilia</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-6 mb-3">
                    <asp:TextBox ID="SearchBox" runat="server" CssClass="form-control" Placeholder="Buscar..." />


                </div>
                <div class="col-md-2 ">

                    <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" CssClass="btn btn-primary w-100" Text="Buscar" />
                </div>
            </div>
            <button type="button" class="btn btn-warning" onclick="addAllToCart()"><i class="bi bi-cart-plus-fill"></i>Agregar seleccionados al carrito</button>
        </div>

        <div id="tablehidden" hidden="hidden" class="card-body">
            <table id="myTable" class="table table-hover  table-striped display align-middle " style="width: 100%">
                <thead class="thead-dark ">
                    <tr>
                        <th>Ver</th>
                        <th>Producto</th>
                        <th class="numeric">Familia</th>
                        <th class="numeric">Subfamilia</th>
                        <th class="numeric">Codigo Pv</th>
                        <th class="numeric">Codigo Fac</th>
                        <th class="numeric">Unidad</th>
                        <th class="numeric">Existencias</th>
                        <th class="numeric">Precio</th>
                        <th class="numeric">Comprar</th>
                        <th class="numeric">Clave</th>

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
                                <td data-title="Ver producto" class="text-center">
                                    <a href="#" data-bs-toggle="modal" data-bs-target="#productModal_<%# Eval("ProductID") %>" onclick="generateShareLink('<%# Eval("ProductID") %>')">
                                        <button type="button" style="width: 42px; height: 42px;" class="btn btn-primary rounded-circle ">
                                            <i class="bi bi-eye"></i>
                                        </button>
                                    </a>
                                </td>


                                <td data-title="Producto">
                                    <span><%# Eval("shortDescription") %></span>

                                </td>
                                <!-- Bootstrap Modal -->
                                <div class="modal fade" id="productModal_<%# Eval("ProductID") %>" tabindex="-1" aria-labelledby="productModalLabel" aria-hidden="true">
                                    <div class="modal-dialog modal-dialog-centered modal-lg">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title" id="productModalLabel"><%# Eval("shortDescription") %></h5>
                                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                            </div>
                                            <div class="modal-body bg-light-subtle">
                                                <div class="container">
                                                    <div class="row mb-3">
                                                        <div class="col-9">
                                                            <input type="text" id="shareLink_<%# Eval("ProductID") %>" class="form-control" readonly>
                                                        </div>
                                                        <div class="col-3">
                                                        <button type="button" class="btn btn-dark" onclick="CopyLink('<%# Eval("ProductID") %>')">Copiar Enlace</button>
                                                        </div>

                                                    </div>
                                                    <div class="row">
                                                        <div class="col">
                                                            <!-- Detalles del producto -->
                                                            <h6>Detalles del producto</h6>
                                                            <p>Familia: <strong><%# GetCategoryDisplay(Eval("Categoria")) %></strong></p>
                                                            <p>Codigo Pv: <strong><%# Getcodigo_pvDisplay(Eval("codigo_pv")) %></strong></p>
                                                            <p>Codigo Fac: <strong><%# Getcodigo_facDisplay(Eval("codigo_fac")) %></strong></p>
                                                            <p>Precio: <strong><%# Eval("UnitPrice")%></strong></p>
                                                            <p>Codigo: <strong><%#Eval("ProductID") %></strong></p>

                                                            <input type="number" id="cantidad2_<%#Trim(Eval("ProductID"))%>_<%#Trim(Eval("Unidad"))%>"
                                                                placeholder="0.00" min="0" style="text-align: center; width: 65px;"
                                                                oninput="saveQuantities()" />

                                                            <button type="button" class="btn btn-sm btn-orange btn-warning rounded-circle" onclick="return AddCart('<%#Trim(Eval("ProductID"))%>,<%#Trim(Eval("Unidad"))%>');" style="--size: 42px; width: var(--size); height: var(--size)">
                                                                <i class="bi bi-cart4"></i>
                                                            </button>

                                                            <!-- Add more details as needed -->
                                                        </div>
                                                        <div class="col-6 text-center">
                                                            <img src=" <%#Eval("ProductImagen")%>" class="img-fluid img-thumbnail rounded" alt="Producto sin imagen" style="height: 300px; width: auto;">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="modal-footer">

                                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>




                                <td data-title="Familia" class="numeric">
                                    <%# Eval("Categoria")%>
                                </td>
                                <td data-title="Subfamilia" class="numeric">
                                    <%# Eval("Subcategoria")%>
                                </td>
                                <td data-title="Codigo Pv" class="numeric">
                                    <%# Eval("codigo_pv")%>
                                </td>
                                <td data-title="Codigo Fac" class="numeric">
                                    <%# Eval("codigo_fac")%>
                                </td>
                                <td data-title="Unidad" class="numeric">
                                    <%# Eval("Unidad")%>
                                </td>
                                <td data-title="existencias" class="numeric">
                                    <%# Eval("EXISTENCIA")%>
                                </td>
                                <td data-title="Precio" class="numeric">
                                    <h6 class="fst-italic "><%# Eval("UnitPrice")%></h6>
                                </td>
                                <td data-title="Cantidad row">
                                    <input type="number" id="cantidad_<%#Trim(Eval("ProductID"))%>_<%#Trim(Eval("Unidad"))%>"
                                        placeholder="0.00" class="col-6" min="0" style="text-align: center; width: 65px;" oninput="saveQuantities()" />

                                    <button type="button" class="btn btn-sm btn-orange btn-warning rounded-circle col-6" onclick="return AddCart(' <%#Trim(Eval("ProductID"))%>,<%#Trim(Eval("Unidad"))%>');" style="--size: 42px; width: var(--size); height: var(--size)">
                                        <i class="bi bi-cart4"></i>
                                    </button>
                                </td>
                                <td data-title="Unidad" class="numeric">
                                    <%# Eval("ProductID")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            No productos para mostrar
                        </EmptyDataTemplate>
                    </asp:ListView>
                    <asp:PlaceHolder ID="PaginationPlaceholder" runat="server"></asp:PlaceHolder>
                    <asp:Label ID="lblProductCount" runat="server" CssClass="form-label"></asp:Label>

                </tbody>
            </table>



        </div>
        <div class="card-footer text-center">
            <button type="button" class="btn btn-warning" onclick="addAllToCart()"><i class="bi bi-cart-plus-fill"></i>Agregar seleccionados al carrito</button>
        </div>

    </div>
</asp:Content>
