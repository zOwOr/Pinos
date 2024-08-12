<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="CheckoutShipping.aspx.vb" Inherits="sycsa.Web.CheckoutShipping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Html_head" runat="server">

    <%--<script type="text/javascript">

        function CheckOtherIsCheckedByGVID(rb) {

            var isChecked = rb.checked;
            var row = rb.parentNode.parentNode.parentNode;

            var _ifMehtodSend = document.getElementById('HfMethosSend');
            _ifMehtodSend.value = rb.value;

            if (isChecked) {
                row.style.backgroundColor = '#ffd800';
                row.style.color = 'black';
            }

            var currentRdbID = rb.id;
            var parent = document.getElementById("<%= gvMethodSend.ClientID%>");
            var items = parent.getElementsByTagName('input');

            for (i = 0; i < items.length; i++) {
                if (items[i].id != currentRdbID && items[i].type == "radio") {

                    if (items[i].checked) {
                        items[i].checked = false;
                        items[i].parentNode.parentNode.parentNode.style.backgroundColor = 'white';
                        items[i].parentNode.parentNode.parentNode.style.color = '#696969';
                    }
                }
            }
        }

    </script>--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Html_Content" runat="server">

    <div class="row my-5">
        <div class="col-lg-6">

            <div class="row">
                <%-- <div class="col-lg-12">

                    <div class="carousel-heading no-margin">
                        <h4 id="lblShippingWay" runat="server" meta:resourcekey="lblShippingWay">Formas de envío</h4>
                    </div>
                      <div class="page-content">
                        <p id="lblTAext1" runat="server" meta:resourcekey="lblTAext1">
                            Seleccione una de las formas de envío para sus productos del carrito
                            (click sobre el metodo de envío)
                        </p>

                        <asp:GridView ID="gvMethodSend" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqShippingway"
                            CssClass="shopping-table" Width="100%" EnableTheming="False" ClientIDMode="Static" ShowHeader="False">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" InsertVisible="False" SortExpression="ID" Visible="false"></asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>

                                        <label style="cursor: pointer; font-weight: bold;">
                                            <asp:RadioButton ID="rb" runat="server" onclick="javascript:CheckOtherIsCheckedByGVID(this);"
                                                ClientIDMode="AutoID" value='<%#Eval("ID")%>' />
                                            <%#Eval("Method")%></label>

                                    </ItemTemplate>
                                    <HeaderStyle></HeaderStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="MethodPrice" HeaderText="" SortExpression="MethodPrice" DataFormatString="{0:C}"></asp:BoundField>
                                <asp:BoundField DataField="Comment" HeaderText="" SortExpression="Comment"></asp:BoundField>
                            </Columns>
                        </asp:GridView>


                        <asp:SqlDataSource runat="server" ID="SqShippingway" ConnectionString='<%$ ConnectionStrings:MySQLConnection %>'
                            ProviderName='<%$ ConnectionStrings:MySQLConnection.ProviderName %>'
                            SelectCommand="SELECT ID, Method, MethodPrice, Comment FROM shippingway where active = 1 "></asp:SqlDataSource>
                    </div>
                </div>--%>

                    <div class="card">
                        <div class="card-header">
                            <h4 id="lblTitleNotesShipping" runat="server" meta:resourcekey="lblTitleNotesShipping">Notas especiales</h4>
                        </div>
                        <div class="card-body">
                            <h5 class="card-title my-5 text-center">Comentarios Sobre Su Orden</h5>

                            <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" CssClass="form-control border border-black" style="height: 500px"></asp:TextBox>

                        </div>
                    </div>

            </div>
        </div>

        <div class="col-lg-6">




            <div class="card">
                <div class="card-header">
                    <h4 id="DeliveryData" runat="server" meta:resourcekey="lblShippingWay">Datos de Entrega</h4>
                </div>
                <div class="card-body">
                    <p class="card-title lead mb-3">Por favor verifique su información, una vez confirmado su pago y liberado el pedido no será posible realizar cambios.</p>
                    <%--<p style="text-align: right;">

                        <button id="btnChangeAddress" type="button" class="product-hover" runat="server" meta:resourcekey="btnChangeAddress"
                            onclick="window.open('seleccAddress.aspx','','left=35px;menubar=no,directories=no,top=25px,resizable=yes,scrollbars=yes');">
                            Cambiar dirección 
                        </button>
                    </p>--%>
                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtorden" runat="server" ReadOnly="false" CssClass="form-control" placeholder="Orden de Compra"></asp:TextBox>
                        <label for="txtorden">Orden de Compra</label>

                    </div>

                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" ReadOnly="true" placeholder="Nombre"></asp:TextBox>
                        <label for="txtName">Nombre</label>
                    </div>

                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtLastName" runat="server" ReadOnly="true" CssClass="form-control" placeholder="Apellidos"></asp:TextBox>
                        <label for="txtLastName">Apellidos</label>
                    </div>


                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtPhone" runat="server" ReadOnly="true" CssClass="form-control" placeholder="Teléfono"></asp:TextBox>
                        <label for="txtPhone">Teléfono </label>
                    </div>

                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtAdress" runat="server" ReadOnly="true" CssClass="form-control" placeholder="Dirección"></asp:TextBox>
                        <label for="txtAdress">Dirección</label>
                    </div>

                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtColony" runat="server" ReadOnly="true" CssClass="form-control" placeholder="Colonia"></asp:TextBox>
                        <label for="txtColony">Colonia</label>
                    </div>

                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtCP" runat="server" ReadOnly="true" CssClass="form-control" placeholder="Código Postal"></asp:TextBox>
                        <label for="txtCP">Código Postal</label>
                    </div>


                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtCity" runat="server" ReadOnly="true" CssClass="form-control" placeholder="Ciudad"></asp:TextBox>
                        <label for="txtCity">Ciudad</label>
                    </div>


                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtState" runat="server" ReadOnly="true" CssClass="form-control" placeholder="Estado"></asp:TextBox>
                        <label for="txtState">Estado</label>
                    </div>

                    <div class="form-floating mb-3">
                        <asp:TextBox ID="txtCountry" runat="server" ReadOnly="true" CssClass="form-control" placeholder="País"></asp:TextBox>
                        <label for="txtCountry">País</label>
                    </div>



                    <%--<label id="lblCompany" for="txtCompany" runat="server" meta:resourcekey="lblCompany">Empresa</label>
                    <asp:TextBox ID="txtCompany" runat="server" ReadOnly="true"></asp:TextBox>

                    <label id="lblRFC" for="txtRFC" runat="server" meta:resourcekey="lblRFC">RFC</label>
                    <asp:TextBox ID="txtRFC" runat="server" ReadOnly="true"></asp:TextBox>--%>
                </div>
                <div class="card-footer text-center">
                    <asp:Button ID="btnContinue" runat="server" Text="Continuar" meta:resourcekey="btnContinue" Font-Bold="true" CssClass="btn btn-lg btn-success" />

                </div>
            </div>






        </div>

    </div>


    <asp:HiddenField ID="HfMethosSend" runat="server" Value="0" ClientIDMode="Static" />
    <asp:HiddenField ID="Hfaddress" runat="server" Value="0" />
</asp:Content>
