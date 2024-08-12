Public Class InfoCustomers
#Region "Variable"
    Private _IdCustomer As Long
    Private _IdAddress As Int64
    Private _Email As String
    Private _Pass As String
    Private _Name As String
    Private _LastName As String
    Private _BirthDate As Date
    Private _Phone As String
    Private _EmailVerifield As Boolean
    Private _Active As Boolean
    Private _CustomersDate As DateTime
    Private _CompanyFac As String
    Private _RFCFac As String
    Private _PhoneFac As String
    Private _DireccionFac As String
    Private _ColoniaFac As String
    Private _CPFac As String
    Private _CityFac As String
    Private _StateFac As String
    Private _TermsConditions As String
    Private _UserName As String
    Private _Country As String
    Private _Canceled As Integer
    Private _Paid As Integer
    Private _CondVenta As String
    Private _Vendedor As String
    Private _FormaPago As String
    Private _UsoCfdi As String

    ''Contact
    Private _Subject As String
    Private _ContactName As String
    Private _ContactEmail As String
    Private _ContactMsg As String

#End Region

#Region "Builder"
    Sub New()
        MyBase.New()
    End Sub
#End Region

#Region "Property"

    Public Property Canceled As Integer
        Get
            Return _Canceled
        End Get
        Set(value As Integer)
            _Canceled = True
        End Set
    End Property

    Public Property Paid As Integer
        Get
            Return _Paid
        End Get
        Set(value As Integer)
            _Paid = value
        End Set
    End Property


    Public Property IdAddress As Int64
        Get
            Return _IdAddress
        End Get
        Set(value As Int64)
            _IdAddress = value
        End Set
    End Property



    Public Property UserName As String
        Get
            Return _UserName
        End Get
        Set(value As String)
            _UserName = value
        End Set
    End Property
    Public Property TermsConditions As String
        Get
            Return _TermsConditions
        End Get
        Set(value As String)
            _TermsConditions = value
        End Set
    End Property
    Public Property Subject As String
        Get
            Return _Subject
        End Get
        Set(value As String)
            _Subject = value
        End Set
    End Property
    Public Property ContactName As String
        Get
            Return _ContactName
        End Get
        Set(value As String)
            _ContactName = value
        End Set
    End Property
    Public Property ContactEmail As String
        Get
            Return _ContactEmail
        End Get
        Set(value As String)
            _ContactEmail = value
        End Set
    End Property
    Public Property ContactMsg As String
        Get
            Return _ContactMsg
        End Get
        Set(value As String)
            _ContactMsg = value
        End Set
    End Property

    Public Property DireccionFac As String
        Get
            Return _DireccionFac
        End Get
        Set(value As String)
            _DireccionFac = value
        End Set
    End Property
    Public Property CompanyFac As String
        Get
            Return _CompanyFac
        End Get
        Set(value As String)
            _CompanyFac = value
        End Set
    End Property
    Public Property RFCFac As String
        Get
            Return _RFCFac
        End Get
        Set(value As String)
            _RFCFac = value
        End Set
    End Property
    Public Property PhoneFac As String
        Get
            Return _PhoneFac
        End Get
        Set(value As String)
            _PhoneFac = value
        End Set
    End Property
    Public Property ColoniaFac As String
        Get
            Return _ColoniaFac
        End Get
        Set(value As String)
            _ColoniaFac = value
        End Set
    End Property
    Public Property CPFac As String
        Get
            Return _CPFac
        End Get
        Set(value As String)
            _CPFac = value
        End Set
    End Property
    Public Property CityFac As String
        Get
            Return _CityFac
        End Get
        Set(value As String)
            _CityFac = value
        End Set
    End Property
    Public Property StateFac As String
        Get
            Return _StateFac
        End Get
        Set(value As String)
            _StateFac = value
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
    Public Property Email As String
        Get
            Return _Email
        End Get
        Set(value As String)
            _Email = value
        End Set
    End Property
    Public Property Pass As String
        Get
            Return _Pass
        End Get
        Set(value As String)
            _Pass = value
        End Set
    End Property
    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
        End Set
    End Property
    Public Property LastName As String
        Get
            Return _LastName
        End Get
        Set(value As String)
            _LastName = value
        End Set
    End Property
    Public Property BirthDate As Date
        Get
            Return _BirthDate
        End Get
        Set(value As Date)
            _BirthDate = value
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
    Public Property EmailVerifield As Boolean
        Get
            Return _EmailVerifield
        End Get
        Set(value As Boolean)
            _EmailVerifield = value
        End Set
    End Property
    Public Property Active As Boolean
        Get
            Return _Active
        End Get
        Set(value As Boolean)
            _Active = value
        End Set
    End Property
    Public Property CustomersDate As DateTime
        Get
            Return _CustomersDate
        End Get
        Set(value As DateTime)
            _CustomersDate = value
        End Set
    End Property


    Public Property Country As String
        Get
            Return _Country
        End Get
        Set(value As String)
            _Country = value
        End Set
    End Property
    Public Property CondVenta As String
        Get
            Return _CondVenta
        End Get
        Set(value As String)
            _CondVenta = value
        End Set
    End Property
    Public Property Vendedor As String
        Get
            Return _Vendedor
        End Get
        Set(value As String)
            _Vendedor = value
        End Set
    End Property

    Public Property FormaPago As String
        Get
            Return _FormaPago
        End Get
        Set(value As String)
            _FormaPago = value
        End Set
    End Property

    Public Property UsoCfdi As String
        Get
            Return _UsoCfdi
        End Get
        Set(value As String)
            _UsoCfdi = value
        End Set
    End Property
#End Region
End Class
