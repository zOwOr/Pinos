<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="Facturas.aspx.vb" Inherits="sycsa.Web.Facturas" %>

<%@ Register Assembly="FastReport.Web, Version=2017.3.20.0, Culture=neutral, PublicKeyToken=db7e5ce63278458c" Namespace="FastReport.Web" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Html_head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Html_sidebar" runat="server">
    <aside class="sidebar col-lg-2 col-md-2 col-sm-2">
        <div class="row sidebar-box my-5">
            <div class="col-lg-12 col-md-12 col-sm-12">


                <div class="card">
                    <div class="card-header">
                        <h4><i class="bi bi-folder-plus"></i> Consultar</h4>
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
<asp:Content ID="Content4" ContentPlaceHolderID="Html_Content" runat="server">
    <section class="col-lg-10 col-md-10 col-sm-10">

        <div class="card my-5">
            <div class="card-header">
                <h4>Historial de documentos de venta</h4>
            </div>
            <div class="card-body">
                <div id="toolbar" class="form-row">
                    <div class="input-group mb-3 col-md-4">
                        <div class="input-group-prepend">
                            <label class="input-group-text" for="inputGroupSelect01">Exportar</label>
                        </div>
                        <select class="form-select" id="inputGroupSelect01">
                            <option selected>Que deseas exportar...</option>
                            <option value="all">Todo</option>
                            <option value="selected">Seleccionado</option>
                        </select>
                    </div>
                    <div class="input-group mb-3 col-md-4">
                        <div class="input-group-prepend">
                            <label class="input-group-text" for="inputGroupSelect01">Ver</label>
                        </div>
                        <select class="form-select" id="inputGroupSelect02">
                            <option selected value="all">Todo</option>
                            <option value="fac">Facturas</option>
                            <option value="rem">Remisiones</option>
                        </select>
                    </div>
                    <div class="checkbox col-md-4">
                        <asp:CheckBox ID="chFill" runat="server" CssClass="form-check-input" AutoPostBack="true" OnCheckedChanged="chFill_CheckedChanged" />
                        <label class="form-check-label" for="chFill">
                            Solo con saldo
                        </label>
                    </div>
                </div>


                <table
                    id="tableFact"
                    class="table table-bordered table-striped table-hover table-condensed"
                    data-pagination="true"
                    data-search="true"
                    data-toggle="table"
                    data-show-columns="true"
                    data-show-export="true"
                    data-click-to-select="true"
                    data-toolbar="#toolbar"
                    data-export-types="['excel']"
                    data-export-options='{
                          "fileName": "Reporte de Facturas",
                          "worksheetName": "Facturas",
                          "htmlContent" : "true",
                          }'>
                    <thead class="thead-dark">
                        <tr>
                            <th data-field="state" data-checkbox="true"></th>
                            <th class="col-auto text-center" data-sortable="true" data-field="tipo_doc">Tipo Doc</th>
                            <th class="col-auto text-center" data-sortable="true" data-field="folio">Folio</th>
                            <th class="col-auto text-center" data-sortable="true" data-field="fecha" data-sorter="dateSort">Fecha alta</th>
                            <th class="col-auto text-center" data-sortable="true" data-field="oc">Orden compra</th>
                            <th class="col-auto text-center" data-field="total">Total</th>
                            <th class="col-auto text-center" data-field="saldo">Saldo</th>
                            <th class="col-auto text-center" data-field="estatus">Estatus</th>
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
                                    <td data-title="tipo_doc" class="text-center">
                                        <%# Eval("TIPO_DOC")%>
                                    </td>
                                    <td data-title="folio" class="text-center">
                                        <%# Eval("FOLIO")%>
                                    </td>
                                    <td data-title="fecha" class="text-center">
                                        <%# Format(Eval("FECHA_ALTA"), "dd/MM/yyyy")%>
                                    </td>
                                    <td data-title="oc" class="text-center">
                                        <%# Eval("ORDEN_COMP")%>
                                    </td>
                                    <td data-title="total" class="text-right font-weight-bold">
                                        <%# String.Format("{0:C}", Eval("TOTAL"))%>
                                    </td>
                                    <td data-title="saldo" class="text-right font-weight-bold">
                                        <%# String.Format("{0:C}", Eval("SALDO_MN"))%>
                                    </td>
                                    <td data-title="estatus" class="text-center">
                                        <%# Eval("ESTATUS")%>
                                    </td>
                                    <td class="text-center">
                                        <asp:LinkButton runat="server" ID="Imprimir" CommandName="Imprimir"
                                            CommandArgument='<%# Eval("Clave")%>'>
                                            <label id="Label1" runat="server" class="fa fa-file-pdf-o" style="color: red; cursor: pointer;"> PDF</label>
                                        </asp:LinkButton>
                                    </td>
                                    <td data-title="XML" class="text-center">
                                        <asp:LinkButton runat="server" ID="ImprimirXML" CommandName="ImprimirXML"
                                            CommandArgument='<%# Eval("Clave")%>'>
                                            <%--                                                CommandArgument='<%# Eval("ARCHIVOXML")%>' Style="font-size: 12px;">--%>
                                            <label id="Label2" runat="server" class="fa fa-file-excel-o" style="color: green; cursor: pointer;"> XML</label>
                                        </asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                No existen facturas para mostrar
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </tbody>
                </table>


            </div>
        </div>

    </section>
</asp:Content>
