Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports System
Imports System.Collections
Imports System.Data
Imports System.Windows.Forms

Namespace WindowsApplication1
    Public Class E1714
        Private Shared Function GetData() As DataTable
            Dim dt As New DataTable()
            dt.Columns.Add("Category", GetType(String))
            dt.Columns.Add("Product", GetType(String))
            dt.Columns.Add("Price", GetType(Single))
            dt.Columns.Add("Quantity", GetType(Single))

            dt.Rows.Add(New Object() { "Beverages", "Chai", 1.6, 319 })
            dt.Rows.Add(New Object() { "Beverages", "Chai", 6295.5, 399 })
            dt.Rows.Add(New Object() { "Beverages", "Ipoh Coffee", 10034.9, 228 })
            dt.Rows.Add(New Object() { "Confections", "Chocolade", 1282.1, 130 })
            dt.Rows.Add(New Object() { "Confections", "Chocolade", 86.7, 8 })
            dt.Rows.Add(New Object() { "Confections", "Scottish Longbreads", 3909.0, 380 })
            Return dt
        End Function

        Public Shared Sub Init(ByVal form As Form)
            Dim grid As New GridControl()
            grid.Dock = DockStyle.Fill
            form.Controls.Add(grid)
            grid.DataSource = GetData()
            grid.ForceInitialize()

            Dim columnView As ColumnView = (CType(grid.DefaultView, ColumnView))
            For Each column As GridColumn In columnView.Columns
                column.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList
            Next column
            Dim handler As FilterPopupCheckedListBoxEventHandler = Sub(sender As Object, e As FilterPopupCheckedListBoxEventArgs)
                Dim list As New ArrayList(e.CheckedComboBox.Items)
                list.Sort(New CheckedListBoxItemComparer(SortDirection.Descending))
                e.CheckedComboBox.Items.Clear()
                e.CheckedComboBox.Items.AddRange(list.ToArray())
            End Sub
            AddHandler columnView.ShowFilterPopupCheckedListBox, handler
        End Sub
    End Class

    Public Class CheckedListBoxItemComparer
        Implements IComparer

        Private directionCore As SortDirection = SortDirection.Ascending

        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal direction As SortDirection)
            Me.directionCore = direction
        End Sub

        Private Function IComparer_Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Dim listBoxItemX As CheckedListBoxItem = TryCast(x, CheckedListBoxItem), listBoxItemY As CheckedListBoxItem = TryCast(y, CheckedListBoxItem)
            Dim filterItemX As FilterItem = If(listBoxItemX IsNot Nothing, TryCast(listBoxItemX.Value, FilterItem), Nothing), filterItemY As FilterItem = If(listBoxItemY IsNot Nothing, TryCast(listBoxItemY.Value, FilterItem), Nothing)
            Dim itemValueX As IComparable = If(filterItemX IsNot Nothing, TryCast(filterItemX.Value, IComparable), Nothing), itemValueY As IComparable = If(filterItemY IsNot Nothing, TryCast(filterItemY.Value, IComparable), Nothing)
            If directionCore = SortDirection.Ascending Then
                Return Comparer.Default.Compare(itemValueX, itemValueY)
            Else
                Return Comparer.Default.Compare(itemValueY, itemValueX)
            End If
        End Function
    End Class
    Public Enum SortDirection
        Ascending
        Descending
    End Enum
End Namespace