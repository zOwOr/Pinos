<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="ShoppingSend.aspx.vb" Inherits="sycsa.Web.ShoppingSend" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Html_head" runat="server">
</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="Html_Content" runat="server">


    <div class="row">
        <div class="col-lg-12 col-sm-12 col-xs-12">

            <div class="carousel-heading no-margin">
                <h4 id="txtLabelTitle" runat="server" ></h4>
            </div>

            <div class="page-content">


                <h3 id="textInfo5" runat="server">¡Cotización enviada!</h3>
                <p id="textInfo6" runat="server"></p>



                <!-- news -->
                <div class="row" id="DivClienteNuevo" runat="server" visible="false">
                    <div class="col-lg-6 col-sm-6 col-xs-6">

                        <h4 id="textInfo2" runat="server"></h4>
                        <p style="text-align: justify;" id="textInfo1" runat="server">
                        </p>


                    </div>
                    <div class="col-lg-6 col-sm-6 col-xs-6">

<%--                        <h4 id="textInfo3" runat="server"></h4>
                        <p id="textInfo4" runat="server"></p>

                        <asp:CheckBox ID="chNews" runat="server" Checked="false" Text="Subcribirme a boletines del sitio " />
                        
                        <div class="category-results">
                            <asp:ListBox ID="ListCategories" runat="server" Height="195" 
                                CssClass="chosen-select" SelectionMode="Multiple"
                                DataSourceID="SqlCategories" DataTextField="CategoryName" DataValueField="idCategories" data-placeholder="" ></asp:ListBox>
                        </div>

                        <div style="margin-top:15px;">
                             <asp:Button ID="btnEnviar" runat="server" Text="Suscribirme" />
                        </div>
                       

                        <asp:SqlDataSource runat="server" ID="SqlCategories" ConnectionString='<%$ ConnectionStrings:MySQLConnection %>'
                            ProviderName='<%$ ConnectionStrings:MySQLConnection.ProviderName %>'
                            SelectCommand="SELECT idCategories, CategoryName FROM categories WHERE (Active = 1) ORDER BY CategoryName"></asp:SqlDataSource>--%>


                    </div>
                </div>




            </div>


        </div>
    </div>

</asp:Content>
