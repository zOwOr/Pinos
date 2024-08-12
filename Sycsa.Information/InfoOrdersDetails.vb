Public Class InfoOrdersDetails
#Region "Variable"
    Private _IdOrdersDetails As Long
    Private _IdOrder As Long
    Private _IdProduct As Integer
    Private _UnitPrice As Decimal
    Private _Quantity As Short
#End Region

#Region "Builder"
    Sub New()
        MyBase.New()
    End Sub
#End Region

#Region "Propertys"
    Public Property IdOrdersDetails As Long
        Get
            Return _IdOrdersDetails
        End Get
        Set(value As Long)
            _IdOrdersDetails = value
        End Set
    End Property
    Public Property IdOrder As Long
        Get
            Return _IdOrder
        End Get
        Set(value As Long)
            _IdOrder = value
        End Set
    End Property
    Public Property IdProduct As Integer
        Get
            Return _IdProduct
        End Get
        Set(value As Integer)
            _IdProduct = value
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
    Public Property Quantity As Integer
        Get
            Return _Quantity
        End Get
        Set(value As Integer)
            _Quantity = value
        End Set
    End Property
#End Region
End Class
