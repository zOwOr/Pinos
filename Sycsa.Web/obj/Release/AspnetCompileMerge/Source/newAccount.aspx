<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="newAccount.aspx.vb" Inherits="sycsa.Web.newAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Html_head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Html_Content" runat="server">

    <div class="row">

        <div class="col-lg-12 col-md-12 col-sm-12 register-account">

            <div class="carousel-heading no-margin">
                <h4>Registro</h4>
            </div>

            <div class="page-content">
                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <p><strong>Información</strong></p>
                    </div>

                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <p>Correo electronico (*)</p>
                    </div>
                    <div class="col-lg-8 col-md-8 col-sm-8">
                        <asp:TextBox ID="txtREmail" runat="server" data-require="true" CssClass="form-control" required></asp:TextBox>
                    </div>

                </div>


                <div class="row">

                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <p>Contraseña</p>
                    </div>
                    <div class="col-lg-8 col-md-8 col-sm-8">
                        <asp:TextBox ID="txtRPassword" runat="server" data-require="true" CssClass="form-control" required></asp:TextBox>
                    </div>

                </div>


                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <p>Nombre de usuario</p>
                    </div>
                    <div class="col-lg-8 col-md-8 col-sm-8">
                        <asp:TextBox ID="txtName" runat="server" data-require="true" CssClass="form-control" required></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <p>Nombre</p>
                    </div>
                    <div class="col-lg-8 col-md-8 col-sm-8">
                        <asp:TextBox ID="txtLastName" runat="server" data-require="true" CssClass="form-control" required></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <p>Telefono</p>
                    </div>
                    <div class="col-lg-8 col-md-8 col-sm-8">
                        <asp:TextBox ID="txtPhone" runat="server" data-require="true" CssClass="form-control" required></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <p>Telefono</p>
                    </div>
                    <div class="col-lg-8 col-md-8 col-sm-8">
                        <asp:TextBox ID="txtPhoneAddress" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12">
                        <p>
                            <asp:Button ID="btnRegister" runat="server" Text="Registrar" CssClass="big" />
                        </p>
                    </div>

                </div>
            </div>

        </div>

    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Html_sidebar" runat="server">
</asp:Content>
