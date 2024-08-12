Public Class InfoSubCategories

#Region "Variable"
    Private _IdSubCategories As Long
    Private _IdCategories As String
    Private _SubCategoriesName As String
    Private _Description As String
    Private _Active As Boolean
#End Region


#Region "Builder"
    Sub New()
        MyBase.New()
    End Sub
#End Region


#Region "Property"
    Public Property IdSubCategories As Long
        Get
            Return _IdSubCategories
        End Get
        Set(value As Long)
            _IdSubCategories = value
        End Set
    End Property
    Public Property IdCategories As String
        Get
            Return _IdCategories
        End Get
        Set(value As String)
            _IdCategories = value
        End Set
    End Property
    Public Property SubCategoriesName As String
        Get
            Return _SubCategoriesName
        End Get
        Set(value As String)
            _SubCategoriesName = value
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
