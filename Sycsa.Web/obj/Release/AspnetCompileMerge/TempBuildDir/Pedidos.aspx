<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="Pedidos.aspx.vb" Inherits="sycsa.Web.Pedidos" %>
<%@ Register assembly="FastReport.Web, Version=2017.3.20.0, Culture=neutral, PublicKeyToken=db7e5ce63278458c" namespace="FastReport.Web" tagprefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Html_head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Html_sidebar" runat="server">
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
<asp:Content ID="Content4" ContentPlaceHolderID="Html_Content" runat="server">
    <section class="col-lg-10 col-md-10 col-sm-10">
        <div>
            <div>
                <div class="carousel-heading no-margin">
                    <h4>Historial de Pedidos</h4>
                </div>
                <div class="">
                    <%--<asp:HyperLink ID="Linkback" runat="server" CssClass="btn" NavigateUrl="~/MyAccount.aspx">Regresar</asp:HyperLink>--%>
                    <div id="no-more-tables">
                        <table class="table table-bordered table-striped table-hover table-condensed">
                            <thead class="thead-dark">
                                <tr>
                                    <th class="col-auto text-center">Folio</th>
                                    <th class="col-auto text-center">Fecha alta</th>
                                    <th class="col-auto text-center">Total</th>
                                    <th class="col-auto text-center">Estatus</th>
                                    <th class="col-auto text-center">Imprimir PDF</th>
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
                                            <td data-title="Folio" class="text-center"
                                                data-filter-control="input" data-sortable="true">
                                                <%# Eval("FOLIO")%>
                                            </td>
                                            <td data-title="text-center">
                                                <%# Eval("FECHA_ALTA")%>
                                            </td>
                                            <td data-title="Subcategoria" class="text-right font-weight-bold">
                                                <%# Eval("TOTAL")%>
                                            </td>
                                            <td data-title="Estatus" class="text-center">
                                                <%# Eval("ESTATUS")%>
                                            </td>
                                            <td class="text-center">
                                                <asp:LinkButton runat="server" ID="Imprimir" CommandName="Imprimir"
                                                    CommandArgument='<%# Eval("Clave")%>'>
                                                    <label id="Label1" runat="server" class="fa fa-file-pdf-o" style="color: red; cursor: pointer;"> PDF</label>
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
            </div>
        </div>
    </section>
</asp:Content>
