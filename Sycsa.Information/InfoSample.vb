
Public Class InfoSample

#Region "Variable"
    ''La variable se declara con un  _ seguido del nombre del campo en  ingles con formarto PascalCasing.
    Private _IdUser As Integer
    Private _Name As String
#End Region

#Region "Builder"
    Sub New()
        MyBase.New()
    End Sub
#End Region

#Region "Property"
    ''La propiedad sera declarado en ingles sin el _ que hace  referencia  al tipo de dato referenciado, esto debe estar en formato PascalCasting.
    Public Property IdUser As Integer
        Get
            Return _IdUser
        End Get
        Set(value As Integer)
            _IdUser = value
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
#End Region

End Class
