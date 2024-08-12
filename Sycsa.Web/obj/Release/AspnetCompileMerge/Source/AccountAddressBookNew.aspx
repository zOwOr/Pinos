<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="AccountAddressBookNew.aspx.vb" Inherits="sycsa.Web.AccountAddressBookNew" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Html_head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Html_sidebar" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Html_Content" runat="server">

    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">

            <div class="page-content">

                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12">

                        <asp:HyperLink ID="linkCancel" runat="server" NavigateUrl="~/AccountAddressBook.aspx">Cancelar</asp:HyperLink>


                        <h3><strong>Dirección</strong></h3>
                        <p>
                            Por favor llene el formulario siguiente para agregar una nueva dirección
                        </p>
                    </div>

                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <p>Nombre de la compañia (opcional)</p>
                    </div>
                    <div class="col-lg-8 col-md-8 col-sm-8">
                        <asp:TextBox ID="txtCompany" runat="server" ></asp:TextBox>
                    </div>

                </div>


                <div class="row">

                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <p>RFC (opcional)</p>
                    </div>
                    <div class="col-lg-8 col-md-8 col-sm-8">
                        <asp:TextBox ID="txtRFC" runat="server"></asp:TextBox>
                    </div>

                </div>


                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <p>Telefono</p>
                    </div>
                    <div class="col-lg-8 col-md-8 col-sm-8">
                        <asp:TextBox ID="txtPhoneAddress" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <p>Dirección</p>
                    </div>
                    <div class="col-lg-8 col-md-8 col-sm-8">
                        <asp:TextBox ID="txtAdress" runat="server" data-require="true" required></asp:TextBox>
                    </div>
                </div>


                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <p>Colonia</p>
                    </div>
                    <div class="col-lg-8 col-md-8 col-sm-8">
                        <asp:TextBox ID="txtColony" runat="server" data-require="true" required></asp:TextBox>
                    </div>
                </div>



                <div class="row">

                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <p>Codigo postal</p>
                    </div>
                    <div class="col-lg-8 col-md-8 col-sm-8">
                        <asp:TextBox ID="txtCP" runat="server" data-require="true" required> </asp:TextBox>
                    </div>

                </div>

                <div class="row">

                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <p>Ciudad</p>
                    </div>
                    <div class="col-lg-8 col-md-8 col-sm-8">
                        <asp:TextBox ID="txtCity" runat="server" data-require="true" required></asp:TextBox>
                    </div>

                </div>

                <div class="row">

                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <p>Estado</p>
                    </div>
                    <div class="col-lg-8 col-md-8 col-sm-8">
                        <asp:TextBox ID="txtState" runat="server" data-require="true" required></asp:TextBox>
                    </div>

                </div>

                <div class="row">

                    <div class="col-lg-4 col-md-4 col-sm-4">
                        <p>Activar esta dirección para envío</p>
                    </div>
                    <div class="col-lg-8 col-md-8 col-sm-8">
                        <asp:CheckBox ID="chAdreesDefault" runat="server" Enabled="true" />
                        <label for="chAdreesDefault">Utilizar para envío</label>
                    </div>

                </div>


                <p>
                    <asp:Button ID="btnSave" runat="server" Text="Guardar" />
                </p>

            </div>


        </div>
    </div>


</asp:Content>
