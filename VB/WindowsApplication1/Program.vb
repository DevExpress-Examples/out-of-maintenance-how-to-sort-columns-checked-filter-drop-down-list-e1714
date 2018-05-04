Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace WindowsApplication1
    Friend NotInheritable Class Program

        Private Sub New()
        End Sub

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Dim form As New Form()
            E1714.Init(form)
            Application.Run(form)
        End Sub
    End Class
End Namespace