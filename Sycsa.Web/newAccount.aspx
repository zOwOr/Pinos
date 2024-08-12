<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="newAccount.aspx.vb" Inherits="sycsa.Web.newAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Html_head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Html_Content" runat="server">

    <div class="row">

        <div class="col-lg-12 col-md-12 col-sm-12 register-account">



            <div class="card">
                <div class="card-header text-center">
                    Registro
                </div>
                <div class="card-body">
                    <h5 class="card-title">Información</h5>


                    <div class="mb-3 row">
                        <label for="inputPassword" class="col-2 col-form-label">Correo electronico (*)</label>
                        <div class="col-10">
                            <asp:TextBox ID="txtREmail" runat="server" data-require="true" CssClass="form-control" required></asp:TextBox>
                        </div>
                    </div>


                    <div class="mb-3 row">
                        <label for="inputPassword" class="col-2 col-form-label">Contraseña</label>
                        <div class="col-10">
                            <asp:TextBox ID="txtRPassword" runat="server" data-require="true" CssClass="form-control" required></asp:TextBox>
                        </div>
                    </div>

                    <div class="mb-3 row">
                        <label for="inputPassword" class="col-2 col-form-label">Nombre de usuario</label>
                        <div class="col-10">
                            <asp:TextBox ID="txtName" runat="server" data-require="true" CssClass="form-control" required></asp:TextBox>
                        </div>
                    </div>


                    <div class="mb-3 row">
                        <label for="inputPassword" class="col-2 col-form-label">Nombre</label>
                        <div class="col-10">
                            <asp:TextBox ID="txtLastName" runat="server" data-require="true" CssClass="form-control" required></asp:TextBox>
                        </div>
                    </div>


                    <div class="mb-3 row">
                        <label for="inputPassword" class="col-2 col-form-label">Telefono</label>
                        <div class="col-10">
                            <asp:TextBox ID="txtPhone" runat="server" data-require="true" CssClass="form-control" required></asp:TextBox>
                        </div>
                    </div>

                    <div class="mb-3 row">
                        <label for="inputPassword" class="col-2 col-form-label">Telefono</label>
                        <div class="col-10">
                            <asp:TextBox ID="txtPhoneAddress" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>


                    <div class="mb-3 row">
                        <div class="col-12 text-center">
                            <asp:Button ID="btnRegister" runat="server" Text="Registrar" CssClass="btn btn-primary" />
                        </div>
                    </div>

                </div>
            </div>




        </div>

    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Html_sidebar" runat="server">
</asp:Content>
