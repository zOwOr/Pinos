Public Class InfoOrdersCanceled
#Region "Variable"
    Private _IdCancellations As Integer
    Private _IdOrders As Int64
    Private _DescriptionCancellation As String
    Private _CancellationDate As DateTime
#End Region

#Region "Builder"
    Sub New()
        MyBase.New()
    End Sub
#End Region

#Region "Propertys"
    Public Property IdCancellations As Integer
        Get
            Return _IdCancellations
        End Get
        Set(value As Integer)
            _IdCancellations = value
        End Set
    End Property
    Public Property IdOrders As Int64
        Get
            Return _IdOrders
        End Get
        Set(value As Int64)
            _IdOrders = value
        End Set
    End Property
    Public Property DescriptionCancellation As String
        Get
            Return _DescriptionCancellation
        End Get
        Set(value As String)
            _DescriptionCancellation = value
        End Set
    End Property
    Public Property CancellationDate As DateTime
        Get
            Return _CancellationDate
        End Get
        Set(value As DateTime)
            _CancellationDate = value
        End Set
    End Property
#End Region
End Class
