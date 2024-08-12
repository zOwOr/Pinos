Public Class InfoMenuRelationShips
#Region "Variable"
    Private _IdMenuRelationShips As Int64
    Private _IdObject As Int64
    Private _IdMenu As Int64
    Private _Oder As Integer
#End Region

#Region "Builder"
    Sub New()
        MyBase.New()
    End Sub
#End Region

#Region "Propertys"
    Public Property IdMenuRelationShips As Int64
        Get
            Return _IdMenuRelationShips
        End Get
        Set(value As Int64)
            _IdMenuRelationShips = value
        End Set
    End Property
    Public Property IdObject As Int64
        Get
            Return _IdObject
        End Get
        Set(value As Int64)
            _IdObject = value
        End Set
    End Property
    Public Property IdMenu As Int64
        Get
            Return _IdMenu
        End Get
        Set(value As Int64)
            _IdMenu = value
        End Set
    End Property
    Public Property Order As Integer
        Get
            Return _Oder
        End Get
        Set(value As Integer)
            _Oder = value
        End Set
    End Property
#End Region
End Class
