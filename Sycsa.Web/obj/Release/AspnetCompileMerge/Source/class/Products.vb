Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports sycsa.BusinessLayer
Imports sycsa.Information


Public Class cProducts
    Dim ObjBLProducts As New BLProducts
    Public Html As New vpublic

    Public Property _IdProduct() As Integer
        Get
            Return m__IdProduct
        End Get
        Set(value As Integer)
            m__IdProduct = value
        End Set
    End Property
    Private m__IdProduct As Integer
    Public Property _Imagen() As String
        Get
            Return m__Imagen
        End Get
        Set(value As String)
            m__Imagen = value
        End Set
    End Property
    Private m__Imagen As String
    Public Property _Price() As Decimal
        Get
            Return m__Price
        End Get
        Set(value As Decimal)
            m__Price = value
        End Set
    End Property
    Private m__Price As Decimal
    Public Property _ProductName() As String
        Get
            Return m__ProductName
        End Get
        Set(value As String)
            m__ProductName = value
        End Set
    End Property
    Private m__ProductName As String
    Public Property _Unidad() As String
        Get
            Return m__Unidad
        End Get
        Set(value As String)
            m__Unidad = value
        End Set
    End Property
    Private m__Unidad As String
    Public Property _ProductQuantity() As Integer
        Get
            Return m__ProductQuantity
        End Get
        Set(value As Integer)
            m__ProductQuantity = value
        End Set
    End Property
    Private m__ProductQuantity As Integer
    Public Property _Descriptionshort() As String
        Get
            Return m__Descriptionshort
        End Get
        Set(value As String)
            m__Descriptionshort = value
        End Set
    End Property
    Private m__Descriptionshort As String

    Public Property _CLAVEPRODUCTO() As Long
        Get
            Return m__CLAVEPRODUCTO
        End Get
        Set(value As Long)
            m__CLAVEPRODUCTO = value
        End Set
    End Property
    Private m__CLAVEPRODUCTO As Decimal

    Public Property _cantidadunidad() As Decimal
        Get
            Return m__cantidadunidad
        End Get
        Set(value As Decimal)
            m__cantidadunidad = value
        End Set
    End Property
    Private m__cantidadunidad As Decimal

    Public Property _tasa_iva() As Decimal
        Get
            Return m__tasa_iva
        End Get
        Set(value As Decimal)
            m__tasa_iva = value
        End Set
    End Property
    Private m__tasa_iva As Decimal

    Public Property _tasaieps() As Decimal
        Get
            Return m__tasaieps
        End Get
        Set(value As Decimal)
            m__tasaieps = value
        End Set
    End Property
    Private m__tasaieps As Decimal

    Public Sub New(pId As Integer, ByVal unidad As String)

        _IdProduct = pId

        Dim __ProductSearch As New List(Of InfoProducts)
        With ObjBLProducts

            .ProductId = _IdProduct
            .UnitInStock = IIf(HttpContext.Current.Session("MM_Lista") Is Nothing, 0, HttpContext.Current.Session("MM_Lista"))
            .Unidad = unidad
            __ProductSearch = .LoadById

            If __ProductSearch(0) IsNot Nothing Then
                _ProductName = __ProductSearch(0).ProductName
                _Descriptionshort = __ProductSearch(0).ShortDescription
                _Price = __ProductSearch(0).UnitPrice
                _CLAVEPRODUCTO = __ProductSearch(0).CLAVEPRODUCTO
                _cantidadunidad = __ProductSearch(0).cantidadunidad
                _tasa_iva = __ProductSearch(0).tasa_iva
                _tasaieps = __ProductSearch(0).tasaieps
                _Unidad = __ProductSearch(0).Unidad
            End If

        End With


    End Sub

End Class