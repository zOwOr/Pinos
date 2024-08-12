Public Class InfoProducts
#Region "Variable"


    Private _ProductId As Long
    Private _idCategory As String
    Private _SubCategoryId As String
    Private _MarkId As String
    Private _ProductKey As String
    Private _ProductName As String
    Private _ShortDescription As String
    Private _LongDescription As String
    Private _ProductFeatures As String
    Private _UnitPrice As Decimal
    Private _UnitInStock As Long
    Private _Promote As Integer
    Private _MarckName As String
    Private _CLAVEPRODUCTO As Long
    Private _cantidadunidad As Decimal
    Private _tasa_iva As Decimal
    Private _tasaieps As Decimal
    Private _Unidad As String
    Private _Imagen As String
#End Region

#Region "Builder"
    Sub New()
        MyBase.New()
    End Sub
#End Region

#Region "Property"

    Public Property idCategory As String
        Get
            Return _idCategory
        End Get
        Set(value As String)
            _idCategory = value
        End Set
    End Property

    Public Property Promote As Integer
        Get
            Return _Promote
        End Get
        Set(value As Integer)
            _Promote = value
        End Set
    End Property

    Public Property ProductId As Long
        Get
            Return _ProductId
        End Get
        Set(value As Long)
            _ProductId = value
        End Set
    End Property
    Public Property SubCategory As String
        Get
            Return _SubCategoryId
        End Get
        Set(value As String)
            _SubCategoryId = value
        End Set
    End Property
    Public Property MarkId As String
        Get
            Return _MarkId
        End Get
        Set(value As String)
            _MarkId = value
        End Set
    End Property
    Public Property ProductKey As String
        Get
            Return _ProductKey
        End Get
        Set(value As String)
            _ProductKey = value
        End Set
    End Property
    Public Property ProductName As String
        Get
            Return _ProductName
        End Get
        Set(value As String)
            _ProductName = value
        End Set
    End Property
    Public Property ShortDescription As String
        Get
            Return _ShortDescription
        End Get
        Set(value As String)
            _ShortDescription = value
        End Set
    End Property
    Public Property LongDescription As String
        Get
            Return _LongDescription
        End Get
        Set(value As String)
            _LongDescription = value
        End Set
    End Property
    Public Property ProductFeatures As String
        Get
            Return _ProductFeatures
        End Get
        Set(value As String)
            _ProductFeatures = value
        End Set
    End Property
    Public Property UnitPrice As Decimal
        Get
            Return _UnitPrice
        End Get
        Set(value As Decimal)
            _UnitPrice = value
        End Set
    End Property
    Public Property UnitInStock As Long
        Get
            Return _UnitInStock
        End Get
        Set(value As Long)
            _UnitInStock = value
        End Set
    End Property
    Public Property MarckName As String
        Get
            Return _MarckName
        End Get
        Set(value As String)
            _MarckName = value
        End Set
    End Property
    Public Property CLAVEPRODUCTO As Long
        Get
            Return _CLAVEPRODUCTO
        End Get
        Set(value As Long)
            _CLAVEPRODUCTO = value
        End Set
    End Property
    Public Property cantidadunidad As Decimal
        Get
            Return _cantidadunidad
        End Get
        Set(value As Decimal)
            _cantidadunidad = value
        End Set
    End Property
    Public Property tasa_iva As Decimal
        Get
            Return _tasa_iva
        End Get
        Set(value As Decimal)
            _tasa_iva = value
        End Set
    End Property
    Public Property tasaieps As Decimal
        Get
            Return _tasaieps
        End Get
        Set(value As Decimal)
            _tasaieps = value
        End Set
    End Property
    Public Property Unidad As String
        Get
            Return _Unidad
        End Get
        Set(value As String)
            _Unidad = value
        End Set
    End Property
    Public Property Imagen As String
        Get
            Return _Imagen
        End Get
        Set(value As String)
            _Imagen = value
        End Set
    End Property
#End Region
End Class
