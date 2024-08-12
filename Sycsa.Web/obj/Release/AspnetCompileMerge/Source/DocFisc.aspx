<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DocFisc.aspx.vb"  MasterPageFile="~/Layout/SiteWeb.Master" Inherits="sycsa.Web.DocFisc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Html_head" runat="server">
     <!-- Main Navigation -->
  
</asp:Content>
<asp:Content ID="Content3"  ContentPlaceHolderID="Html_sidebar" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Html_Content" runat="server">
                    <section class="main-content col-lg-9 col-md-9 col-sm-9 col-lg-push-3 col-md-push-3 col-sm-push-3">            
                    <div class="row">
                        <div class="col-lg-7">
                            <div id="box_process" class="process" style="display: none; margin-top: 5px;">Atendiendo ...</div>
                            <div id="box_messenger" class="msgBox" style="margin-top: 5px;">

                            </div>
                        </div>
                    </div>
                                          <nav id="main-navigation" class="style1">
                        <ul>
                            <li class="home-green current-item">
                                <a href="<% Response.Write(ResolveUrl("~/home.aspx"))%>">
                                    <i class="icons icon-shop-1"></i>
                                    <span class="nav-caption">Pedidos</span>
                                </a>
                            </li>
                            <li class="home-green current-item">
                                <a href="<% Response.Write(ResolveUrl("~/marks.aspx"))%>">
                                    <i class="icons icon-marquee"></i>
                                    <span class="nav-caption">Facturas</span>
                                </a>
                            </li>
                            <li class="home-green current-item" id="dvDocFisc" runat="server">
                                <a href="<% Response.Write(ResolveUrl("~/DocFisc.aspx"))%>">
                                    <i class="icons icon-contacts"></i>
                                    <span class="nav-caption">Complementos de Pago</span>
                                </a>
                            </li>
                            <li class="home-green current-item">
                                <a href="<% Response.Write(ResolveUrl("~/Login.aspx"))%>">
                                    <i class="icons icon-contacts"></i>
                                    <span class="nav-caption">Reportes</span>
                                </a>
                            </li>
                        </ul>
                    </nav>
                    <!-- Main Navigation -->
                </section>

</asp:Content>
