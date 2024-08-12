<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="iforgot.aspx.vb" Inherits="sycsa.Web.iforgot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Html_head" runat="server">
        <style>
        .modal-lg {
            width: 95% !important;
        }

        .iframe {
            border: solid #BBB6B6 0px;
        }

        .modal-body {
            padding: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Html_Content" runat="server">
        <div class="row">
                <div class="col-lg-12  col-sm-12 col-xs-12">
                   <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">¿Olvidaste tu contraseña?</h3>
                        </div>
                        <div class="panel-body">
                              <div class="row">
                                <div class="col-lg-6 col-sm-6 col-xs-6">
                                    <div class="form-group">
                                        <label for="txtClaveOficina">Correo Electrónico:</label>
                                        <asp:TextBox ID="txtMail" runat="server" CssClass="form-control input-sm isNumber" required="True" MaxLength="50"></asp:TextBox>
                                        <asp:Button ID="btnSendRequest" runat="server" CssClass="btn btn-primary btn-sm" Text="enviar"  OnClick="btnSendRequest_Click"/>
                                     </div>
                                </div>
                            </div>

                          

                        </div>

                       
                    </div>
                </div>

            
            </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Html_sidebar" runat="server">
</asp:Content>
