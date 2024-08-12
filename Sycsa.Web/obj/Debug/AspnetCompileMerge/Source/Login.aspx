<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="Login.aspx.vb" Inherits="sycsa.Web.Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Html_head" runat="server">
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="Html_sidebar" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Html_Content" runat="server">



    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">


            <div class="row">

                <div class="col-lg-7 col-md-7 col-sm-7">

                    <div class="carousel-heading no-margin">
                        <h4>
                            <asp:Label ID="lbTitleLogin" runat="server" Text="Detalle de cuenta"  meta:resourcekey="lbTitleLogin"></asp:Label>
                        </h4>
                    </div>

                    <div class="page-content">

                        <p>
                            <asp:Label ID="lbTextInfo" runat="server" Text="Si ya está registrado, por favor entra directamente aquí" meta:resourcekey="lbTextInfo"></asp:Label>
                        </p>

                        <div class="row">
                            <div class="col-lg-6 col-md-6 col-sm-6">
                                <div class="iconic-input">
                                    <asp:TextBox ID="txtUserName" runat="server" meta:resourcekey="txtUserName" placeholder="Usuario" autocomplete="off"></asp:TextBox>
                                    <i class="icons icon-user-3"></i>
                                </div>
                            </div>

                            <div class="col-lg-6 col-md-6 col-sm-6">
                                <div class="iconic-input">
                                    <asp:TextBox ID="txtPass" runat="server"  meta:resourcekey="txtPass" TextMode="Password" placeholder="Password" autocomplete="off"></asp:TextBox>
                                    <i class="icons icon-lock"></i>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-6 col-md-6 col-sm-6 align-left">
                                <asp:Button ID="btnLogin" runat="server" Text="Continuar" CssClass="orange" meta:resourcekey="btnLogin" />
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 align-right">
                                <small>
                                    <asp:HyperLink ID="LinkIforgot" runat="server" CssClass="align-right" Text="Contraseña perdida" NavigateUrl="~/iforgot/iforgot.aspx" meta:resourcekey="LinkIforgot"></asp:HyperLink>
                                </small>
                            </div>
                        </div>
                    </div>

                </div>

                <div class="col-lg-5 col-md-5 col-sm-5">
                    <div class="carousel-heading no-margin">
                        <h4>
                            <asp:Label ID="txtNewAccountTitle" runat="server" Text="Crear cuenta" meta:resourcekey="txtNewAccountTitle"></asp:Label>
                        </h4>
                    </div>
                    <div class="page-content">

                        <blockquote>
                            <h5 id="txtTitleNewUser" runat="server" meta:resourcekey="txtTitleNewUser">Cliente Nuevo</h5>


                            <p id="TextNewUser" runat="server" meta:resourcekey="TextNewUser" class="small_text" style="text-align:justify;">
                              Si es cliente nuevo, puede registrase de manera fácil y rápido, solo te tomara unos minutos.
                            </p>

                           <asp:Button ID="btnNewAccount" runat="server" Text="Crear cuenta" CssClass="orange" meta:resourcekey="btnNewAccount" />

                        </blockquote>


                    </div>
                </div>
            </div>


        </div>
    </div>

</asp:Content>
