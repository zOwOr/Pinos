Public Class InfoPosts
#Region "Variables"
    Private _Id As Long
    Private _PostAuthor As Long
    Private _PostContent As Long
    Private _PostTitle As String
    Private _PostName As String
    Private _MenuOrder As String
    Private _PostDate As DateTime
    Private _PostModified As DateTime
    Private _PostType As String
    Private _Active As Boolean
#End Region
#Region "Builder"
    Sub New()
        MyBase.New()
    End Sub
#End Region
#Region "Property"
    Public Property Id As Long
        Get
            Return _Id
        End Get
        Set(value As Long)
            _Id = value
        End Set
    End Property
    Public Property PostAuthor As Long
        Get
            Return _PostAuthor
        End Get
        Set(value As Long)
            _PostAuthor = value
        End Set
    End Property

    Public Property PostContent As Long
        Get
            Return _PostContent
        End Get
        Set(value As Long)
            _PostContent = value
        End Set
    End Property
    Public Property PostTitle As String
        Get
            Return _PostTitle

        End Get
        Set(value As String)
            _PostTitle = value
        End Set
    End Property
    Public Property PostName As String
        Get
            Return _PostName
        End Get
        Set(value As String)
            _PostName = value
        End Set
    End Property
    Public Property MenuOrder As String
        Get
            Return _MenuOrder
        End Get
        Set(value As String)
            _MenuOrder = value
        End Set
    End Property
    Public Property PostDate As DateTime
        Get
            Return _PostDate
        End Get
        Set(value As DateTime)
            _PostDate = value
        End Set
    End Property
    Public Property PostModified As DateTime
        Get
            Return _PostModified
        End Get
        Set(value As DateTime)
            _PostModified = value
        End Set
    End Property
    Public Property PostType As String
        Get
            Return _PostType
        End Get
        Set(value As String)
            _PostType = value
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
