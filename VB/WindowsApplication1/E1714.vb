Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Collections
Imports DevExpress.XtraGrid
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraEditors.Controls

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
			AddHandler columnView.ShowFilterPopupCheckedListBox, AddressOf columnView_ShowFilterPopupCheckedListBox
		End Sub
		Private Shared Sub columnView_ShowFilterPopupCheckedListBox(ByVal sender As Object, ByVal e As FilterPopupCheckedListBoxEventArgs)
			Dim list As New ArrayList(e.CheckedComboBox.Items)
			list.Sort(New CheckedListBoxItemComparer(SortDirection.Descending))
			e.CheckedComboBox.Items.Clear()
			e.CheckedComboBox.Items.AddRange(list.ToArray())
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
			Dim filterItemX As FilterItem = Nothing, filterItemY = Nothing

			If listBoxItemX IsNot Nothing Then 
				filterItemX =  TryCast(listBoxItemX.Value, FilterItem)
			End If
			If listBoxItemY IsNot Nothing Then 
				filterItemY =  TryCast(listBoxItemY.Value, FilterItem)
			End If

			Dim filterItemValueX As IComparable =  Nothing, filterItemValueY As IComparable =  Nothing
			If filterItemX IsNot Nothing Then
				filterItemValueX = TryCast(filterItemX.Value, IComparable)
			End If
			If filterItemY IsNot Nothing Then
				filterItemValueY = TryCast(filterItemY.Value, IComparable)
			End If

			If directionCore = SortDirection.Ascending Then
				Return Comparer.Default.Compare(filterItemValueX, filterItemValueY)
			Else
				Return Comparer.Default.Compare(filterItemValueY, filterItemValueX)
			End If
		End Function
	End Class
	Public Enum SortDirection
		Ascending
		Descending
	End Enum
End Namespace