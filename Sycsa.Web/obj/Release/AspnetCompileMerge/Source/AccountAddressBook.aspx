<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Layout/SiteWeb.Master" CodeBehind="AccountAddressBook.aspx.vb" Inherits="sycsa.Web.AccountAddressBook" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Html_head" runat="server">
    <script>
        $(document).ready(function () {
            $(".edtRow").click(function (e) {
                alert("s");
                _key = $(this).data("row"); eventTarget = $(this).data("action");
                __doPostBack(eventTarget, _key);
            });
        });

        function getAction(tar, id) {
            __doPostBack(tar, id);
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Html_Content" runat="server">

    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12">

            <div class="page-content">

                <h2>Direcciones </h2>
                <span>A continuación se muestra una lista de direcciones que tiene registradas en su cuenta.
                    Puede editar o eliminar las direcciones de la lista.
                </span>

                <p>
                    <button type="button" onclick="window.location='/MyAccount.aspx'">Regresar</button>
                    <button type="button" onclick="window.location='/AccountAddressBookNew.aspx'">Agregar dirección</button>
                </p>

                <div style="margin-top: 35px; margin-bottom: 15px;" >
                    <%
                        'Carga de direcciones
                        For Each _row As Data.DataRow In DtAddress.Tables(0).Rows
                            
                            Response.Write("<div class=""row"">")
                            Response.Write("<div class=""col-lg-8 col-md-8 col-sm-8"">")
                            
                            Response.Write("<div class=""product-info"">")
                            Response.Write("<address>")
                            
                            If IsDBNull(_row.Item("Company")) = False Then
                                If _row.Item("Company") <> "" Then
                                    Response.Write("<strong>" & _row.Item("Company") & "</strong></br>")
                                End If
                            End If
                           
                            If IsDBNull(_row.Item("RFC")) = False Then
                                If _row.Item("RFC") <> "" Then
                                    Response.Write("RFC. " & _row.Item("RFC") & "</br>")
                                End If
                            End If
                                                       
                            Response.Write(_row.Item("Adress") & "</br>")
                            Response.Write(_row.Item("Colony") & "</br>")
                            Response.Write(_row.Item("City") & ", " & _row.Item("State") & ". " & "<abbr title=""Código Postal"">C.P. </abbr>" & _row.Item("CP") & "</br>")
                            Response.Write("<abbr title=""Teléfono"">Tel:</abbr> " & _row.Item("Phone") & "</br>")
                            Response.Write("<strong>" & _row.Item("Envio") & "</strong></br>")
                            Response.Write("</address>")
                            Response.Write("</br>")
                            Response.Write("<address>")
                            Response.Write("</div>")
                            
                            Response.Write("<div class=""col-lg-4 col-md-4 col-sm-4"">")
                            'Response.Write("<div class=""product-actions full-width"" >")
                            Response.Write("<p>")
                            Response.Write("<button type=""button""  onclick=""return getAction('Edt','" & _row.Item("idAddress") & "');""   title=""Editar"" >Editar</button>")
                            Response.Write("<button type=""button"" onclick=""return getAction('del','" & _row.Item("idAddress") & "');""   title=""Eliminar"" >Eliminar</button>")
                            Response.Write("</p>")
                            'Response.Write("</div>")
                            Response.Write("</div>")
                            
                            Response.Write("</div>")
                            Response.Write("</div>")
                        Next
                        
                    %>
                </div>
            </div>

        </div>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Html_sidebar" runat="server">
</asp:Content>
