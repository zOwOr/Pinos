Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.IO
Imports System.Xml
Public Class addShoppingCart : Implements IEquatable(Of addShoppingCart)

    Private m__Cantidad As Int64

    Private _IdProduct As Int64
    Private _Unidad As String
    Private _Product As cProducts = Nothing

    Public Property IdProduct() As Integer
        Get
            Return _IdProduct
        End Get
        Set(value As Integer)
            _Product = Nothing
            _IdProduct = value
            _Unidad = value
        End Set
    End Property

    Public ReadOnly Property Product() As cProducts
        Get
            If _Product Is Nothing Then
                _Product = New cProducts(_IdProduct, _Unidad)
            End If
            Return _Product
        End Get
    End Property

    Public ReadOnly Property Producto() As String
        Get
            Return Product._Descriptionshort
        End Get
    End Property

    Public ReadOnly Property Descripcion() As String
        Get
            Return Product._Descriptionshort
        End Get
    End Property

    Public Property Unidad() As String
        Get
            Return _Unidad
        End Get
        Set(value As String)
            _Unidad = value
        End Set
    End Property

    Public ReadOnly Property Precio() As Decimal
        Get
            Return Product._Price
        End Get
    End Property

    Public Property Cantidad() As Integer
        Get
            Return m__Cantidad
        End Get
        Set(value As Integer)
            m__Cantidad = value
        End Set
    End Property

    Public ReadOnly Property Total() As Decimal
        Get
            Return Precio * Cantidad
        End Get
    End Property

    Public Sub New(pId As Integer, Optional ByVal unidad As String = "")
        _IdProduct = pId
        _Unidad = unidad
    End Sub

    Public ReadOnly Property CLAVEPRODUCTO() As Long
        Get
            Return Product._CLAVEPRODUCTO

        End Get
    End Property

    Public ReadOnly Property cantidadunidad() As Decimal
        Get
            Return Product._cantidadunidad
        End Get
    End Property

    Public ReadOnly Property tasa_iva() As Decimal
        Get
            Return Product._tasa_iva
        End Get
    End Property

    Public ReadOnly Property tasaieps() As Decimal
        Get
            Return Product._tasaieps
        End Get
    End Property


    Public Overloads Function Equals(pItem As addShoppingCart) As Boolean Implements IEquatable(Of addShoppingCart).Equals
        Return IIf(pItem.IdProduct = _IdProduct And pItem.Unidad = _Unidad, True, False)
    End Function

End Class