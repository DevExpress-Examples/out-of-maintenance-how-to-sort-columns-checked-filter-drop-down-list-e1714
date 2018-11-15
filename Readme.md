<!-- default file list -->
*Files to look at*:

* [E1714.cs](./CS/WindowsApplication1/E1714.cs) (VB: [E1714.vb](./VB/WindowsApplication1/E1714.vb))
<!-- default file list end -->
# How to sort column's checked filter drop down list


<p>This example demonstrates how to sort items shown within the <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument1425">checked filter drop down list</a> the via the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsBaseColumnView_ShowFilterPopupCheckedListBoxtopic">ShowFilterPopupCheckedListBox</a> event.<br />
This will be a generic solution that can be used for columns of various types. To achieve this, we will implement a class supporting the <a href="http://msdn.microsoft.com/en-us/library/system.collections.icomparer.aspx">IComparer</a> interface, and will use it to sort the items in ascending and descending order.</p>

<br/>


