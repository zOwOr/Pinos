<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWebSim.Master" CodeBehind="CheckoutPayment.aspx.vb" Inherits="sycsa.Web.CheckoutPayment" %>

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

        <div class="row">
            <div class="col-lg-12">

                <div class="row">
                    <div class="col-lg-3">
                        <div class="carousel-heading no-margin">
                            <h4 id="lblPaymentMethodTitle" runat="server" meta:resourcekey="lblPaymentMethodTitle">Metodo de pago</h4>
                        </div>
                        <div class="page-content">

                            <p>
                                <asp:Label ID="lblPaymentMethod" runat="server" meta:resourcekey="lblPaymentMethod" Text="Formas de pago disponible" Font-Bold="true">
                                </asp:Label>
                            </p>

                            <div class="row">
                                <div class="col-lg-12">

                                    <asp:DropDownList ID="dlPaymentMethod" runat="server" DataTextField="Description" DataValueField="idPaymentMethod">
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>


                        <div class="carousel-heading no-margin">
                            <h4 id="InfoTitleShipping" runat="server" meta:resourcekey="InfoTitleShipping">Importante</h4>
                        </div>
                        <div class="page-content">

                            <div class="medium_text">
                                <ul>
                                    <li>Al confirmar su pedido, recibirá un correo electronico con las instrucciones de pago
                                    </li>

                                    <li>Su pedido será procesado una vez que recibamos comprobante o notificación de su depósito o transferencia
                                    </li>

                                    <li>Los pedidos con más de 3 días de haberse realizado y no pagados se podrán cancelar
                                    </li>
                                </ul>
                            </div>

                        </div>


                    </div>

                    <div class="col-lg-9">
                        <div class="carousel-heading no-margin">
                            <h4 id="hProductos" runat="server" meta:resourcekey="hProductos">Resumen</h4>
                        </div>
                        <div class="page-content">


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
                                        <legend id="pListProducts" runat="server" meta:resourcekey="pListProducts" style="font-weight: bold">Prodcutos 
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
                                                <td style="width: 19%; font-size: small; text-align: right;"><strong>Sub Total</strong></td>
                                                <td style="width: 15%; text-align: right; font-size: small;"><% Response.Write(FormatCurrency(Html._SubTotal, 2))%></td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td style="font-size: small; text-align: right;"><strong>IVA</strong></td>
                                                <td style="font-size: small; text-align: right;"><% Response.Write(FormatCurrency(Html._PorcentajeIva, 2))%></td>
                                            </tr>


                                            <tr>
                                                <td style="font-size:small;"><% Response.Write(Html._MethodSendTitle +  " - " + Html._MethodSendComm)%> </td>
                                                <td style="font-size: small !important; text-align: right;"><strong>Envio</strong></td>
                                                <td style="font-size: small !important; text-align: right;"><% Response.Write(FormatCurrency(Html._MethodSendPrice, 2))%></td>
                                            </tr>

                                            <tr>
                                                <td></td>
                                                <td style="font-size: small !important; text-align: right;"><strong><span class="price">Total</span></strong></td>
                                                <td style="font-size: small !important; text-align: right;"><span class="price"><%  Response.Write(FormatCurrency(Html._Total, 2))%></span></td>
                                            </tr>
                                        </table>
                                    </div>

                                </div>

                                <div class="col-lg-12" id="txtInforConfirmation" runat="server" meta:resourcekey="txtInforConfirmation">
                                    <p>Por favor revise la información antes de continuar una vez confirmado el pedido no se podrá realizar cambios.</p>
                                </div>

                            </div>

                        </div>

                        <div class="row">
                            <div class="col-lg-12">

                                <div class="carousel-heading no-margin">
                                    <h4 id="lblTitleFill" runat="server" meta:resourcekey="lblTitleFill">Datos de Factura</h4>
                                </div>
                                <div class="page-content">

                                    <div class="medium_text">
                                        <asp:CheckBox ID="chFill" runat="server" Text="Facturar compra" meta:resourcekey="chFill" onclick="javascript:Fill(this);" />
                                    </div>

                                    <fieldset id="fielFill" style="display: none;">

                                        <div id="txtFill" runat="server" meta:resourcekey="chFill">
                                            <p>La factura será realizada con los siguientes datos que se presentan en el formulario de abajo.</p>
                                        </div>


                                        <label id="lblCompany" for="txtCompany" runat="server" meta:resourcekey="lblCompany">Empresa</label>
                                        <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>

                                        <label id="lblRFC" for="txtRFC" runat="server" meta:resourcekey="lblRFC">RFC</label>
                                        <asp:TextBox ID="txtRFC" runat="server"></asp:TextBox>

                                        <label id="lblPhone" for="txtPhone" runat="server" meta:resourcekey="lblPhone">Teléfono</label>
                                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>

                                        <label id="lblAdress" for="txtAdress" runat="server" meta:resourcekey="lblAdress">Dirección</label>
                                        <asp:TextBox ID="txtAdress" runat="server"></asp:TextBox>

                                        <label id="lblColony" for="txtColony" runat="server" meta:resourcekey="lblColony">Colonia</label>
                                        <asp:TextBox ID="txtColony" runat="server"></asp:TextBox>

                                        <label id="lblCP" for="txtCP" runat="server" meta:resourcekey="lblCP">Código Postal</label>
                                        <asp:TextBox ID="txtCP" runat="server"></asp:TextBox>

                                        <label id="lblCity" for="txtCity" runat="server" meta:resourcekey="lblCity">Ciudad</label>
                                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>

                                        <label id="lblState" for="txtState" runat="server" meta:resourcekey="lblState">Estado</label>
                                        <asp:TextBox ID="txtState" runat="server"></asp:TextBox>

                                        <label id="lblCountry" for="txtCountry" runat="server" meta:resourcekey="lblCountry">País</label>
                                        <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>

                                    </fieldset>


                                </div>

                            </div>
                        </div>


                        <div class="row">
                            <div class="col-lg-12">
                                <div class="carousel-heading no-margin">
                                    <h4 id="lblTitleNotesShipping" runat="server" meta:resourcekey="lblTitleNotesShipping">Notas especiales</h4>
                                </div>
                                <div class="page-content">
                                    <p id="lblNotesShipping" runat="server" meta:resourcekey="lblNotesShipping">Comentarios Sobre Su Orden </p>
                                    <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine"></asp:TextBox>
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
                    <asp:Button ID="btnPrevious" runat="server" Text="Regresar" meta:resourcekey="btnPrevious" />
                    <asp:Button ID="btnContinue" runat="server" Text="Confirmar" meta:resourcekey="btnContinue" />
                </p>

            </div>
        </div>

    </div>

</asp:Content>
