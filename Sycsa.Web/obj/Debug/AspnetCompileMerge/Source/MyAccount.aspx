<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="MyAccount.aspx.vb" Inherits="sycsa.Web.myAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Html_head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Html_Content" runat="server">


    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">

            <div class="col-lg-8 col-md-8 col-sm-8">

                <div class="carousel-heading no-margin">
                    <h4>Información de mi cuenta</h4>
                </div>
                <div class="page-content contact-info">

                    <div class="contact-form">
                        <label>Nombre de usuario</label>
                        <asp:TextBox ID="txtNombre" runat="server" data-require="true" required></asp:TextBox>
                    </div>

                    <div class="contact-form">
                        <label>Nombre</label>
                        <asp:TextBox ID="txtLastName" runat="server" data-require="true" required></asp:TextBox>
                    </div>

                    <div class="contact-form">
                        <label>Correo electrónico</label>
                        <asp:TextBox ID="txtEmail" runat="server" data-require="true" required></asp:TextBox>
                    </div>

                    <div class="contact-form">
                        <label>Teléfono</label>
                        <asp:TextBox ID="txtphone" runat="server"></asp:TextBox>
                    </div>

                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" />
                </div>

            </div>

            <div class="col-lg-4 col-md-4 col-sm-4">

                <div class="page-content contact-info">
                    <ul>
                        <li>
                            <asp:HyperLink ID="LinkShopping" runat="server" NavigateUrl="~/AccountHistory.aspx"><i class="icons icon-right-dir"></i> Pedidos realizados</asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/AccountLogin.aspx"><i class="icons icon-right-dir"></i> Información de acceso</asp:HyperLink></li>
                                                <li>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Facturas.aspx"><i class="icons icon-right-dir"></i> Información de facturas</asp:HyperLink></li>
                    </ul>
                </div>
            </div>

        </div>
    </div>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Html_sidebar" runat="server">
</asp:Content>
