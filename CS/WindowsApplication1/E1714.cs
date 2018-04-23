using System;
using System.Data;
using System.Collections;
using DevExpress.XtraGrid;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Controls;

namespace WindowsApplication1 {
    public class E1714 {
        private static DataTable GetData() {
            DataTable dt = new DataTable();
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Product", typeof(string));
            dt.Columns.Add("Price", typeof(float));
            dt.Columns.Add("Quantity", typeof(float));

            dt.Rows.Add(new object[] { "Beverages", "Chai", 1.6, 319 });
            dt.Rows.Add(new object[] { "Beverages", "Chai", 6295.5, 399 });
            dt.Rows.Add(new object[] { "Beverages", "Ipoh Coffee", 10034.9, 228 });
            dt.Rows.Add(new object[] { "Confections", "Chocolade", 1282.1, 130 });
            dt.Rows.Add(new object[] { "Confections", "Chocolade", 86.7, 8 });
            dt.Rows.Add(new object[] { "Confections", "Scottish Longbreads", 3909.0, 380 });
            return dt;
        }
        public static void Init(Form form) {
            GridControl grid = new GridControl();
            grid.Dock = DockStyle.Fill;
            form.Controls.Add(grid);
            grid.DataSource = GetData();
            grid.ForceInitialize();

            ColumnView columnView = ((ColumnView)grid.DefaultView);
            foreach (GridColumn column in columnView.Columns) {
                column.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;
            }
            FilterPopupCheckedListBoxEventHandler handler = delegate(object sender, FilterPopupCheckedListBoxEventArgs e) {
                ArrayList list = new ArrayList(e.CheckedComboBox.Items);
                list.Sort(new CheckedListBoxItemComparer(SortDirection.Descending));
                e.CheckedComboBox.Items.Clear();
                e.CheckedComboBox.Items.AddRange(list.ToArray());
            };
            columnView.ShowFilterPopupCheckedListBox += handler;
        }
    }
    public class CheckedListBoxItemComparer : IComparer {
        private SortDirection directionCore = SortDirection.Ascending;
        public CheckedListBoxItemComparer() : base() { }
        public CheckedListBoxItemComparer(SortDirection direction) { this.directionCore = direction; }

        int IComparer.Compare(object x, object y) {
            CheckedListBoxItem listBoxItemX = x as CheckedListBoxItem, listBoxItemY = y as CheckedListBoxItem;
            FilterItem filterItemX = listBoxItemX != null ? listBoxItemX.Value as FilterItem : null, filterItemY = listBoxItemY != null ? listBoxItemY.Value as FilterItem : null;
            IComparable itemValueX = filterItemX != null ? filterItemX.Value as IComparable : null, itemValueY = filterItemY != null ? filterItemY.Value as IComparable : null;
            if (directionCore == SortDirection.Ascending)
                return Comparer.Default.Compare(itemValueX, itemValueY);
            else {
                return Comparer.Default.Compare(itemValueY, itemValueX);
            }
        }
    }
    public enum SortDirection { Ascending, Descending }
}