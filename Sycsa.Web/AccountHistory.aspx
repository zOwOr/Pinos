<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="AccountHistory.aspx.vb" Inherits="sycsa.Web.AccountHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Html_head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Html_sidebar" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Html_Content" runat="server">


    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">



            <div class="card my-5">
                <div class="card-header">
                    <h4>Historial de pedidos</h4>
                </div>
                <div class="card-body">
                    <div class="page-content contact-info">

                        <asp:HyperLink ID="Linkback" runat="server" CssClass="btn btn-secondary" NavigateUrl="~/MyAccount.aspx">Regresar</asp:HyperLink>
                        <p>
                            Aqui puede ver su historial de compras que ha realizado 
                        </p>


                        <div style="padding: 15px;">

                            <asp:GridView ID="tbHistorySales" runat="server" AutoGenerateColumns="False" AllowSorting="True" Width="100%" AllowPaging="False" EmptyDataText="" CssClass="table table-bordered table-hover">
                                <Columns>
                                    <asp:BoundField DataField="Clave" HeaderText="Clave" SortExpression="Clave" Visible="False" />
                                    <asp:BoundField DataField="Clave" HeaderText="Orden No." SortExpression="Clave">
                                        <HeaderStyle CssClass="text-center fw-bold" />
                                        <ItemStyle CssClass="text-center align-middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Fecha_Alta" HeaderText="Fecha" SortExpression="Fecha_Alta">
                                        <HeaderStyle CssClass="text-center fw-bold" />
                                        <ItemStyle CssClass="text-center align-middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total" HeaderText="Total compra" SortExpression="Total" DataFormatString="{0:c}">
                                        <HeaderStyle CssClass="text-center fw-bold" />
                                        <ItemStyle CssClass="text-center align-middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Sub_Total" HeaderText="Subtotal" SortExpression="Sub_Total">
                                        <HeaderStyle CssClass="text-center fw-bold" />
                                        <ItemStyle CssClass="text-center align-middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Tot_IVA" HeaderText="Total Iva" SortExpression="Tot_IVA">
                                        <HeaderStyle CssClass="text-center fw-bold" />
                                        <ItemStyle CssClass="text-center align-middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Orden_Comp" HeaderText="Orden de Compra" SortExpression="Orden_Comp">
                                        <HeaderStyle CssClass="text-center fw-bold" />
                                        <ItemStyle CssClass="text-center align-middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Folio" HeaderText="Folio" SortExpression="Folio">
                                        <HeaderStyle CssClass="text-center fw-bold" />
                                        <ItemStyle CssClass="text-center align-middle" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Estatus" HeaderText="Estatus" SortExpression="Estatus">
                                        <HeaderStyle CssClass="text-center fw-bold" />
                                        <ItemStyle CssClass="text-center align-middle" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Imprimir">
                                        <HeaderStyle CssClass="text-center fw-bold" />
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="Imprimir" CommandName="Imprimir" CommandArgument='<%# Eval("Clave")%>' CssClass="btn btn-outline-danger btn-sm">
                    <i class="fa fa-file-pdf-o"></i> Imprimir
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </div>

                    </div>
                </div>
            </div>




        </div>
    </div>

</asp:Content>

