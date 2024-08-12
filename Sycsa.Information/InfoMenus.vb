Public Class InfoMenus
#Region "Variables"
    Private _IdMenus As Long
    Private _Name As String
    Private _Description As String
    Private _Active As Boolean
#End Region

#Region "Buider"
    Sub New()
        MyBase.New()
    End Sub
#End Region
#Region "Property"

    Public Property IdMenus As Long
        Get
            Return _IdMenus
        End Get
        Set(value As Long)
            _IdMenus = value
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
    Public Property Description As String
        Get
            Return _Description
        End Get
        Set(value As String)
            _Description = value
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
