<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWebSim.Master" CodeBehind="Facturas.aspx.vb" Inherits="sycsa.Web.Facturas" %>
<%@ Register assembly="FastReport.Web, Version=2017.3.20.0, Culture=neutral, PublicKeyToken=db7e5ce63278458c" namespace="FastReport.Web" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Html_Content" runat="server">
       <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">


                <div class="carousel-heading no-margin">
                    <h4>Historial de Facturas</h4>
                </div>
                <div class="page-content contact-info">

                    <asp:HyperLink ID="Linkback" runat="server" CssClass="btn" NavigateUrl="~/MyAccount.aspx">Regresar</asp:HyperLink>
                    <p>
                        Aqui puede ver su historial de compras que ha realizado 
                    </p>
                    <div class="medium_text">
                        <asp:CheckBox ID="chFill" runat="server" Text="Facturar Saldo Pendiente" AutoPostBack="true"  oncheckedchanged="chFill_CheckedChanged" />
                    </div>
                    <div id="no-more-tables">
                                <table class="col-md-12 table-bordered table-striped table-condensed cf">
                                    <thead class="cf">
                                        <tr>
                                      <th>Folio</th>
                                      <th>Fecha alta</th>
                                        <th class="numeric">Orden compra</th>
                                        <th class="numeric">Total</th>
                                        <th class="numeric">Saldo</th>
                                        <th class="numeric">Estatus</th> 
                                        <th class="numeric">Imprimir PDF</th>   
                                        <th class="numeric">Imprimir XML</th>                             
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
                                                <td data-title="Folio" class="numeric">
                                                    <%# Eval("FOLIO")%>
                                                </td>
                                                <td data-title="Fecha alta">
                                                    <%# Eval("FECHA_ALTA")%>
                                                </td>
                                                <td data-title="Categoria" class="numeric">
                                                    <%# Eval("ORDEN_COMP")%>
                                                </td>
                                                <td data-title="Subcategoria" class="numeric">
                                                    <%# Eval("TOTAL")%>
                                                </td>
                                                <td data-title="Marca" class="numeric">
                                                     <%# Eval("SALDO_MN")%>
                                                </td>
                                                <td data-title="EStatus" class="numeric">
                                                    <%# Eval("ESTATUS")%>
                                                </td>
                                                <td>
                                                    <asp:LinkButton runat="server" ID="Imprimir" CommandName="Imprimir" 
                                                    CommandArgument='<%# Eval("Clave")%>' Style="font-size: 12px;">
                                                    <label id="Label1" runat="server" class="fa fa-file-pdf-o" style="font-size:14px;color:red;cursor: pointer;">Imprimir</label>
                                                    </asp:LinkButton>
                                                </td>
                                                <td data-title="XML" class="numeric">
                                                    <asp:LinkButton runat="server" ID="ImprimirXML" CommandName="ImprimirXML" 
                                                    CommandArgument='<%# Eval("Clave")%>' Style="font-size: 12px;">
<%--                                                CommandArgument='<%# Eval("ARCHIVOXML")%>' Style="font-size: 12px;">--%>
                                                    <label id="Label2" runat="server" class="fa fa-file-excel-o" style="font-size:14px;color:green;cursor: pointer;">Imprimir XML</label>
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
 </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Html_head" runat="server">
</asp:Content>
