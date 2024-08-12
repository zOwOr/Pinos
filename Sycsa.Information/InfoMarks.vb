Public Class InfoMarks
#Region "Variable"
    Private _IdMark As Long
    Private _MarkName As String
    Private _Description As String
    Private _MarkImage As String
    Private _MarkThumb As String
    Private _Active As Boolean
#End Region
#Region "Builder"
    Sub New()
        MyBase.New()
    End Sub
#End Region
#Region "Property"
    Public Property IdMark As Long
        Get
            Return _IdMark
        End Get
        Set(value As Long)
            _IdMark = value
        End Set
    End Property

    Public Property MarkName As String
        Get
            Return _MarkName
        End Get
        Set(value As String)
            _MarkName = value
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
    Public Property MarkIamge As String
        Get
            Return _MarkImage
        End Get
        Set(value As String)
            _MarkImage = value
        End Set
    End Property
    Public Property MarkThumb As String
        Get
            Return _MarkThumb
        End Get
        Set(value As String)
            _MarkThumb = value
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
