Public Class InfoNewsLetters
#Region "Variable"
    Private _IdNewsLetters As Int64
    Private _NewsLettersName As String
    Private _Subject As String
    Private _ContentHTML As String
    Private _ContentText As String
    Private _DateSend As DateTime
    Private _Active As Boolean
    Private _NewLettersDate As DateTime
    Private _IdCategory As Integer
#End Region

#Region "Builder"
    Sub New()
        MyBase.New()
    End Sub
#End Region

#Region "Propertys"
    Public Property IdCategory As Integer
        Get
            Return _IdCategory
        End Get
        Set(value As Integer)
            _IdCategory = value
        End Set
    End Property
    Public Property IdNewsLetters As String
        Get
            Return _IdNewsLetters
        End Get
        Set(value As String)
            _IdNewsLetters = value
        End Set
    End Property
    Public Property NewsLettersName As String
        Get
            Return _NewsLettersName
        End Get
        Set(value As String)
            _NewsLettersName = value
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
    Public Property ContentHTML As String
        Get
            Return _ContentHTML
        End Get
        Set(value As String)
            _ContentHTML = value
        End Set
    End Property
    Public Property ContentText As String
        Get
            Return _ContentText
        End Get
        Set(value As String)
            _ContentText = value
        End Set
    End Property
    Public Property DateSend As DateTime
        Get
            Return _DateSend
        End Get
        Set(value As DateTime)
            _DateSend = value
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
    Public Property NewLettersDate As DateTime
        Get
            Return _NewLettersDate
        End Get
        Set(value As DateTime)
            _NewLettersDate = value
        End Set
    End Property
#End Region
End Class
