Public Class frmAboutBox

    Private Sub frmAboutBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.AssemblyInfo.Title <> "" Then
            ApplicationTitle = My.Application.AssemblyInfo.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.AssemblyInfo.Name)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.AssemblyInfo.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.AssemblyInfo.Version.ToString)
        Me.LabelCopyright.Text = My.Application.AssemblyInfo.LegalCopyright
        Me.LabelCompanyName.Text = My.Application.AssemblyInfo.CompanyName
        Me.TextBoxDescription.Text = My.Application.AssemblyInfo.Description
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

End Class
