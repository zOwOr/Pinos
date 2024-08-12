Imports System
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Xml
Imports System.IO
Imports System.Data.Common
Imports System.Web



Public Class wsAccountHistory
    Inherits System.Web.UI.Page
    Dim Bd As Microsoft.Practices.EnterpriseLibrary.Data.Database '= DatabaseFactory.CreateDatabase("MySQLConnection")


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim _idC As Integer = Request.QueryString("ck")
        Dim _limit_lower As String = 0
        Dim _where As String = " 1=1 "
        Dim _order_by As String = "idOrders"
        Dim _rows = 25
        Dim _current = 1
        Dim _limit_l = (_current * _rows) - (_rows)
        Dim _limit_h = _limit_lower + _rows
        Dim _search As String = ""
        Dim _nRows As String = ""

        'Data: $_POST["sort"] 
        If Request.Form.Keys.Count > 0 Then

            Dim _sort As String
            For i = 0 To Request.Form.Keys.Count - 1
                If Request.Form.Keys(i).IndexOf("sort") <> -1 Then

                    _sort = Request.Form.Keys(i)
                    _sort = _sort.Replace("sort[", "")
                    _sort = _sort.Replace("]", "")

                    If _order_by = "idOrders" Then
                        _order_by = _sort
                    Else
                        _order_by += "," & _sort
                    End If
                End If
            Next

        End If

        If Request.Form("searchPhrase") IsNot Nothing Then
            If Request.Form("searchPhrase") <> "" Then
                _search = LTrim(RTrim(Request.Form("searchPhrase")))
                _where = _where & " AND ( nOrder LIKE '" + _search + "%' ) "
            End If
        End If

        If Request.Form("rowCount") IsNot Nothing Then
            _rows = Request.Form("rowCount")
        End If

        If Request.Form("current") IsNot Nothing Then
            _current = Request.Form("current")
            _limit_l = (_current * _rows) - (_rows)
            _limit_h = _rows
        End If

        Dim _limit As String
        If _rows = -1 Then
            _limit = ""  'no limit
        Else
            _limit = String.Format("LIMIT {0}, {1}", _limit_l, _limit_h)
        End If

        Dim _sql As String = ""
        _sql = String.Format("SELECT idOrders, nOrder, OrderDate, Total, Products, OrderCancel, Status  FROM sales_list WHERE idCustomers = {0} and  {1} ORDER BY {2} {3}", _idC, _where, _order_by, _limit)

        Dim sqlcomando As Common.DbCommand = Bd.GetSqlStringCommand(_sql)
        Dim ds As DataSet = Bd.ExecuteDataSet(sqlcomando)
        Dim _jsonT0 As String = ConvertDataTabletoString(ds.Tables(0))

        _sql = String.Format("select count(*) as total from sales_list where  idCustomers={0} and {1} ", _idC, _where)
        Dim sqlcomando2 As Common.DbCommand = Bd.GetSqlStringCommand(_sql)
        Dim ds2 As DataSet = Bd.ExecuteDataSet(sqlcomando2)
        _nRows = ds2.Tables(0).Rows(0).Item("total").ToString

        'echo "{ \"current\":  $current, \"rowCount\":$rows,  \"rows\": ".$json.", \"total\": $nRows }";
        Dim _echo As String
        _echo = "{ ""current"": " & _current & " ," & _
         " ""rowCount"": " & _rows & " ," & _
         " ""rows"": " & _jsonT0 & " ," & _
        " ""total"": " & _nRows & " }"

        Response.Clear()
        Response.ContentType = "application/json; charset=utf-8"
        Response.Write(_echo)


    End Sub


    Public Function ConvertDataTabletoString(dt As DataTable) As String

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim rows As New List(Of Dictionary(Of String, Object))()
        Dim row As Dictionary(Of String, Object)
        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)()
            For Each col As DataColumn In dt.Columns
                row.Add(col.ColumnName, dr(col))
            Next
            rows.Add(row)
        Next


        Return serializer.Serialize(rows)

    End Function



End Class