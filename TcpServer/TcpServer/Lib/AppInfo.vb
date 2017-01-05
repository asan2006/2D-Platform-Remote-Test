Imports System.Reflection
Public Class AppInfo
    Public Shared ReadOnly Property AssemblyName As String
        Get
            Dim asmName = Assembly.GetExecutingAssembly.GetName.Name
            Return asmName
        End Get
    End Property
End Class
