Public Class InfoCategories
#Region "Variable"
    Private _IdCategories As String
    Private _CategoryName As String
    Private _Description As String
    Private _Active As Boolean
#End Region

#Region "Builder"
    Sub New()
        MyBase.New()
    End Sub
#End Region

#Region "Property"

    Public Property IdCategories As String
        Get
            Return _IdCategories
        End Get
        Set(value As String)
            _IdCategories = value
        End Set
    End Property
    Public Property CategoryName As String
        Get
            Return _CategoryName
        End Get
        Set(value As String)
            _CategoryName = value
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
