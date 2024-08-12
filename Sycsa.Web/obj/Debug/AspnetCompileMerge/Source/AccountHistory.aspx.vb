Imports System
Imports sycsa.Information
Imports sycsa.BusinessLayer
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Public Class AccountHistory
    Inherits System.Web.UI.Page
    Dim common As New CONECTASQL.ConectaSQL
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'Title
        Page.Title = "Historial de pedidos"

        Dim DataSet As New DataSet
        Dim id As String = IIf(Session("MM_CLIENTE") Is Nothing, "0", Session("MM_CLIENTE"))
        DataSet = common.sqlconsulta("select Clave, Folio, Fecha_Alta, Orden_Comp,Sub_Total, Tot_IVA, Total, Estatus  from docven where Tipo_Doc = 'PED' and Serie ='IN' and Cliente =" & id, "dPedidos")
        tbHistorySales.DataSource = DataSet
        tbHistorySales.DataBind()
    End Sub
    Protected Sub tbHistorySales_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles tbHistorySales.RowCommand
        If e.CommandName = "Imprimir" Then
            Dim queryString As String = "/Default.aspx?clav=" & e.CommandArgument.ToString() & "&name_report=" & "pedido.frx"

            Dim newWin As String = "window.open('" & queryString & "','Facturas','height=550, width=870,toolbar=no,directories=no,status=no, menubar=no,scrollbars=yes,resizable=no');"

            ClientScript.RegisterStartupScript(Me.GetType(), "Facturas", newWin, True)
        End If
    End Sub

End Class