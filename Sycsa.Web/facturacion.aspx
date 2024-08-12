<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="facturacion.aspx.vb" Inherits="sycsa.Web.facturacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Html_head" runat="server">
</asp:Content>

<asp:Content ID="MyAccount_Content" ContentPlaceHolderID="Html_sidebar" runat="server">
    <aside class="sidebar col-lg-2 col-md-2 col-sm-2">
        <!-- Categories -->
        <div class="row sidebar-box my-5">
            <div class="col-lg-12 col-md-12 col-sm-12">


                <div class="card">
                    <div class="card-header">
                        <h4><i class="bi bi-folder-plus"></i>  Consultar</h4>
                    </div>
                    <div class="card-body">
                        <ul class="list-group">
                            <li class="list-group-item">
                                <a href="<% Response.Write(ResolveUrl("~/MyAccount.aspx"))%>">
                                    <span class="nav-caption">Mi Informacion</span>
                                </a>
                            </li>
                            <li class="list-group-item">
                                <a href="<% Response.Write(ResolveUrl("~/Facturas.aspx"))%>">
                                    <span class="nav-caption">Facturas</span>
                                </a>
                            </li>
                            <li class="list-group-item">
                                <a href="<% Response.Write(ResolveUrl("~/Cobranza.aspx"))%>">
                                    <span class="nav-caption">Cobranza</span>
                                </a>
                            </li>
                            <li class="list-group-item">
                                <a href="<% Response.Write(ResolveUrl("~/NotasCredito.aspx"))%>">
                                    <span class="nav-caption">Notas de Credito</span>
                                </a>
                            </li>
                            <li class="list-group-item">
                                <a href="<% Response.Write(ResolveUrl("~/Pedidos.aspx"))%>">
                                    <span class="nav-caption">Pedidos</span>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>


            </div>
        </div>
    </aside>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Html_Content" runat="server">
    <section class="col-lg-10 col-md-10 col-sm-10">
        <div class="row my-5">


            <div class="card">
                <div class="card-header">
                    <h4>Facturacion en linea</h4>
                </div>
                <div class="card-body">

                    <div class="mb-3">
                        <label for="exampleFormControlInput1" class="form-label">RFC (escribe el RFC y presiona enter)</label>
                        <asp:TextBox ID="txtrfc" runat="server" OnTextChanged="buscacliente" ValidationGroup="buscacliente" CssClass="form-control mb-3" required></asp:TextBox>
                        <asp:Button ID="btnbuscarrfc" runat="server" Text="Buscar RFC" class="btn btn-outline-secondary " />
                    </div>


                    <div class="mb-3">
                        <label for="exampleFormControlInput1" class="form-label">Nombre o razon social</label> 
                        <asp:TextBox ID="txtNOMBRE" runat="server" data-require="false" CssClass="form-control"></asp:TextBox>
                        <asp:TextBox ID="TXTCLIMOS" runat="server" data-require="false" CssClass="form-control" Visible="false"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label for="exampleFormControlInput1" class="form-label">Codigo Postal</label>
                        <asp:TextBox ID="txtcodigopostal" runat="server" data-require="false" CssClass="form-control" Width="102px"></asp:TextBox>
                    </div>


                    <div class="mb-3">
                        <label for="exampleFormControlInput1" class="form-label">Regimen Fiscal</label>
                        <asp:DropDownList ID="txtregimen_cbo" runat="server" data-require="false" CssClass="form-control">
                            <asp:ListItem Value="601">601 GENERAL DE LEY PERSONAS MORALES</asp:ListItem>
                            <asp:ListItem Value="603">603 PERSONAS MORALES CON FINES NO LUCRATIVOS</asp:ListItem>
                            <asp:ListItem Value="605">605 SUELDOS Y SALARIOS E INGRESOS ASIMILADOS A SALARIOS</asp:ListItem>
                            <asp:ListItem Value="606">606 ARRENDAMIENTO</asp:ListItem>
                            <asp:ListItem Value="607">607 RÉGIMEN DE ENAJENACIÓN O ADQUISICIÓN DE BIENES</asp:ListItem>
                            <asp:ListItem Value="608">608 DEMÁS INGRESOS</asp:ListItem>
                            <asp:ListItem Value="609">609 CONSOLIDACIÓN</asp:ListItem>
                            <asp:ListItem Value="610">610 RESIDENTES EN EL EXTRANJERO SIN ESTABLECIMIENTO PERMANENTE EN MÉXICO</asp:ListItem>
                            <asp:ListItem Value="611">611 INGRESOS POR DIVIDENDOS (SOCIOS Y ACCIONISTAS)</asp:ListItem>
                            <asp:ListItem Value="612">612 PERSONAS FÍSICAS CON ACTIVIDADES EMPRESARIALES Y PROFESIONALES</asp:ListItem>
                            <asp:ListItem Value="614">614 INGRESOS POR INTERESES</asp:ListItem>
                            <asp:ListItem Value="615">615 RÉGIMEN DE LOS INGRESOS POR OBTENCIÓN DE PREMIOS</asp:ListItem>
                            <asp:ListItem Value="616">616 SIN OBLIGACIONES FISCALES</asp:ListItem>
                            <asp:ListItem Value="620">620 SOCIEDADES COOPERATIVAS DE PRODUCCIÓN QUE OPTAN POR DIFERIR SUS INGRESOS</asp:ListItem>
                            <asp:ListItem Value="621">621 INCORPORACIÓN FISCAL</asp:ListItem>
                            <asp:ListItem Value="622">622 ACTIVIDADES AGRÍCOLAS, GANADERAS, SILVÍCOLAS Y PESQUERAS</asp:ListItem>
                            <asp:ListItem Value="623">623 OPCIONAL PARA GRUPOS DE SOCIEDADES</asp:ListItem>
                            <asp:ListItem Value="624">624 COORDINADOS</asp:ListItem>
                            <asp:ListItem Value="625">625 RÉGIMEN DE LAS ACTIVIDADES EMPRESARIALES CON INGRESOS A TRAVÉS DE PLATAFORMAS TECNOLÓGICAS</asp:ListItem>
                            <asp:ListItem Value="626">626 RÉGIMEN SIMPLIFICADO DE CONFIANZA</asp:ListItem>
                            <asp:ListItem Value="628">628 HIDROCARBUROS</asp:ListItem>
                            <asp:ListItem Value="629">629 DE LOS REGÍMENES FISCALES PREFERENTES Y DE LAS EMPRESAS MULTINACIONALES</asp:ListItem>

                        </asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <label for="exampleFormControlInput1" class="form-label">Uso CFDI</label>
                        <asp:DropDownList ID="txtusocfdi" runat="server" data-require="false" CssClass="form-control">
                            <asp:ListItem Value="G01">G01 ADQUISICIÓN DE MERCANCÍAS</asp:ListItem>
                            <asp:ListItem Value="G02">G02 DEVOLUCIONES, DESCUENTOS O BONIFICACIONES</asp:ListItem>
                            <asp:ListItem Value="G03">G03 GASTOS EN GENERAL</asp:ListItem>
                            <asp:ListItem Value="I01">I01 CONSTRUCCIONES</asp:ListItem>
                            <asp:ListItem Value="I02">I02 MOBILIARIO Y EQUIPO DE OFICINA POR INVERSIONES</asp:ListItem>
                            <asp:ListItem Value="I03">I03 EQUIPO DE TRANSPORTE</asp:ListItem>
                            <asp:ListItem Value="I04">I04 EQUIPO DE COMPUTO Y ACCESORIOS</asp:ListItem>
                            <asp:ListItem Value="I05">I05 DADOS, TROQUELES, MOLDES, MATRICES Y HERRAMENTAL</asp:ListItem>
                            <asp:ListItem Value="I06">I06 COMUNICACIONES TELEFÓNICAS</asp:ListItem>
                            <asp:ListItem Value="I07">I07 COMUNICACIONES SATELITALES</asp:ListItem>
                            <asp:ListItem Value="I08">I08 OTRA MAQUINARIA Y EQUIPO</asp:ListItem>
                            <asp:ListItem Value="D01">D01 HONORARIOS MÉDICOS, DENTALES Y GASTOS HOSPITALARIOS</asp:ListItem>
                            <asp:ListItem Value="D02">D02 GASTOS MÉDICOS POR INCAPACIDAD O DISCAPACIDAD</asp:ListItem>
                            <asp:ListItem Value="D03">D03 GASTOS FUNERALES.</asp:ListItem>
                            <asp:ListItem Value="D04">D04 DONATIVOS</asp:ListItem>
                            <asp:ListItem Value="D05">D05 INTERESES REALES EFECTIVAMENTE PAGADOS POR CRÉDITOS HIPOTECARIOS (CASA HABITACIÓN)</asp:ListItem>
                            <asp:ListItem Value="D06">D06 APORTACIONES VOLUNTARIAS AL SAR</asp:ListItem>
                            <asp:ListItem Value="D07">D07 PRIMAS POR SEGUROS DE GASTOS MÉDICOS</asp:ListItem>
                            <asp:ListItem Value="D08">D08 GASTOS DE TRANSPORTACIÓN ESCOLAR OBLIGATORIA</asp:ListItem>
                            <asp:ListItem Value="D09">D09 DEPÓSITOS EN CUENTAS PARA EL AHORRO, PRIMAS QUE TENGAN COMO BASE PLANES DE PENSIONES</asp:ListItem>
                            <asp:ListItem Value="D10">D10 PAGOS POR SERVICIOS EDUCATIVOS (COLEGIATURAS)</asp:ListItem>
                            <asp:ListItem Value="S01">S01 SIN EFECTOS FISCALES</asp:ListItem>
                            <asp:ListItem Value="CP01">CP01 PAGOS</asp:ListItem>
                            <asp:ListItem Value="CN01">CN01 NÓMINA</asp:ListItem>

                        </asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <label for="exampleFormControlInput1" class="form-label">Forma de pago</label>
                        <asp:DropDownList ID="txtformapago" runat="server" data-require="false" CssClass="form-control">
                            <asp:ListItem Value="01">01 EFECTIVO</asp:ListItem>
                            <asp:ListItem Value="02">02 CHEQUE NOMINATIVO</asp:ListItem>
                            <asp:ListItem Value="03">03 TRANSFERENCIA ELECTRÓNICA DE FONDOS</asp:ListItem>
                            <asp:ListItem Value="04">04 TARJETA DE CRÉDITO</asp:ListItem>
                            <asp:ListItem Value="05">05 MONEDERO ELECTRÓNICO</asp:ListItem>
                            <asp:ListItem Value="06">06 DINERO ELECTRÓNICO</asp:ListItem>
                            <asp:ListItem Value="08">08 VALES DE DESPENSA</asp:ListItem>
                            <asp:ListItem Value="12">12 DACIÓN EN PAGO</asp:ListItem>
                            <asp:ListItem Value="13">13 PAGO POR SUBROGACIÓN</asp:ListItem>
                            <asp:ListItem Value="14">14 PAGO POR CONSIGNACIÓN</asp:ListItem>
                            <asp:ListItem Value="15">15 CONDONACIÓN</asp:ListItem>
                            <asp:ListItem Value="17">17 COMPENSACIÓN</asp:ListItem>
                            <asp:ListItem Value="23">23 NOVACIÓN</asp:ListItem>
                            <asp:ListItem Value="24">24 CONFUSIÓN</asp:ListItem>
                            <asp:ListItem Value="25">25 REMISIÓN DE DEUDA</asp:ListItem>
                            <asp:ListItem Value="26">26 PRESCRIPCIÓN O CADUCIDAD</asp:ListItem>
                            <asp:ListItem Value="27">27 A SATISFACCIÓN DEL ACREEDOR</asp:ListItem>
                            <asp:ListItem Value="28">28 TARJETA DE DÉBITO</asp:ListItem>
                            <asp:ListItem Value="29">29 TARJETA DE SERVICIOS</asp:ListItem>
                            <asp:ListItem Value="30">30 APLICACIÓN DE ANTICIPOS</asp:ListItem>
                            <asp:ListItem Value="31">31 INTERMEDIARIO PAGOS</asp:ListItem>
                            <asp:ListItem Value="99">99 POR DEFINIR</asp:ListItem>

                        </asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <label for="exampleFormControlInput1" class="form-label">Correo electrónico</label>
                        <asp:ListView ID="Listemails" runat="server" ConvertEmptyStringToNull="true"
                            GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1" EnableTheming="false">
                            <GroupTemplate>
                                <asp:PlaceHolder runat="server" ID="itemPlaceHolder1" EnableTheming="False"></asp:PlaceHolder>
                            </GroupTemplate>

                            <LayoutTemplate>
                                <asp:PlaceHolder ID="groupPlaceHolder1" runat="server"></asp:PlaceHolder>
                            </LayoutTemplate>

                            <ItemTemplate>
                                <tr>
                                    <td></td>
                                    <td data-title="email" class="text-center">
                                        <%# Eval("email")%>
                                    </td>
                                    <td data-title="factura" class="text-center">
                                        <%# Eval("factura")%>
                                    </td>


                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                No existen email para mostrar
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </div>


                    <div class="mb-3">
                        <label for="exampleFormControlInput1" class="form-label">Teléfono</label>
                        <asp:TextBox ID="txtphone" runat="server" data-require="true" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label for="exampleFormControlInput1" class="form-label">Dirección</label>
                        <asp:TextBox ID="txtdireccion" runat="server" data-require="true" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label for="exampleFormControlInput1" class="form-label">Colonia</label>
                        <asp:TextBox ID="txtcolonia" runat="server" data-require="true" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label for="exampleFormControlInput1" class="form-label">Ciudad</label>
                        <asp:TextBox ID="txtciudad" runat="server" data-require="true" CssClass="form-control"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label for="exampleFormControlInput1" class="form-label">Estado</label>
                        <asp:TextBox ID="txtestado" runat="server" data-require="true" CssClass="form-control mb-3"></asp:TextBox>
                        <asp:Button ID="btnActualizar" runat="server" Text="Grabar cambios" CssClass="btn btn-success" />

                    </div>

                    <div class="mb-3 row">
                        <label for="staticEmail" class="col-sm-2 col-form-label">Ticket</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="TXTFOLIO" runat="server" data-require="true" CssClass="form-control"></asp:TextBox>
                        </div>
                        <label for="staticEmail" class="col-sm-4 col-form-label">por ejemplo LA001255, EA002122, FA004501</label>

                    </div>


                    <div class="mb-3 row">
                        <label for="staticEmail" class="col-sm-2 col-form-label">Total</label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="TXTTOTAL" runat="server" data-require="true" CssClass="form-control"></asp:TextBox>
                        </div>
                        <label for="staticEmail" class="col-sm-4 col-form-label">por ejemplo 1540.00</label>

                    </div>

                </div>
            </div>

            <%--<cc1:recaptchacontrol ID="recaptcha" runat="server" PublicKey="6LdoltApAAAAADNJY8yUVHCnt2ALOOQsgo_jwpfy" PrivateKey="6LdoltApAAAAAAM6ySBjLZ5JdVDWAbKo2atm-upD" />--%>
            <asp:HiddenField ID="gRecaptchaResponse" runat="server" />
            <%--<div class="g-recaptcha" data-sitekey="6Le-wvkSAAAAAPBMRTvw0Q4Muexq9bi0DJwx_mJ-" data-callback="onSuccess" data-action="action"> </div>--%>
            <asp:Button ID="btnfacturar" runat="server" Text="Facturar Ticket" Style="display: none" />
            <asp:Button ID="btntimbrar" runat="server" Text="Facturar Ticket" CssClass="btn btn-success" />


        </div>
    </section>
    <script>
        function onSubmit(token) {
            document.getElementById('gRecaptchaResponse').value = token;
            document.getElementById('btnfacturar').click();
        }
    </script>
</asp:Content>
