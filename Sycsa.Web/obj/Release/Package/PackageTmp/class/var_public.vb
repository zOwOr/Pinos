Imports System
Imports System.Data
Imports System.Linq
Imports sycsa.Information

Public Class vpublic



#Region "Variables para titulos y etiquetas de la master"

    Public _Layout_title As String
    Public _Layout_menuOption As Integer
    Public _Layout_bannerOption As Integer
    Public _Layout_metadescription As String
    Public _Layout_metadekeyword As String
    Public _Layout_Lenguage As String
    Public _Layout_phone As String
    Public _Layout_address As String
    Public _Layout_Empresa As String
    Public _Layout_emailContact As String
    Public _Layout_skype As String

    Public _Layout_logoimg As Boolean = True
    Public _Layout_img1_titulo As String = " "
    Public _Layout_img1_descripcion As String = " "
    Public _Layout_img2_titulo As String = " "
    Public _Layout_img2_descripcion As String = " "
    Public _Layout_img3_titulo As String = " "
    Public _Layout_img3_descripcion As String = " "

#End Region


#Region "Variables para el contenido de las paginas"

    Public _TotalItemsProduct As Integer
    Public _PorcentajeIva As Decimal
    Public _SubTotal As Decimal
    Public _Total As Decimal
    Public _MethodSendComm As String
    Public _MethodSendPrice As Decimal
    Public _MethodSendTitle As String
    Public _Lista As Long
    Public _RFC As String

#End Region


    Public Function updElemntsCart()

        _TotalItemsProduct = ShoppingCart.CapturarProducto().ListProducts.Count
        HttpContext.Current.Session("_TotalItemsProduct") = _TotalItemsProduct

        _PorcentajeIva = 0.16 'Aqui se coloca el valor de la base de datos
        HttpContext.Current.Session("_SubTotal") = ShoppingCart.CapturarProducto().SubTotal
        HttpContext.Current.Session("_PorcentajeIva") = (ShoppingCart.CapturarProducto().SubTotal * _PorcentajeIva)

        Return Nothing
    End Function




End Class
