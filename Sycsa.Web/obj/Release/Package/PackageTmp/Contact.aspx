<%@ Page Title="    Contacto" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="Contact.aspx.vb" Inherits="sycsa.Web.contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Html_head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Html_Content" runat="server">
<%--    <asp:ScriptManager runat="server"></asp:ScriptManager>--%>
    <div class="row">

        <div class="col-lg-7 col-md-7 col-sm-7">

            <div class="carousel-heading no-margin">
                <h4>Información de contacto</h4>
            </div>

            <div class="page-content contact-info">
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d449.4592320454079!2d-100.30684664130726!3d25.68210401056713!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x8662958224b22b4b%3A0xe7c768c255ada549!2sDr+Jos%C3%A9+Ma.+Coss+839%2C+Centro%2C+64000+Monterrey%2C+N.L.!5e0!3m2!1ses-419!2smx!4v1502058929749" width="425" height="350" frameborder="0" style="border: 0" allowfullscreen></iframe>

                <div class="row">

                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="contact-item green">
                            <i class="icons icon-location-3"></i>
                            <p><strong>Visítanos</strong></br>
                                <% Response.Write(Html._Layout_address)%>
                            </p>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="contact-item blue">
                            <i class="icons icon-mail"></i>
                            <p><strong>Escríbenos</strong></br>
                                <a href="#"><% Response.Write(Html._Layout_emailContact)%></a><br>                           
                            </p>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="contact-item orange">
                            <i class="icons icon-phone"></i>
                            <p><strong>Llámanos</strong></br>
                                <% Response.Write(Html._Layout_phone)%>
                            </p>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-6">
                        <div class="contact-item purple">
                            <i class="icons icon-clock"></i>
                            
                            <p><strong>Horarios de atención</strong> </br>
                                lunes a viernes<br>
                                8:30am a 6:30pm<br>
                              
                            </p>
                        </div>
                    </div>

                </div>

            </div>

        </div>




        <div class="col-lg-5 col-md-5 col-sm-5">

            <div class="carousel-heading no-margin">
                <h4>Contactanos</h4>
            </div>

            <div class="page-content contact-form">

                <div role="form">
                    <label>Asunto </label>
                    <asp:TextBox ID="txtsubject" runat="server"  placeholder="Asunto del mensaje"></asp:TextBox>
                 
                    <label>Nombre completo (Requerido)</label>
                    <asp:TextBox ID="txtname" runat="server" required placeholder="Nombre completo"></asp:TextBox>

                    <label>Correo electrónico (Requerido)</label>
                    <asp:TextBox ID="txtEmail" runat="server"  required placeholder=" alguien@ejemplo.com"></asp:TextBox>

                    <label>Mensaje (Requerido)</label>
                    <asp:TextBox ID="txtMessage" runat="server"  TextMode="MultiLine" required placeholder=" Escribe tu mensaje aqui..."></asp:TextBox>
                    
                    <asp:Button ID="btnContact" runat="server"  CssClass="big" Text="Enviar mensaje" />

                </div>
            </div>

        </div>


    </div>


</asp:Content>
