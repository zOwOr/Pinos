<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="MyAccount.aspx.vb" Inherits="sycsa.Web.myAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Html_head" runat="server">
</asp:Content>
<asp:Content ID="MyAccount_Content" ContentPlaceHolderID="Html_sidebar" runat="server">
    <aside class="sidebar col-lg-2 col-md-2 col-sm-2">
        <!-- Categories -->
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
<asp:Content ID="Content2" ContentPlaceHolderID="Html_Content" runat="server">
    <section class="col-lg-10 col-md-10 col-sm-10">



                    <div class="card  my-5">
                        <div class="card-header">
                            <h4>Información de mi cuenta</h4>
                        </div>
                        <div class="card-body">
                            <div class="mb-3">
                                <label for="exampleFormControlTextarea1" class="form-label">Nombre de usuario</label>
                                <asp:TextBox ID="txtNombre" runat="server" data-require="true" CssClass="form-control" required></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label for="exampleFormControlTextarea1" class="form-label">Nombre</label>
                                <asp:TextBox ID="txtLastName" runat="server" data-require="true" CssClass="form-control" required></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label for="exampleFormControlTextarea1" class="form-label">Correo electrónico</label>
                                <asp:TextBox ID="txtEmail" runat="server" data-require="true" CssClass="form-control" required></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label for="exampleFormControlTextarea1" class="form-label">Teléfono</label>
                                <asp:TextBox ID="txtphone" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-warning" />
                            </div>
                        </div>
                    </div>


    </section>
</asp:Content>
