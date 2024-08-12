<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="ListProducts.aspx.vb" Inherits="sycsa.Web.ListProducts" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Html_head" runat="server">

    <script>
        function AddCart(e) {
            eventTarget = "addCart"
            cantidad = $('#cantidad_' + e.split(",")[0].trim() + "_" + e.split(",")[1].trim()).val();
            cantidad = cantidad > 0 ? cantidad : 1
            __doPostBack(eventTarget, e.trim() + "," + cantidad);

        }
    </script>
    <script>
        function AddCant(e) {
            var a = e.value
            $("#" + e.id).val(a)
        }
    </script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Html_sidebar" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Html_Content" runat="server">

    <div class="row">

        <div class="col-lg-6 col-md-6 col-sm-6">
            <div class="category-results">
                
                <p>

                    <asp:DataPager ID="DataPager" runat="server" PagedControlID="ListProducts" QueryStringField="PageNum">
                        <Fields>
                            <asp:TemplatePagerField>
                                <PagerTemplate>

                                    <span id="txtPagePag" runat="server">Pagina </span>
                                    <asp:Label runat="server" ID="labelCurrentPage" Text="<%# If(Container.TotalRowCount > 0, (Container.StartRowIndex / Container.PageSize) + 1, 0)%>" />
                                    <span id="txtPageOf" runat="server">de </span>
                                    <asp:Label runat="server" ID="labelTotalPages" Text="<%# Math.Ceiling(CDbl(Container.TotalRowCount) / Container.PageSize) %>" />

                                </PagerTemplate>

                            </asp:TemplatePagerField>

                        </Fields>
                    </asp:DataPager>
                </p>

                <p id="pTextLabelResultForPage" runat="server" meta:resourcekey="pTextLabelResultForPage">Elementos por página </p>

                <asp:DropDownList ID="ResultPage" runat="server" AppendDataBoundItems="true" CssClass="chosen-select" AutoPostBack="True">
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="20">20</asp:ListItem>
                    <asp:ListItem Value="30">30</asp:ListItem>
                    <asp:ListItem Value="50">50</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="col-lg-6 col-md-6 col-sm-6">
            <div class="pagination">
                <div class="page-button">

                    <asp:DataPager ID="dataPagerNumeric" PagedControlID="ListProducts"
                        runat="server" PageSize="5">
                        <Fields>
                            <asp:NumericPagerField ButtonCount="5"
                                NumericButtonCssClass="page-button"
                                CurrentPageLabelCssClass="page-button"
                                NextPreviousButtonCssClass="page-button" />
                        </Fields>
                    </asp:DataPager>

                </div>
            </div>
        </div>

    </div>

    <div class="row">
        <div id="no-more-tables">
                          <table class="col-md-12 table-bordered table-striped table-condensed cf">
                              <thead class="cf">
                            <tr>
                              <th>Codigo</th>
                              <th>Producto</th>
                                <th class="numeric">Categoria</th>
                                <th class="numeric">Subcategoria</th>
                                <th class="numeric">Marca</th>
                                <th class="numeric">Unidad</th>
                              <th class="numeric">Precio</th>
                              <th class="numeric">Cantidad</th>                              
                            </tr>
                            </thead>
                            <tbody>
        <asp:ListView ID="ListProducts" runat="server" ConvertEmptyStringToNull="true"
            GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1"
            OnPagePropertiesChanging="OnPagePropertiesChanging" EnableTheming="false">

            <GroupTemplate>
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder1" EnableTheming="False"></asp:PlaceHolder>
            </GroupTemplate>

            <LayoutTemplate>
                <asp:PlaceHolder ID="groupPlaceHolder1" runat="server"></asp:PlaceHolder>
            </LayoutTemplate>

            <ItemTemplate>
                
                <tr>
                <td data-title="Codigo" class="numeric">
                    <%# Eval("ProductName")%>
                </td>
                <td data-title="Producto">
                   <span><%# Eval("shortDescription")%></span> 
                    <span class="descripciontb"><a href="ShowProduct.aspx?pk=<%#Eval("ProductID")%>&pu=<%# Eval("Unidad")%>" class="product-hover">  </a> </span>
                </td>
                <td data-title="Categoria" class="numeric">
                    <%# Eval("Categoria")%>
                </td>
                <td data-title="Subcategoria" class="numeric">
                    <%# Eval("Subcategoria")%>
                </td>
                <td data-title="Marca" class="numeric">
                     <%# Eval("Marca")%>
                </td>
                <td data-title="Unidad" class="numeric">
                    <%# Eval("Unidad")%>
                </td>
                <td data-title="Precio" class="numeric">
                    <span class="price"><%# IIf(Session("MM_Lista") Is Nothing, "", FormatCurrency(Eval("UnitPrice"), 2))%></span>
                </td>
                <td data-title="Cantidad" style="width: 116px;">
                    <input type="number" id="cantidad_<%#Trim(Eval("ProductID"))%>_<%#Trim(Eval("Unidad"))%>" placeholder="0.00" min="0" style="text-align:center;width: 65px;"/>
<%--                    <div class="col-lg-8 col-md-8 col-sm-8 product-content no-padding" style="width: 130px;">
                        
                    </div>--%>
                    <%--<div class="col-lg-8 col-md-8 col-sm-8 product-content no-padding">--%>
                        <div class="product-actions full-width" onclick="return AddCart(' <%#Trim(Eval("ProductID"))%>,<%#Trim(Eval("Unidad"))%>');" style="width: 40px;">
                                <span class="add-to-cart">
                                    <span class="action-wrapper">
                                        <i class="icons icon-basket-2"></i>
                                        <span class="action-name" id="txtBotonCarAdd" runat="server" meta:resourcekey="txtBotonCarAdd"></span>
                                    </span>
                                </span>

                            </div>
<%--                     </div>--%>
                </td>
            </tr>
        
            </ItemTemplate>
            <EmptyDataTemplate>
               No existen productos para mostrar
            </EmptyDataTemplate>
        </asp:ListView>
                              </tbody>
                              
                           </table>   
        </div>                               
    </div>

</asp:Content>
