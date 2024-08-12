<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="seleccAddress.aspx.vb" Inherits="sycsa.Web.seleccAddress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Direcciones</title>

    <%--<link rel="stylesheet" href="/in/css/bootstrap.min.css" />--%>
    <link href="wPanel/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="/in/css/perfect-scrollbar.css" />

    <link rel="stylesheet" href="/in/css/flexslider.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="/in/css/fontello.css" />
    <link rel="stylesheet" type="text/css" href="/in/css/settings.css" media="screen" />
    <link href="/in/css/jquery.nouislider.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="/in/css/style.css" />

    <script src="/in/js/jquery-1.11.0.min.js"></script>
    <script defer src="/in/js/bootstrap.min.js"></script>
    <script src="/in/js/main-script.js"></script>


    <script>
        function SetAd(ad) {
            var objRef = window.opener;
            var _url

            if (objRef.location.href.indexOf("?address") == -1) {
                _url = objRef.location.href + "?address=change&param=" + ad;
            } else {
                _url = objRef.location.pathname + "?address=change&param=" + ad;
            }
           
            objRef.location = _url;
            window.close();
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-lg-12">

                <div class="carousel-heading no-margin">
                    <h4 id="lblAddress" runat="server" meta:resourcekey="lblAddress">Lista de Direcciones</h4>
                </div>

                <div class="page-content" style="margin: auto; padding: 20px;">

                    <p id="lblTitleAddress" runat="server" meta:resourcekey="lblTitleAddress">
                        Seleccione la dirección que desea utilizar para el envío de sus productos.
                    </p>

                    <asp:GridView ID="listAd" runat="server" AutoGenerateColumns="False" DataKeyNames="idAddress" DataSourceID="SqlAddress"
                        CssClass="table-bordered table-hover" ShowHeader="False" Width="95%" GridLines="None">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <p>
                                        <button type="button" onclick="return SetAd('<%#Eval("idAddress")%>');" class="btn btn-primary"><i class="icons icon-ok-3"></i> Seleccionar</button>
                                    </p>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"  />
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <address style="padding: 10px; font-style:italic;">

                                        <p>
                                            <strong><%# Eval("Company")%></strong>
                                            <br />
                                            <%# Eval("RFC")%>
                                        </p>
                                        <p>
                                            <strong>Dir.</strong>  <%# Eval("Adress")%>
                                            <br />
                                            <strong>Tel.</strong>Tel: <%# Eval("Phone")%>
                                            <br />
                                            <strong>Cp.</strong> <%# Eval("CP")%>
                                            <br />
                                            <strong>Col.</strong> <%# Eval("Colony")%>, <%# Eval("City")%>, <%# Eval("State")%>
                                        </p>

                                    </address>
                                </ItemTemplate>
                                <HeaderStyle Width="95%" />
                            </asp:TemplateField>
                          
                        </Columns>
                    </asp:GridView>
                </div>

                <asp:SqlDataSource runat="server" ID="SqlAddress" ConnectionString='<%$ ConnectionStrings:MySQLConnection %>' 
                    ProviderName='<%$ ConnectionStrings:MySQLConnection.ProviderName %>' 
                    SelectCommand="SELECT idAddress, idClient, Company, RFC, Phone, Adress, Colony, CP, City, State, Country FROM customersaddresses WHERE (idClient = @idClient)">
                    <SelectParameters>
                        <asp:SessionParameter  Name="idClient" SessionField="MM_UserId" DefaultValue="-1" DbType="Int64" />
                    </SelectParameters>
                </asp:SqlDataSource>

            </div>
        </div>
    </form>
</body>
</html>
