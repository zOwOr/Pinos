Public Class InfoCustomersAddresses
#Region "Variable"
    Private _IdAddress As Long
    Private _IdClient As Long
    Private _Company As String
    Private _RFC As String
    Private _Phone As String
    Private _Address As String
    Private _Colony As String
    Private _CP As String
    Private _City As String
    Private _State As String
    Private _Country As String
    Private _DefaultAdrees As Integer

#End Region

#Region "Builder"
    Sub New()
        MyBase.New()
    End Sub
#End Region

#Region "Property"

    Public Property DefaultAdrees As Integer
        Get
            Return _DefaultAdrees
        End Get
        Set(value As Integer)
            _DefaultAdrees = value
        End Set
    End Property

    Public Property IdAddress As Long
        Get
            Return _IdAddress
        End Get
        Set(value As Long)
            _IdAddress = value
        End Set
    End Property

    Public Property IdClient As Long
        Get
            Return _IdClient
        End Get
        Set(value As Long)
            _IdClient = value
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
    Public Property Phone As String
        Get
            Return _Phone
        End Get
        Set(value As String)
            _Phone = value
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
    Public Property Country As String
        Get
            Return _Country
        End Get
        Set(value As String)
            _Country = value
        End Set
    End Property
#End Region
End Class
