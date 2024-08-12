Public Class InfoOrders
#Region "Variable"

    Private _IdOrders As Long
    Private _NOrder As Long
    Private _IdCustomer As Long
    Private _IdAddressCustomers As Long
    Private _IdPaymentMethod As Integer
    Private _OrderTotalPrices As Double
    Private _OrderIVA As Double
    Private _Bill As String
    Private _OrderDate As DateTime
    Private _OrderFinished As DateTime
    Private _OrderCancel As String
    Private _PaymentStatus As String
    Private _Customer As String
    Private _Phone As String
    Private _Company As String
    Private _RFC As String
    Private _PhoneC As String
    Private _Address As String
    Private _Colony As String
    Private _CP As String
    Private _City As String
    Private _State As String
    Private _IdMethodSend As Integer
    Private _Quantiy As Integer
    Private _Price As Decimal
    Private _IdProduct As Int64
    Private _Email As String

#End Region
#Region "Buider"
    Sub New()
        MyBase.New()
    End Sub
#End Region
#Region "Property"

    Public Property Email As String
        Get
            Return _Email
        End Get
        Set(value As String)
            _Email = value
        End Set

    End Property

    Public Property IdProduct As Int64
        Get
            Return _IdProduct
        End Get
        Set(value As Int64)
            _IdProduct = value
        End Set

    End Property

    Public Property Price As Decimal
        Get
            Return _Price
        End Get
        Set(value As Decimal)
            _Price = value
        End Set

    End Property

    Public Property Quantiy As Integer
        Get
            Return _Quantiy
        End Get
        Set(value As Integer)
            _Quantiy = value
        End Set
    End Property

    Public Property IdMethodSend As String
        Get
            Return _IdMethodSend
        End Get
        Set(value As String)
            _IdMethodSend = value
        End Set
    End Property

    Public Property Company As String
        Get
            Return _Company
        End Get
        Set(value As String)
            _Company = value
        End Set
    End Property
    Public Property RFC As String
        Get
            Return _RFC
        End Get
        Set(value As String)
            _RFC = value
        End Set
    End Property

    Public Property PhoneC As String
        Get
            Return _PhoneC
        End Get
        Set(value As String)
            _PhoneC = value
        End Set
    End Property
    Public Property Address As String
        Get
            Return _Address
        End Get
        Set(value As String)
            _Address = value
        End Set
    End Property
    Public Property Colony As String
        Get
            Return _Colony
        End Get
        Set(value As String)
            _Colony = value
        End Set
    End Property
    Public Property CP As String
        Get
            Return _CP
        End Get
        Set(value As String)
            _CP = value
        End Set
    End Property
    Public Property City As String
        Get
            Return _City
        End Get
        Set(value As String)
            _City = value
        End Set
    End Property
    Public Property State As String
        Get
            Return _State
        End Get
        Set(value As String)
            _State = value
        End Set
    End Property
    Public Property Customer As String
        Get
            Return _Customer
        End Get
        Set(value As String)
            _Customer = value
        End Set
    End Property
    Public Property Phone As String
        Get
            Return _Phone
        End Get
        Set(value As String)
            _Phone = value
        End Set
    End Property
    Public Property IdOrders As Long
        Get
            Return _IdOrders
        End Get
        Set(value As Long)
            _IdOrders = value
        End Set
    End Property
    Public Property NOrder As Long
        Get
            Return _NOrder
        End Get
        Set(value As Long)
            _NOrder = value
        End Set
    End Property
    Public Property IdCustomer As Long
        Get
            Return _IdCustomer
        End Get
        Set(value As Long)
            _IdCustomer = value
        End Set
    End Property

    Public Property IdAddressCustomers As Long
        Get
            Return _IdAddressCustomers
        End Get
        Set(value As Long)
            _IdAddressCustomers = value
        End Set
    End Property
    Public Property IdPaymentMethod As Double
        Get
            Return _IdPaymentMethod
        End Get
        Set(value As Double)
            _IdPaymentMethod = value
        End Set
    End Property
    Public Property OrderTotalPrices As Double
        Get
            Return _OrderTotalPrices
        End Get
        Set(value As Double)
            _OrderTotalPrices = value
        End Set
    End Property

    Public Property OrderIVA As Double
        Get
            Return _OrderIVA
        End Get
        Set(value As Double)
            _OrderIVA = value
        End Set
    End Property
    Public Property Bill As String
        Get
            Return _Bill
        End Get
        Set(value As String)
            _Bill = value
        End Set
    End Property
    Public Property OrderDate As DateTime
        Get
            Return _OrderDate
        End Get
        Set(value As DateTime)
            _OrderDate = value
        End Set
    End Property
    Public Property OrderFinished As DateTime
        Get
            Return _OrderFinished
        End Get
        Set(value As DateTime)
            _OrderFinished = value
        End Set
    End Property
    Public Property OrderCancel As String
        Get
            Return _OrderCancel
        End Get
        Set(value As String)
            _OrderCancel = value
        End Set
    End Property
    Public Property PaymentStatus As String
        Get
            Return _PaymentStatus
        End Get
        Set(value As String)
            _PaymentStatus = value
        End Set
    End Property
#End Region
End Class
