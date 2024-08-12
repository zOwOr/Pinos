Public Class InfoGcRecoveryPass
#Region "Variable"
    Private _Id_R As Int64
    Private _IdUser As Int64
    Private _Fecha As DateTime
    Private _IP As String
    Private _Hash As String
    Private _Status As Int64
    Private _Expira As DateTime
#End Region


#Region "Builder"
    Sub New()
        MyBase.New()
    End Sub
#End Region


#Region "Propertys"
    Public Property Id_R As Int64
        Get
            Return _Id_R
        End Get
        Set(value As Int64)
            _Id_R = value
        End Set
    End Property
    Public Property IdUser As Int64
        Get
            Return _IdUser
        End Get
        Set(value As Int64)
            _IdUser = value
        End Set
    End Property
    Public Property Fecha As DateTime
        Get
            Return _Fecha
        End Get
        Set(value As DateTime)
            _Fecha = value
        End Set
    End Property
    Public Property IP As String
        Get
            Return _IP
        End Get
        Set(value As String)
            _IP = value
        End Set
    End Property
    Public Property HASH As String
        Get
            Return _Hash
        End Get
        Set(value As String)
            _Hash = value
        End Set
    End Property
    Public Property Status As Int64
        Get
            Return _Status
        End Get
        Set(value As Int64)
            _Status = value
        End Set
    End Property
    Public Property Expira As DateTime
        Get
            Return _Expira
        End Get
        Set(value As DateTime)
            _Expira = value
        End Set
    End Property

#End Region
End Class
