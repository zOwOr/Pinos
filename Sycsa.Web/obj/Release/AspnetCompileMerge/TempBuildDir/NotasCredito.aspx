<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="NotasCredito.aspx.vb" Inherits="sycsa.Web.NotasCredito" %>
<%@ Register assembly="FastReport.Web, Version=2017.3.20.0, Culture=neutral, PublicKeyToken=db7e5ce63278458c" namespace="FastReport.Web" tagprefix="cc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Html_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Html_sidebar" runat="server">
    <aside class="sidebar col-lg-2 col-md-2 col-sm-2">
        <!-- Categories -->
        <div class="row sidebar-box blue">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="sidebar-box-heading">
                    <i class="icons icon-folder-open-empty"></i>
                    <h4>Consultar</h4>
                </div>
                <div class="sidebar-box-content">
                    <ul>
                        <li class="sidebar-padding-box">
                            <a href="<% Response.Write(ResolveUrl("~/MyAccount.aspx"))%>">
                                <span class="nav-caption">Mi Informacion</span>
                            </a>
                        </li>
                        <li class="sidebar-padding-box">
                            <a href="<% Response.Write(ResolveUrl("~/Facturas.aspx"))%>">
                                <span class="nav-caption">Facturas</span>
                            </a>
                        </li>
                        <li>
                            <a href="<% Response.Write(ResolveUrl("~/Cobranza.aspx"))%>">
                                <span class="nav-caption">Cobranza</span>
                            </a>
                        </li>
                        <li>
                            <a href="<% Response.Write(ResolveUrl("~/Pedidos.aspx"))%>">
                                <span class="nav-caption">Pedidos</span>
                            </a>
                        </li>
<%--                        <li>
                            <a href="<% Response.Write(ResolveUrl("~/home.aspx"))%>">
                                <span class="nav-caption">Reportes</span>
                            </a>
                        </li>--%>
                    </ul>
                </div>
            </div>
        </div>
    </aside>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Html_Content" runat="server">
    <section class="col-lg-10 col-md-10 col-sm-10">
        <div>
            <div>
                <div class="carousel-heading no-margin">
                    <h4>Historial de Complementos de Pago</h4>
                </div>
                <div class="">
                    <div id="toolbar" class="form-row">
                        <div class="input-group">
                            <div class="input-group-prepend">
                                <label class="input-group-text" for="inputGroupSelect01">Exportar</label>
                            </div>
                            <select class="custom-select" id="inputGroupSelect01">
                                <option selected>Que deseas exportar...</option>
                                <option value="all">Todo</option>
                                <option value="selected">Seleccionado</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div id="no-more-tables">
                    <table 
                        id="table" 
                        data-pagination="true" 
                        data-search="true" 
                        data-toggle="table" 
                        data-show-columns="true" 
                        data-show-export="true" 
                        data-click-to-select="true" 
                        data-toolbar="#toolbar"
                        data-export-types="['excel']"
                        data-export-options='{
                          "fileName": "Reporte de Cobranzas",
                          "worksheetName": "Cobranzas",
                          "htmlContent" : "true",
                          }'
                        >
                        <thead class="thead-dark">
                            <tr>
                                <th data-field="state" data-checkbox="true"></th>
                                <th class="col-auto text-center" data-sortable="true" data-field="folio">Folio</th>
                                <th class="col-auto text-center" data-sortable="true" data-field="fecha_alta">Fecha Alta</th>
                                <th class="col-auto text-center" data-sortable="true" data-field="fecha_real">Fecha Real</th>
                                <th class="col-auto text-center" data-sortable="true" data-field="total">Total Aplicado</th>
                                <th class="col-auto text-center" data-sortable="true" data-field="estatus">Estatus</th>
                                <th class="col-auto text-center">Imprimir PDF</th>
                                <th class="col-auto text-center">Imprimir XML</th>
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
                                        <td></td>
                                        <td data-title="Folio" class="text-center">
                                            <%# Eval("FOLIO")%>
                                        </td>
                                        <td data-title="Fecha alta" class="text-center">
                                            <%# Format(Eval("FECHA_ALTA"), "dd/MM/yyyy")%>
                                        </td>
                                        <td data-title="fecha real" class="text-center">
                                            <%# Format(Eval("FECHA_REAL"), "dd/MM/yyyy")%>
                                        </td>
                                        <td data-title="total aplicado" class="text-right font-weight-bold">
                                            <%# Eval("TOTAL_APLICADO")%>
                                        </td>
                                        <td data-title="Estatus" class="text-center">
                                            <%# Eval("ESTATUS")%>
                                        </td>
                                        <td class="text-center">
                                            <asp:LinkButton runat="server" ID="Imprimir" CommandName="Imprimir"
                                                CommandArgument='<%# Eval("Clave")%>' Style="font-size: 12px;">
                                                <label id="Label1" runat="server" class="fa fa-file-pdf-o" style="font-size: 14px; color: red; cursor: pointer;">Imprimir</label>
                                            </asp:LinkButton>
                                        </td>
                                        <td data-title="XML" class="text-center">
                                            <asp:LinkButton runat="server" ID="ImprimirXML" CommandName="ImprimirXML"
                                                CommandArgument='<%# Eval("Clave")%>' Style="font-size: 12px;">
                                                <%--                                                CommandArgument='<%# Eval("ARCHIVOXML")%>' Style="font-size: 12px;">--%>
                                                <label id="Label2" runat="server" class="fa fa-file-excel-o" style="font-size: 14px; color: green; cursor: pointer;">Imprimir XML</label>
                                            </asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    No existen complementos de pago para mostrar
                                </EmptyDataTemplate>
                            </asp:ListView>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </section>
 </asp:Content>

