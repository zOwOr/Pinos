<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="AccountHistory.aspx.vb" Inherits="sycsa.Web.AccountHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Html_head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Html_sidebar" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Html_Content" runat="server">


    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">


            <div class="carousel-heading no-margin">
                <h4>Historial de pedidos</h4>
            </div>
            <div class="page-content contact-info">

                <asp:HyperLink ID="Linkback" runat="server" CssClass="btn" NavigateUrl="~/MyAccount.aspx">Regresar</asp:HyperLink>
                <p>
                    Aqui puede ver su historial de compras que ha realizado 
                </p>


                <div style="padding: 15px;">

                    <asp:GridView ID="tbHistorySales" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="100%" AllowPaging="False" EmptyDataText="">
                        <Columns>
                            <asp:BoundField DataField="Clave" HeaderText="Clave" SortExpression="Clave" Visible="False" />
                            <asp:BoundField DataField="Clave" HeaderText="Orden No." SortExpression="Clave" >
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Fecha_Alta" HeaderText="Fecha" SortExpression="Fecha_Alta" >
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Total" HeaderText="Total compra" SortExpression="Total" DataFormatString="{0:c}" >
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Sub_Total" HeaderText="Subtotal" SortExpression="Sub_Total" >
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Tot_IVA" HeaderText="Total Iva" SortExpression="Tot_IVA" >
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Orden_Comp" HeaderText="Orden de Compra" SortExpression="Orden_Comp" >
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Folio" HeaderText="Folio" SortExpression="Folio" >
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Estatus" HeaderText="Estatus" SortExpression="Estatus" >
                            <HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Bottom" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Imprimir">
                                <ItemTemplate>   
                                                                                             
                                        <asp:LinkButton runat="server" ID="Imprimir" CommandName="Imprimir" 
                                        CommandArgument='<%# Eval("Clave")%>' Style="font-size: 12px;">
                                        <i class="icons icon-ok-3"></i>
                                        <label id="Label1" runat="server" class="fa fa-file-pdf-o" style="font-size:14px;color:red">Imprimir</label>
                                        </asp:LinkButton> 
                                </ItemTemplate>                                   
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

            </div>

        </div>
    </div>

</asp:Content>

