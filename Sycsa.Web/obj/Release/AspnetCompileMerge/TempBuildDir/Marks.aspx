<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="Marks.aspx.vb" Inherits="sycsa.Web.marks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Html_head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Html_sidebar" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Html_Content" runat="server">


    <div class="row">

        <div class="col-lg-12 col-md-12 col-sm-12">
            <div class="carousel-heading">
                <h4 id="txtTitleCategorie" runat="server" meta:resourcekey="txtTitleCategorie">Compra por marca</h4>
            </div>
        </div>



        <div class="col-lg-12 col-md-12 col-sm-12">

            <h4 id="txtDescMark1" runat="server" meta:resourcekey="txtDescMark1">Selecciona una marca para visualizar los productos</h4>
            <asp:ListView ID="ListProducts" runat="server" ConvertEmptyStringToNull="true"
            GroupPlaceholderID="groupPlaceHolder1" ItemPlaceholderID="itemPlaceHolder1"
            EnableTheming="false" RepeatColumns="5" RepeatDirection="vertical">
                <GroupTemplate>
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder1" EnableTheming="False"></asp:PlaceHolder>
                </GroupTemplate>

                <LayoutTemplate>
                    <asp:PlaceHolder ID="groupPlaceHolder1" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>

                <ItemTemplate>
                    <li>
                        <a href="<% Response.Write(ResolveUrl("~/ListProducts.aspx?paramM="))%> <%# Eval("idMark")%>"><strong><%# Eval("MarkName") %></strong></a>
                    </li>
                </ItemTemplate>

                <EmptyDataTemplate>
                   No existen productos para mostrar
                </EmptyDataTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>

