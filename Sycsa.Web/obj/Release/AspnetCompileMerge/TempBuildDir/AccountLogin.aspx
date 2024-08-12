<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="AccountLogin.aspx.vb" Inherits="sycsa.Web.AccountLogin" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Html_head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Html_sidebar" runat="server">
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="Html_Content" runat="server">

    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">


            <div class="carousel-heading no-margin">
                <h4>Información de acceso</h4>
            </div>
            <div class="page-content contact-info">
                <asp:HyperLink ID="Linkback" runat="server" CssClass="btn" NavigateUrl="~/MyAccount.aspx">Regresar</asp:HyperLink>
                <p>
                    Aqui puede cambiar su contraseña con la que accede al sitio
                </p>


                <div class="contact-form">
                    <label>Nueva Contraseña</label>
                    <asp:TextBox ID="txtPass" runat="server" data-require="true" TextMode="Password" placeholder="Password" CssClass="form-control" required></asp:TextBox>
                </div>

                <div class="contact-form">
                    <label>Repetir Contraseña</label>
                    <asp:TextBox ID="txtPassRepeat" runat="server" data-require="true" TextMode="Password" placeholder="Password" CssClass="form-control" required></asp:TextBox>
                </div>


                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" />

            </div>



        </div>
    </div>


</asp:Content>

