<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="Login.aspx.vb" Inherits="sycsa.Web.Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Html_head" runat="server">
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="Html_sidebar" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Html_Content" runat="server">

            <div class="row">

                <div class="col-lg-7 col-md-7 col-sm-7">

                    <div class="card">
                        <div class="card-header text-center">
                            <i class="bi bi-person-circle"></i>   Detalle de cuenta
                        </div>
                        <div class="card-body">
                            <div class="mb-3 row">
                                <div class="col-12">
                                    <asp:TextBox ID="txtUserName" runat="server" meta:resourcekey="txtUserName" placeholder="Usuario" CssClass="form-control" autocomplete="off"></asp:TextBox>

                                </div>
                            </div>
                            <div class="mb-3 row">
                                <div class="col-12">
                                    <asp:TextBox ID="txtPass" runat="server" meta:resourcekey="txtPass" TextMode="Password" placeholder="Password" CssClass="form-control" autocomplete="off"></asp:TextBox>

                                </div>
                            </div>
                            <div class="mb-3 row">
                                <div class="col-6">
                                    <asp:Button ID="btnLogin" runat="server" Text="Continuar" CssClass="btn btn-success" meta:resourcekey="btnLogin" />

                                </div>
                                <div class="col-6">
                                    <asp:HyperLink ID="LinkIforgot" runat="server" CssClass="btn btn-secondary" Text="Contraseña perdida" NavigateUrl="~/iforgot/iforgot.aspx" meta:resourcekey="LinkIforgot"></asp:HyperLink>

                                </div>
                            </div>
                        </div>
                    </div>

                </div>

                <div class="col-lg-5 col-md-5 col-sm-5">

                    <div class="card">
                        <div class="card-header">
                            Crear cuenta
                        </div>
                        <div class="card-body">
                            <h5 class="card-title">Cliente Nuevo</h5>
                            <p class="card-text">Si es cliente nuevo, puede registrase de manera fácil y rápido, solo te tomara unos minutos.</p>
                            <div class="mb-3 row">
                                <div class="col-12">
                                    <asp:Button ID="btnNewAccount" runat="server" Text="Crear cuenta" CssClass="btn btn-primary" meta:resourcekey="btnNewAccount" />

                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>




</asp:Content>
