<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="CheckoutPayment.aspx.vb" Inherits="sycsa.Web.CheckoutPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Html_head" runat="server">

    <script type="text/javascript">
        function Fill(ev) {
            var input = document.getElementById("<%=chFill.ClientID%>");
            var isChecked = input.checked;
            if (isChecked) {
                document.getElementById("fielFill").style = "display:normal";
            } else {
                document.getElementById("fielFill").style = "display:none";
            }
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Html_Content" runat="server">

    <div>

        <div class="row my-5">
            <div class="col-lg-12">

                <div class="row">

                    <div class="col-lg-3">

                        <div class="card mb-3">
                            <div class="card-header">
                                <h4 id="lblPaymentMethodTitle" runat="server" meta:resourcekey="lblPaymentMethodTitle">Metodo de pago</h4>
                            </div>
                            <div class="card-body">
                                <h6 class="card-title">Formas de pago disponible</h6>
                                <asp:DropDownList ID="dlPaymentMethod" runat="server" DataTextField="Description" DataValueField="idPaymentMethod" CssClass="form-select">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="card mb-3">
                            <div class="card-body">
                                <h5 class="card-title text-center">Importante </h5>
                                <ul class="list-group list-group-flush">
                                    <li class="list-group-item">Al confirmar su pedido, recibirá un correo electronico con las instrucciones de pago</li>
                                    <li class="list-group-item">Su pedido será procesado una vez que recibamos comprobante o notificación de su depósito o transferencia </li>
                                    <li class="list-group-item">Los pedidos con más de 3 días de haberse realizado y no pagados se podrán cancelar </li>
                                </ul>
                            </div>
                        </div>

                    </div>




                    <div class="col-lg-9">


                        <div class="card mb-3">
                            <div class="card-header">
                                <h4 id="hProductos" runat="server" meta:resourcekey="hProductos">Resumen</h4>
                            </div>
                            <div class="card-body">
                                <div class="row">

                                    <div class="col-lg-4">

                                        <fieldset>
                                            <legend id="txtInforSend" runat="server" meta:resourcekey="txtInforSend" style="font-weight: bold">Datos del envío
                                            </legend>

                                            <%-- datos de envio --%>
                                            <% Response.Write(ObjInfoCustomer(0).Name + " " + ObjInfoCustomer(0).LastName)%>
                                            <br />
                                            Tel. <% Response.Write(ObjInfoCustomer(0).Phone)%>
                                            <br />
                                            <br />

                                            <label id="lbDir" runat="server" meta:resourcekey="lbDir"><strong>Dirección</strong></label>

                                            <address style="font-size: small;">

                                                <% Response.Write(ObjInfoCustomerAdress(0).DireccionFac)%>
                                                <br />
                                                <% Response.Write(ObjInfoCustomerAdress(0).ColoniaFac)%>, cp. <% Response.Write(ObjInfoCustomerAdress(0).CPFac)%>
                                                <br />
                                                <% Response.Write(ObjInfoCustomerAdress(0).CityFac)%>, <% Response.Write(ObjInfoCustomerAdress(0).StateFac)%>
                                                <br />
                                                <% Response.Write(ObjInfoCustomerAdress(0).Country)%>
                                            </address>

                                        </fieldset>

                                    </div>

                                    <div class="col-lg-8">
                                        <fieldset>
                                            <legend id="pListProducts" runat="server" meta:resourcekey="pListProducts" style="font-weight: bold">Productos 
                                            </legend>
                                            <!-- List productos -->
                                            <asp:GridView ID="gvListProductos" runat="server" AutoGenerateColumns="False" CssClass="orderinfo-table"
                                                DataKeyNames="IdProduct" EmptyDataText="No hay nada en su carrito de compras." GridLines="None" Width="100%" CellPadding="0"
                                                ShowHeader="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Producto">
                                                        <ItemTemplate>
                                                            <div style="font-size: small">
                                                                <%# Eval("Producto")%>  x <strong>(<%# Eval("Cantidad")%>)</strong>
                                                            </div>
                                                        </ItemTemplate>
                                                        <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Precio" DataFormatString="{0:C}" HeaderStyle-HorizontalAlign="Right" HeaderText="Precio" ItemStyle-HorizontalAlign="Right">
                                                        <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Small" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Total" DataFormatString="{0:C}" HeaderStyle-HorizontalAlign="Right" HeaderText="Total" ItemStyle-HorizontalAlign="Right">
                                                        <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" Width="50" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="Small" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                        </fieldset>

                                        <div>
                                            <table style="width: 100%;" class="orderinfo-table">

                                                <tr>
                                                    <td></td>
                                                    <td style="font-size: small; text-align: right;"><strong>Sub Total</strong></td>
                                                    <td style="text-align: right; font-size: small;"><% Response.Write(FormatCurrency(Html._SubTotal, 2))%></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td style="font-size: small; text-align: right;"><strong>Sub sub Total (Decuento especial del 4%)</strong></td>
                                                    <td style="text-align: right; font-size: small;"><% 
                                                                                                                     Dim subtotal As Decimal = Html._SubTotal
                                                                                                                     Dim descuento As Decimal = GetDescuento()
                                                                                                                     Dim subtotalConDescuento As Decimal = subtotal - (subtotal * descuento)
                                                                                                                     Response.Write(IIf(Session("MM_Lista") Is Nothing, "", FormatCurrency(subtotalConDescuento, 2)))
                                                                                                                   %></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td style="font-size: small; text-align: right;"><strong>IVA</strong></td>
                                                    <td style="font-size: small; text-align: right;"><% 
                                                                                                         Dim iva As Decimal = Html._PorcentajeIva * (1 - descuento)
                                                                                                         Response.Write(IIf(Session("MM_Lista") Is Nothing, "", FormatCurrency(iva, 2)))
                                                                                                     %>  </td>
                                                </tr>


                                                <tr>
                                                    <td style="font-size: small;"><% Response.Write(Html._MethodSendTitle + " - " + Html._MethodSendComm)%> </td>
                                                    <td style="font-size: small !important; text-align: right;"><strong>Envio</strong></td>
                                                    <td style="font-size: small !important; text-align: right;"><% Response.Write(FormatCurrency(Html._MethodSendPrice, 2))%></td>
                                                </tr>

                                                <tr>
                                                    <td></td>
                                                    <td style="font-size: small !important; text-align: right;"><strong><span class="price">Total</span></strong></td>
                                                    <td style="font-size: small !important; text-align: right;"><span class="price"><% 
                                                                                                                                        Dim total As Decimal = subtotalConDescuento + iva
                                                                                                                                        Response.Write(IIf(Session("MM_Lista") Is Nothing, "", FormatCurrency(total, 2)))
                                                                                                                                    %></span></td>
                                                </tr>
                                            </table>
                                        </div>

                                    </div>

                                    <div class="col-lg-12" id="txtInforConfirmation" runat="server" meta:resourcekey="txtInforConfirmation">
                                        <p>Por favor revise la información antes de continuar una vez confirmado el pedido no se podrá realizar cambios.</p>
                                    </div>

                                </div>
                            </div>
                        </div>




                        <div class="row mb-3">
                            <div class="col-lg-12">



                                <div class="card">
                                    <div class="card-header">
                                        <h4 id="lblTitleFill" runat="server" meta:resourcekey="lblTitleFill">Datos de Factura</h4>
                                    </div>
                                    <div class="card-body">

                                        <div class="form-check">
                                            <asp:CheckBox ID="chFill" runat="server" meta:resourcekey="chFill" onclick="javascript:Fill(this);" CssClass="form-check-input" />
                                            <label class="form-check-label" for="chFill">
                                                Facturar compra
                                            </label>
                                        </div>




                                        <fieldset id="fielFill" style="display: none;">

                                            <figure class="my-5">
                                                <figcaption class="blockquote-footer fs-6">La factura será realizada con los siguientes datos que se presentan en el formulario de abajo. </figcaption>
                                            </figure>




                                            <div class="row g-1 mb-3">

                                                <div class="form-floating col">
                                                    <asp:TextBox ID="txtCompany" CssClass="form-control" runat="server" placeholder="Empresa"></asp:TextBox>
                                                    <label for="txtCompany">Empresa</label>
                                                </div>

                                                <div class="form-floating col">
                                                    <asp:TextBox ID="txtRFC" CssClass="form-control" runat="server" placeholder="RFC"></asp:TextBox>
                                                    <label for="txtRFC">RFC</label>
                                                </div>

                                                <div class="form-floating col">
                                                    <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server" placeholder="Teléfono"></asp:TextBox>
                                                    <label for="txtPhone">Teléfono</label>
                                                </div>

                                            </div>


                                            <div class="row g-1 mb-3">
                                                <div class="form-floating col">
                                                    <asp:TextBox ID="txtAdress" CssClass="form-control" runat="server" placeholder="Dirección"></asp:TextBox>
                                                    <label for="txtAdress">Dirección</label>
                                                </div>

                                                <div class="form-floating col">
                                                    <asp:TextBox ID="txtColony" CssClass="form-control" runat="server" placeholder="Colonia"></asp:TextBox>
                                                    <label for="txtColony">Colonia</label>
                                                </div>

                                                <div class="form-floating col ">
                                                    <asp:TextBox ID="txtCP" CssClass="form-control" runat="server" placeholder="Código Postal"></asp:TextBox>
                                                    <label for="txtCP">Código Postal</label>
                                                </div>
                                            </div>

                                            <div class="row g-1 mb-3">

                                                <div class="form-floating col">
                                                    <asp:TextBox ID="txtCity" CssClass="form-control" runat="server" placeholder="Ciudad"></asp:TextBox>
                                                    <label for="txtCity">Ciudad</label>
                                                </div>

                                                <div class="form-floating col">
                                                    <asp:TextBox ID="txtState" CssClass="form-control" runat="server" placeholder="Estado"></asp:TextBox>
                                                    <label for="txtState">Estado</label>
                                                </div>

                                                <div class="form-floating col">
                                                    <asp:TextBox ID="txtCountry" CssClass="form-control" runat="server" placeholder="País"></asp:TextBox>
                                                    <label for="txtCountry">País</label>
                                                </div>

                                            </div>





                                        </fieldset>

                                    </div>
                                </div>



                            </div>
                        </div>


                        <div class="row">
                            <div class="col-lg-12">

                                <div class="card">
                                    <div class="card-header">
                                        <h4 id="lblTitleNotesShipping" runat="server" meta:resourcekey="lblTitleNotesShipping">Notas especiales</h4>
                                    </div>
                                    <div class="card-body">
                                        <p id="lblNotesShipping" runat="server" meta:resourcekey="lblNotesShipping">Comentarios Sobre Su Orden </p>
                                        <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" CssClass="form-control border border-black "></asp:TextBox>

                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>


        <div class="row">
            <div class="col-lg-12">

                <p style="text-align: right;">
                    <asp:Button ID="btnPrevious" runat="server" Text="Regresar" meta:resourcekey="btnPrevious" CssClass="btn btn-secondary" />
                    <asp:Button ID="btnContinue" runat="server" Text="Confirmar" meta:resourcekey="btnContinue" CssClass="btn btn-success" />
                </p>

            </div>
        </div>

    </div>

</asp:Content>
