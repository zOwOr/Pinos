Public Class InfoUsers
#Region "Variable"
    Private _Id As Int64
    Private _UserLogin As String
    Private _UserPass As String
    Private _UserNicename As String
    Private _UserName As String
    Private _UserEmail As String
    Private _UserRegistered As DateTime
    Private _Active As Boolean
#End Region


#Region "Builder"
    Sub New()
        MyBase.New()
    End Sub
#End Region


#Region "Propertys"
    Public Property Id As String
        Get
            Return _Id
        End Get
        Set(value As String)
            _Id = value
        End Set
    End Property
    Public Property UserLogin As String
        Get
            Return _UserLogin
        End Get
        Set(value As String)
            _UserLogin = value
        End Set
    End Property
    Public Property UserPass As String
        Get
            Return _UserPass
        End Get
        Set(value As String)
            _UserPass = value
        End Set
    End Property
    Public Property UserNicename As String
        Get
            Return _UserNicename
        End Get
        Set(value As String)
            _UserNicename = value
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
    Public Property UserEmail As String
        Get
            Return _UserEmail
        End Get
        Set(value As String)
            _UserEmail = value
        End Set
    End Property
    Public Property UserRegistered As String
        Get
            Return _UserRegistered
        End Get
        Set(value As String)
            _UserRegistered = value
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
#End Region
End Class
